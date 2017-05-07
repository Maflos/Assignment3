using ClinicInterfaces.Contracts;
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
    public partial class AdminForm : Form
    {
        private ChannelFactory<IWCFAdminInterface> channelFcatory;

        public AdminForm()
        {
            InitializeComponent();
            channelFcatory = new ChannelFactory<IWCFAdminInterface>("Admin");
        }


    }
}
