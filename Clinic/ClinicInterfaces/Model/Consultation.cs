using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicInterfaces.Model
{
    public class Consultation
    {
        public int ConsultationID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public string Details { get; set; }
    }
}
