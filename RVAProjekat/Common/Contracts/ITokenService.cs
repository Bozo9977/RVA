using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    [ServiceContract]
    public interface ITokenService
    {
        [OperationContract]
        void GenerateToken(int userID, int level);

        [OperationContract]
        void RecallToken(int userID);
    }
}
