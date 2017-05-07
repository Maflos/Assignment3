using ClinicInterface;
using ClinicInterfaces;
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
    public partial class Login : Form
    {
        private ChannelFactory<IWCFClinicService> channelFcatory;

        public Login()
        {
            InitializeComponent();
            channelFcatory = new ChannelFactory<IWCFClinicService>("ClinicService");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWCFClinicService proxy = channelFcatory.CreateChannel();

            try
            {
               User user = proxy.FindUser(textBox1.Text, textBox2.Text);

                switch (user.Function)
                {
                    case "secretary":
                        SecretaryForm sf = new SecretaryForm(user);
                        sf.Visible = true;
                        break;

                    case "admin":
                        AdminForm af = new AdminForm(user);
                        af.Visible = true;
                        break;

                    case "doctor":
                        DoctorForm df = new DoctorForm(user);
                        df.Visible = true;
                        break;

                    default:
                        break;
                }

                textBox1.Clear();
                textBox2.Clear();
            }
            catch
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("User doesn't exist!");
            }
        }
    }
}
