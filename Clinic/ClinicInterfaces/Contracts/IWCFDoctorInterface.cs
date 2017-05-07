using ClinicInterfaces.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClinicInterfaces.Contracts
{
    [ServiceContract]
    public interface IWCFDoctorInterface
    {
        [OperationContract]
        List<DoctorConsultation> GetOwnedConsultations(int id);

        [OperationContract]
        void UpdateDoctorConsultation(int id, string details);
    }
}
