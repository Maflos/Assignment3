using ClinicInterfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClinicInterfaces.Contracts
{
    [ServiceContract]
    public interface IWCFDoctorInterface
    {
        [OperationContract]
        List<Consultation> GetOwnedConsultations();
    }
}
