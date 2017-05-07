using System;

namespace ClinicInterfaces.Model
{
    public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IDCardNr { get; set; }
        public int PIN { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
