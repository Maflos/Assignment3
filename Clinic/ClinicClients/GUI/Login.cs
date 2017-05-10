using ClinicInterface;
using ClinicInterfaces.Model;
using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace ClinicClients
{
    public partial class Login : Form
    {
        private ChannelFactory<IWCFClinicService> channelFcatory;
        private Subject sbj;

        public Login(Subject sbj)
        {
            InitializeComponent();
            channelFcatory = new ChannelFactory<IWCFClinicService>("ClinicService");
            this.sbj = sbj;
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
                        SecretaryForm sf = new SecretaryForm(user, sbj);
                        sf.Visible = true;
                        break;

                    case "admin":
                        AdminForm af = new AdminForm(user);
                        af.Visible = true;
                        break;

                    case "doctor":
                        DoctorForm df = new DoctorForm(user);
                        sbj.Attach(df);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
