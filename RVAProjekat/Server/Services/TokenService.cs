using Common.Contracts;
using Common.Helpers;
using Server.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class TokenService : ITokenService
    {
        IDBContracts db = new DataBaseProvider();
        object x = new object();

        public void GenerateToken(int userID, int level)
        {
            MyLogger.Instance().Log("Generate Token -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    MyLogger.Instance().Log("Generate Token -- SUCCESS", "Service", "INFO");
                    db.GenerateToken(userID, level);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Generate Token -- ERROR", "Service", "FATAL");
            }
            
        }

        public void RecallToken(int userID)
        {
            MyLogger.Instance().Log("Recall Token -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    MyLogger.Instance().Log("Recall Token -- SUCCESS", "Service", "INFO");
                    db.DeleteToken(userID);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Recall Token -- FAIL", "Service", "FATAL");
            }

            
        }
    }
}
