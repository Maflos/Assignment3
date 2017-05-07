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
            resetPatientGrid();
        }

        private void resetFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void resetPatientGrid()
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
                dataGridView1.Rows[i].Cells[3].Value = patientList[i].BirthDate;
                dataGridView1.Rows[i].Cells[4].Value = patientList[i].ID;
            }

            dataGridView1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetPatientGrid();
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

                resetPatientGrid();
                resetFields();
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

                resetPatientGrid();
                resetFields();
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

                resetPatientGrid();
                resetFields();
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
