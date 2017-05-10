using ClinicInterfaces.Contracts;
using ClinicInterfaces.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;

namespace ClinicClients
{
    public partial class DoctorForm : Form, IObserver
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
                dataGridView1.Rows[i].Cells[5].Value = "no";
            }

            dataGridView1.Update();
        }

        public void Update(int doctorID, int patientID)
        {
            if (doctor.UserID == doctorID)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if ((int)dataGridView1.Rows[i].Cells[3].Value == patientID)
                    {
                        dataGridView1.Rows[i].Cells[5].Value = "yes";
                        break;
                    }
                }
            }
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
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    proxy.UpdateDoctorConsultation((int)dataGridView1.Rows[rowIndex].Cells[4].Value,
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
