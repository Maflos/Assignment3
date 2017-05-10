using ClinicInterfaces.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClinicInterfaces
{
    [ServiceContract]
    public interface IWCFSecretaryInterface
    {
        [OperationContract]
        List<Patient> GetPatients();

        [OperationContract]
        void InsertPatient(Patient pat);

        [OperationContract]
        void DeletePatient(int id);

        [OperationContract]
        void UpdatePatient(Patient pat);

        [OperationContract]
        List<SecretaryConsultation> GetConsultations();

        [OperationContract]
        int GetAvailableDoctorID(DateTime consultationDate);

        [OperationContract]
        void ProgramConsultation(int doctorID, int patientID, DateTime date);
    }
}
