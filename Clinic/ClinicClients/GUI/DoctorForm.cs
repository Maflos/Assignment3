using ClinicInterfaces.Contracts;
using ClinicInterfaces.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicClients
{
    public partial class DoctorForm : Form
    {
        private ChannelFactory<IWCFDoctorInterface> channelFcatory;
        private User doctor;

        public DoctorForm(User doctor)
        {
            InitializeComponent();
            channelFcatory = new ChannelFactory<IWCFDoctorInterface>("Doctor");
            this.doctor = doctor;
            ResetDoctorGrid();
        }

        private void ResetDoctorGrid()
        {
            IWCFDoctorInterface proxy = channelFcatory.CreateChannel();
            List<DoctorConsultation> consultationList = proxy.GetOwnedConsultations(doctor.UserID);

            dataGridView1.Rows.Clear();

            for (int i = 0; i < consultationList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = consultationList[i].PatientName;
                dataGridView1.Rows[i].Cells[1].Value = consultationList[i].Date;
                dataGridView1.Rows[i].Cells[2].Value = consultationList[i].Details;
                dataGridView1.Rows[i].Cells[3].Value = consultationList[i].PatientID;
                dataGridView1.Rows[i].Cells[4].Value = consultationList[i].ConsultationID;
            }

            dataGridView1.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetDoctorGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWCFDoctorInterface proxy = channelFcatory.CreateChannel();

            if (richTextBox1.Text != "")
            {
                try
                {
                    int rowInderx = dataGridView1.CurrentCell.RowIndex;
                    proxy.UpdateDoctorConsultation((int)dataGridView1.Rows[rowInderx].Cells[4].Value,
                        richTextBox1.Text);

                    ResetDoctorGrid();
                    richTextBox1.ResetText();
                }
                catch
                {
                    MessageBox.Show("Wrong input!");
                }
            }
        }
    }
}
