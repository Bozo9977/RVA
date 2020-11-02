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
    public class GateService : IGateService
    {
        IDBContracts db = new DataBaseProvider();
        object x = new object();

        public bool AddGate(string name, int levelOfAccess)
        {
            MyLogger.Instance().Log("Add Gate -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    db.AddGateToDataBase(new Gate() { Name = name, LevelOfAccess = levelOfAccess });
                    MyLogger.Instance().Log("Add Gate -- SUCCESS!", "Service", "INFO");
                    return true;
                }
            }
            catch
            {
                MyLogger.Instance().Log("Add Gate -- FAIL!", "Service", "Error");
                return false;
            }
            
        }

        public void BanUser(string username, int gateID)
        {
            MyLogger.Instance().Log("Ban user -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    MyLogger.Instance().Log("Ban user -- SUCCESS", "Service", "INFO");
                    db.BanUser(username, gateID);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Ban user -- FAIL", "Service", "FATAL");
            }
            
        }

        public bool ChangeGate(string gateName, int levelOfAccess, Gate selectedGate)
        {
            MyLogger.Instance().Log("Change Gate -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    db.ChangeGate(gateName, levelOfAccess, selectedGate);
                    MyLogger.Instance().Log("Change gate -- SUCCESS!", "Service", "INFO");
                    return true;
                }
            }
            catch
            {
                MyLogger.Instance().Log("Change gate -- FAIL!", "Service", "ERROR");
                return false;
            }

            
            //throw new NotImplementedException();
        }

        public void CloneCheck(Check check)
        {
            MyLogger.Instance().Log("Clone Check -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    db.CloneCheck(check);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Clone Check -- ERROR", "Service", "FATAL");
            }

            
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="check"></param>
        public void DeleteCheck(Check check)
        {
            MyLogger.Instance().Log("Delete Check -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    db.DeleteCheck(check);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Delete Check -- ERROR", "Service", "FATAL");
            }
            
        }

        public void DeleteGate(Gate selectedGate)
        {
            MyLogger.Instance().Log("Delete Gate -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    db.DeleteGate(selectedGate);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Delete Gate -- ERROR", "Service", "FATAL");
            }
            
        }

        public List<Gate> GetAllGates()
        {
            //MyLogger.Instance().Log("Get Gates -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    return db.GetGates();
                }
            }
            catch
            {
                MyLogger.Instance().Log("Get Gates -- ERROR", "Service", "FATAL");
                return new List<Gate>();
            }
            
        }

        public List<Check> GetChecks()
        {
            //MyLogger.Instance().Log("Get Checks -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    return db.GetAllChecks();
                }
            }
            catch
            {
                MyLogger.Instance().Log("Get Checks -- ERROR", "Service", "FATAL");
                return new List<Check>();
            }
            
        }

        public void ModifyCheck(DateTime newDate, Check check)
        {
            MyLogger.Instance().Log("Modify Check -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    MyLogger.Instance().Log("Modify Check -- SUCCESS", "Service", "INFO");
                    Check toModify = db.GetAllChecks().Find(x => x.Id == check.Id);
                    if(toModify == null)
                    {
                        toModify = check;
                    }
                    toModify.Datetime = newDate;
                    db.ModifyCheck(toModify);

                }
            }
            catch
            {
                MyLogger.Instance().Log("Modify Check -- FAIL", "Service", "FATAL");
            }
            
        }

        public bool ValidateCheckChange(Check check)
        {
            MyLogger.Instance().Log("Validate Check -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    using (ProjectDBContext dBContext = new ProjectDBContext())
                    {
                        Check toValidate = dBContext.Checks.ToList().Find(x => x.Id == check.Id);
                        if (DateTime.Compare(check.Datetime, dBContext.Checks.ToList().Find(x => x.Id == check.Id).Datetime) != 0)
                        {
                            MyLogger.Instance().Log("Validate Check -- FAILED", "Service", "INFO");
                            return false;
                        }
                        else
                        {
                            MyLogger.Instance().Log("Validate Check -- SUCCESS", "Service", "INFO");
                            return true;
                        }   
                    }
                }
            }
            catch
            {
                MyLogger.Instance().Log("Validate Check -- ERROR", "Service", "FATAL");
                return false;
            }
            
        }

        public bool ValidateCheckDeletion(Check check)
        {
            MyLogger.Instance().Log("Validate Check's deletion -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    using (ProjectDBContext dBContext = new ProjectDBContext())
                    {
                        Check toDelete = dBContext.Checks.ToList().Find(c => c.Id == check.Id);
                        if (dBContext.Checks.ToList().Exists(x => x.Id == check.Id))
                        {
                            MyLogger.Instance().Log("Validate Check's deletion -- SUCCESS", "Service", "INFO");
                            return true;
                        }
                        else
                        {
                            MyLogger.Instance().Log("Validate Check's deletion -- FAIL", "Service", "ERROR");
                            return false;
                        }   
                    }
                }
            }
            catch
            {
                MyLogger.Instance().Log("Validate Check's deletion -- ERROR", "Service", "FATAL");
                return false;
            }
            
        }

        public int FindLastCheckID()
        {
            MyLogger.Instance().Log("Find Last Check's ID -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    return db.FindLastCheckID();
                }
            }
            catch
            {
                MyLogger.Instance().Log("Find Last Check's ID -- ERROR", "Service", "FATAL");
                return -1;
            }
            
        }

        public Check FindLastCheck()
        {
            MyLogger.Instance().Log("Find Last Check -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    return db.FindLastCheck();
                }
            }
            catch
            {
                MyLogger.Instance().Log("Find Last check -- ERROR", "Service", "FATAL");
                return null;
            }
            
        }
        public Check FindCheckByID(int id)
        {
            MyLogger.Instance().Log("Find check by id -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    return db.FindCheckByID(id);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Find check by id -- ERROR", "Service", "FATAL");
                return null;
            }
            
        }

        public List<Check> SearchedChecks(string searchParam, DateTime selectedDate)
        {
            MyLogger.Instance().Log($"Search {searchParam} -- CALLED", "Service", "INFO");
            ISearch search;
            try
            {
                lock (x)
                {
                    if (searchParam == "ON")
                        search = new SearchOn();
                    else if (searchParam == "BEFORE")
                        search = new SearchBefore();
                    else if (searchParam == "AFTER")
                        search = new SearchAfter();
                    else
                        return GetChecks();
                    return search.SearchChecks(selectedDate);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Search command -- ERROR", "Service", "FATAL");
                return null;
            }
            
        }
    }
}
