using ClinicInterfaces.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClinicInterfaces.Contracts
{
    [ServiceContract]
    public interface IWCFAdminInterface
    {
        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        void InsertUser(User usr);

        [OperationContract]
        void DeleteUser(int id);

        [OperationContract]
        void UpdateUser(User usr);
    }
}
