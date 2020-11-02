using Common.Contracts;
using Common.Helpers;
using Common.Models;
using Server.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class GateHandler : IGateHandler
    {
        //IDBContracts db = new DataBaseProvider();
        ICheckService cs = new CheckService();
        object x = new object();

        public string IssueCheck(User user, Gate gate, CheckType type)
        {
            MyLogger.Instance().Log("Issue check -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    //MyLogger.Instance().Log("Issue check -- SUCCESS", "Service", "INFO");
                    return cs.GenerateCheck(user, gate, type);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Issue check -- ERROR", "Service", "FATAL");
                return "Exception cought! Contct your system administrator";
            }
        }

    }
}
