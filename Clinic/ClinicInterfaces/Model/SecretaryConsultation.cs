﻿using System;

namespace ClinicInterfaces.Model
{
    public class SecretaryConsultation
    {
        public int ConsultationID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public DateTime Date { get; set; }
    }
}
