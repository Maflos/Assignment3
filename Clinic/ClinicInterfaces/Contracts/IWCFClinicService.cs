using ClinicInterfaces.Model;
using System.ServiceModel;

namespace ClinicInterface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFClinicService" in both code and config file together.
    [ServiceContract]
    public interface IWCFClinicService
    {
        [OperationContract]
        User FindUser(string username, string password);
    }
}
