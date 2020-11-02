using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User Login(string username, string password);

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        bool ChangeInfo(User user);
        [OperationContract]
        bool DeleteUser(User user);
        [OperationContract]
        List<User> GetAllUsers();
        [OperationContract]
        bool ValidateUser(User user);

    }
}
