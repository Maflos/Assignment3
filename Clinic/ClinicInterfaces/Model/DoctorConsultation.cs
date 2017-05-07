using System;

namespace ClinicInterfaces.Model
{
    public class DoctorConsultation
    {
        public int ConsultationID { get; set; }
        public string PatientName { get; set; }
        public int PatientID { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
    }
}
