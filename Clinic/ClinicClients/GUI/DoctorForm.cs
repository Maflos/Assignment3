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
    public partial class DoctorForm : Form
    {
        private ChannelFactory<IWCFDoctorInterface> channelFcatory;

        public DoctorForm()
        {
            InitializeComponent();
            channelFcatory = new ChannelFactory<IWCFDoctorInterface>("Doctor");
        }
    }
}
