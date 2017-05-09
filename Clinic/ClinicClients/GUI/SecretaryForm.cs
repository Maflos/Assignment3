using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using ClinicInterface;
using ClinicInterfaces.Model;
using ClinicInterfaces;

namespace ClinicClients
{
    public partial class SecretaryForm : Form
    {
        private ChannelFactory<IWCFSecretaryInterface> channelFcatory;
        private User secretary;

        public SecretaryForm(User secretary)
        {
            InitializeComponent();
            dataGridView1.Columns[4].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            channelFcatory = new ChannelFactory<IWCFSecretaryInterface>("Secretary");
            this.secretary = secretary;
            ResetPatientGrid();
            ResetConsultationGrid();
        }

        private void ResetFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void ResetPatientGrid()
        {
            IWCFSecretaryInterface proxy = channelFcatory.CreateChannel();
            List<Patient> patientList = proxy.GetPatients();

            dataGridView1.Rows.Clear();

            for (int i = 0; i < patientList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = patientList[i].Name;
                dataGridView1.Rows[i].Cells[1].Value = patientList[i].IDCardNr;
                dataGridView1.Rows[i].Cells[2].Value = patientList[i].PIN;
                dataGridView1.Rows[i].Cells[3].Value = patientList[i].BirthDate.Date;
                dataGridView1.Rows[i].Cells[4].Value = patientList[i].ID;
            }

            dataGridView1.Update();
        }

        private void ResetConsultationGrid()
        {
            IWCFSecretaryInterface proxy = channelFcatory.CreateChannel();
            List<SecretaryConsultation> consultationList = proxy.GetConsultations();

            dataGridView2.Rows.Clear();

            for (int i = 0; i < consultationList.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = consultationList[i].PatientName;
                dataGridView2.Rows[i].Cells[1].Value = consultationList[i].DoctorName;
                dataGridView2.Rows[i].Cells[2].Value = consultationList[i].Date.Date;
                dataGridView2.Rows[i].Cells[3].Value = consultationList[i].PatientID;
                dataGridView2.Rows[i].Cells[4].Value = consultationList[i].DoctorID;
                dataGridView2.Rows[i].Cells[5].Value = consultationList[i].ConsultationID;
            }

            dataGridView1.Update();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ResetPatientGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IWCFSecretaryInterface proxy = channelFcatory.CreateChannel();

            try
            {
                proxy.InsertPatient(new Patient()
                {
                    Name = textBox1.Text,
                    IDCardNr = int.Parse(textBox2.Text),
                    PIN = int.Parse(textBox3.Text),
                    BirthDate = DateTime.Parse(textBox4.Text)
                });

                ResetPatientGrid();
                ResetFields();
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IWCFSecretaryInterface proxy = channelFcatory.CreateChannel();

            try
            {
                int rowInderx = dataGridView1.CurrentCell.RowIndex;
                proxy.DeletePatient((int)dataGridView1.Rows[rowInderx].Cells[4].Value);

                ResetPatientGrid();
                ResetFields();
            }
            catch
            {
                MessageBox.Show("Could not Delete!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IWCFSecretaryInterface proxy = channelFcatory.CreateChannel();

            try
            {
                int rowInderx = dataGridView1.CurrentCell.RowIndex;

                proxy.UpdatePatient(new Patient() {
                
                    ID = (int)dataGridView1.Rows[rowInderx].Cells[4].Value,
                    Name = textBox1.Text,
                    IDCardNr = int.Parse(textBox2.Text),
                    PIN = int.Parse(textBox3.Text),
                    BirthDate = DateTime.Parse(textBox4.Text)
                });

                ResetPatientGrid();
                ResetFields();
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResetConsultationGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IWCFSecretaryInterface proxy = channelFcatory.CreateChannel();

            try
            {
                int docID = proxy.GetAvailableDoctorID(DateTime.Parse(textBox5.Text));

                if (docID != -1)
                {
                    textBox1.ResetText();
                    textBox1.Text += docID;
                    int rowInderx = dataGridView1.CurrentCell.RowIndex;
                    proxy.ProgramConsultation(docID, (int)dataGridView1.Rows[rowInderx].Cells[4].Value,
                    DateTime.Parse(textBox5.Text));
                    ResetConsultationGrid();
                }
                else
                {
                    MessageBox.Show("No doctor Available!");
                }
            }
            catch
            {
                MessageBox.Show("Wrong input!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
