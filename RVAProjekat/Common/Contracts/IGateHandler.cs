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
    public interface IGateHandler
    {
        [OperationContract]
        string IssueCheck(User user, Gate gate, CheckType type);

        //[OperationContract]
        //List<Gate> GetAllGates();

        //[OperationContract]
        //void BanUser(string username, int gateID);

        //[OperationContract]
        //List<Check> GetChecks();
    }
}
