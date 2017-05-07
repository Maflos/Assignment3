using ClinicInterfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
    }
}
