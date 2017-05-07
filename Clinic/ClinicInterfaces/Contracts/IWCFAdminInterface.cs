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
