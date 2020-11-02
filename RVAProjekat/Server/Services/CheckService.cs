using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts;
using Common.Models;
using Server.DatabaseAccess;

namespace Server.Services
{
    public class CheckService : ICheckService
    {
        IDBContracts db = new DataBaseProvider();
        object x = new object();

        public string GenerateCheck(User user, Gate gate, CheckType type)
        {
            string validPassing ="";
            try
            {
                lock (x)
                {
                    if (type == CheckType.IN)
                    {
                        Token t = db.GetUsersToken(user);
                        validPassing = db.ValidateGateEntering(user, gate);
                        if (validPassing.Contains("passed"))
                        {
                            Check newCheck = new Check()
                            {
                                Datetime = DateTime.Now,
                                GateID = gate.GateID,
                                Token = t,
                                Type = type,
                                TokenId = t.Id
                            };

                            Gate g = db.GetGates().Find(x => x.GateID == gate.GateID);
                            g.Checks.Add(newCheck);
                            db.ChangeGate(gate.Name, gate.LevelOfAccess, g);
                        }
                    }
                    else
                    {
                        Token t = db.GetUsersToken(user);
                        validPassing = db.ValidateGateExiting(user, gate);
                        if (validPassing.Contains("exited"))
                        {
                            Check newCheck = new Check()
                            {
                                Datetime = DateTime.Now,
                                GateID = gate.GateID,
                                Token = t,
                                Type = type,
                                TokenId = t.Id
                            };

                            Gate g = db.GetGates().Find(x => x.GateID == gate.GateID);
                            g.Checks.Add(newCheck);
                            db.ChangeGate(gate.Name, gate.LevelOfAccess, g);
                        }
                    }

                    return validPassing;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: "+ e.Message + "\nStack Trace\n"+e.StackTrace);
                return "Exception cought! Contact your system administrator.";
            }
            
           
        }
        
    }
}
