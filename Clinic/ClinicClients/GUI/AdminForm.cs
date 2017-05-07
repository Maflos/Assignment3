using ClinicInterfaces.Contracts;
using ClinicInterfaces.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;

namespace ClinicClients
{
    public partial class AdminForm : Form
    {
        private ChannelFactory<IWCFAdminInterface> channelFcatory;
        private User admin;

        public AdminForm(User admin)
        {
            InitializeComponent();
            channelFcatory = new ChannelFactory<IWCFAdminInterface>("Admin");
            this.admin = admin;
            resetUserGrid();
        }

        private void resetFields()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void resetUserGrid()
        {
            IWCFAdminInterface proxy = channelFcatory.CreateChannel();
            List<User> userList = proxy.GetUsers();

            dataGridView1.Rows.Clear();

            for (int i = 0; i < userList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = userList[i].Username;
                dataGridView1.Rows[i].Cells[1].Value = userList[i].Password;
                dataGridView1.Rows[i].Cells[2].Value = userList[i].Function;
                dataGridView1.Rows[i].Cells[3].Value = userList[i].UserID;
            }

            dataGridView1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetUserGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IWCFAdminInterface proxy = channelFcatory.CreateChannel();

            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    proxy.InsertUser(new User()
                    {
                        Username = textBox1.Text,
                        Password = textBox2.Text,
                        Function = comboBox1.Text
                    });

                    resetUserGrid();
                    resetFields();
                }
                catch
                {
                    MessageBox.Show("Wrong input!");
                }
            }
            else
            {
                MessageBox.Show("Cannot have empty input!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IWCFAdminInterface proxy = channelFcatory.CreateChannel();

            try
            {
                int rowInderx = dataGridView1.CurrentCell.RowIndex;
                proxy.DeleteUser((int)dataGridView1.Rows[rowInderx].Cells[3].Value);

                resetUserGrid();
                resetFields();
            }
            catch
            {
                MessageBox.Show("Could not Delete!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IWCFAdminInterface proxy = channelFcatory.CreateChannel();

            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    int rowInderx = dataGridView1.CurrentCell.RowIndex;
                    proxy.UpdateUser(new User()
                    {
                        UserID = (int)dataGridView1.Rows[rowInderx].Cells[3].Value,
                        Username = textBox1.Text,
                        Password = textBox2.Text,
                        Function = comboBox1.Text
                    });

                    resetUserGrid();
                    resetFields();
                }
                catch
                {
                    MessageBox.Show("Wrong input!");
                }
            }
        }
    }
}
