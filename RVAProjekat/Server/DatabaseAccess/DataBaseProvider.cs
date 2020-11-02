using Common.Helpers;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DatabaseAccess
{
    public class DataBaseProvider : IDBContracts
    {
        ProjectDBContext projectDBContext = new ProjectDBContext();

        public void AddUserToDatabase(User user)
        {
            projectDBContext.Users.Add(user);
            projectDBContext.SaveChanges();
        }

      
        public void UpdateUserToDatabase(User user)
        {
            using (ProjectDBContext dbContext = new ProjectDBContext())
            {
                dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            }
            
        }

        public void DeleteUserFromDatabase(User user)
        {
            User userToDelete = new User(user);
            foreach(User u in projectDBContext.Users)
            {
                if(u.Id == user.Id)
                    userToDelete = u;
            }

            projectDBContext.Users.Remove(userToDelete);
            projectDBContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            using(ProjectDBContext dBContext = new ProjectDBContext())
            {
                return dBContext.Users.ToList();
            }
        }

        public bool ValidateUser(User user)
        {
            List<User> users = GetAllUsers();
            if (users.SingleOrDefault(x => x.Username == user.Username) != null)
            {
                MyLogger.Instance().Log("Validate user -- SUCCESS!", "Service", "ERROR");
                return false;
            }
            else
            {
                MyLogger.Instance().Log("Validate user -- SUCCESS!", "Service", "INFO");
                return true;
            }
                
        }
        public void AddGateToDataBase(Gate gate)
        {
            projectDBContext.Gates.Add(gate);
            projectDBContext.SaveChanges();
        }

        public List<Gate> GetGates()
        {
            List<Gate> gates = new List<Gate>();
            using (ProjectDBContext dbContext = new ProjectDBContext())
            {
                foreach (Gate g in dbContext.Gates)
                    gates.Add(g);
            }
            
            
            return gates;
        }


        public void BanUser(string username, int gateID)
        {
            projectDBContext.BanedUsers.Add(new BanedUser() { Username = username, GateID = gateID });
            projectDBContext.SaveChanges();
        }


        public List<Check> GetAllChecks()
        {
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {
                return dbContext.Checks.ToList();
            }
        }

        public void GenerateToken(int userID, int level)
        {
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {
                List<Token> tokensInDB = dbContext.Tokens.ToList<Token>();
                Token tokenToUpdate = tokensInDB.SingleOrDefault(x => x.UserID == userID);
                if (tokenToUpdate == null)
                {
                    Token toAdd = new Token() { UserID = userID, LevelOfAccess = level };
                    dbContext.Tokens.Add(toAdd);
                    dbContext.SaveChanges();
                }
                else
                {
                    Token t = dbContext.Tokens.ToList().Find(x => x.UserID == userID);
                    t.LevelOfAccess = level;
                    dbContext.Tokens.Attach(t);
                    dbContext.Entry(t).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            
            
        }

        public void ChangeGate(string gateName, int levelOfAccess, Gate selectedGate)
        {
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {
                Gate toChange = projectDBContext.Gates.ToList().Find(x => x.GateID == selectedGate.GateID);
                toChange.Name = gateName;
                toChange.LevelOfAccess = levelOfAccess;
                toChange.Checks = selectedGate.Checks;

                dbContext.Gates.Attach(toChange);
                var entry = dbContext.Entry(toChange);
                entry.State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void DeleteGate(Gate selectedGate)
        {
            Gate gateToDelete = new Gate();
            foreach(Gate g in projectDBContext.Gates)
            {
                if (g.GateID == selectedGate.GateID)
                    gateToDelete = g;
            }

            projectDBContext.Gates.Remove(gateToDelete);
            projectDBContext.SaveChanges();
        }

        public void DeleteToken(int userId)
        {
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {
                Token toDelete = new Token();
                foreach (Token t in dbContext.Tokens)
                {
                    if (t.UserID == userId)
                    {
                        toDelete = t;
                        break;
                    }
                }
                dbContext.Tokens.Remove(toDelete);
                dbContext.SaveChanges();
            }
            
        }

        public Token GetUsersToken(User user)
        {
            using (ProjectDBContext dbContext = new ProjectDBContext())
            {
                Token usersToken = dbContext.Tokens.ToList().Find(x => x.UserID == user.Id);
                return usersToken;
            }
            
        }


        public string ValidateGateEntering(User user, Gate gate)
        {
            //using (ProjectDBContext dBContext = new ProjectDBContext())
            //{
                Token usersToken = GetUsersToken(user);

                List<BanedUser> banedFromGates = new List<BanedUser>();
                foreach (BanedUser bu in projectDBContext.BanedUsers)
                {
                    if (bu.Username == user.Username)
                        banedFromGates.Add(bu);
                }

                List<Check> checking = projectDBContext.Checks.ToList();
                List<Token> allTokens = projectDBContext.Tokens.ToList();
                List<Check> enteredGates = projectDBContext.Checks.ToList().FindAll(x => x.Type == CheckType.IN && x.Token.UserID == user.Id);
                List<Check> exitedGates = projectDBContext.Checks.ToList().FindAll(x => x.Type == CheckType.OUT && x.Token.UserID == user.Id);
                

                List<Check> excessEntered = new List<Check>();
                foreach (Check c in enteredGates)
                {
                    if (exitedGates.Find(g => g.GateID == c.GateID) == null)
                    {
                        excessEntered.Add(c);
                    }
                }


                if (usersToken == null || usersToken.LevelOfAccess < gate.LevelOfAccess || banedFromGates.Exists(x => x.GateID == gate.GateID))
                {
                    return "You don't have the clearence!";
                }
                else if (excessEntered.Count > 0 || enteredGates.Count != exitedGates.Count)
                {
                    return "You have already entered a gate.";
                }
                else
                {
                    return "You have passed the gate: " + gate.Name;
                }
            //}
            
        }

        public string ValidateGateExiting(User user, Gate gate)
        {
            Token usersToken = GetUsersToken(user);

            List<Check> checking = projectDBContext.Checks.ToList();
            List<Token> allTokens = projectDBContext.Tokens.ToList();
            List<Check> enteredGates = projectDBContext.Checks.ToList().FindAll(x => x.Type == CheckType.IN && x.Token.UserID == user.Id);
            List<Check> exitedGates = projectDBContext.Checks.ToList().FindAll(x => x.Type == CheckType.OUT && x.Token.UserID == user.Id);
            

            if (enteredGates.Count <= exitedGates.Count)
            {
                return "You must first enter any gate";
            }
            else if(enteredGates.Count > exitedGates.Count)
            {
                if (enteredGates[enteredGates.Count - 1].GateID != gate.GateID)
                    return "You must first exit gate: " + enteredGates[enteredGates.Count - 1].GateID;
                else
                    return "You have exited the gate: " + gate.Name;
            }
            else
            {
                return "You have exited the gate: " + gate.Name;
            }


        }

        public void ModifyCheck(Check check)
        {
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {
                Check c = dbContext.Checks.ToList().Find(x => x.Id == check.Id);
                if (c == null)
                {
                    c = new Check()
                    {
                        Datetime = check.Datetime,
                        GateID = check.GateID,
                        Token = check.Token,
                        TokenId = check.TokenId,
                        Type = check.Type,

                    };
                    dbContext.Add(c);
                    dbContext.SaveChanges();
                    CommandHandler.Instance.UpdateCheckIDS(c.Id, FindLastCheckID());
                }
                else
                {

                    c.Datetime = check.Datetime;
                    dbContext.Checks.Attach(c);
                    dbContext.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    CommandHandler.Instance.UpdateCheckIDS(c.Id, FindLastCheckID());
                }
            }
            
        }

        public void DeleteCheck(Check check)
        {
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {
                Check toDelete = null;
                foreach (Check c in dbContext.Checks)
                {
                    if (c.Id == check.Id)
                    {
                        toDelete = c;
                        break;
                    }
                }
                if(toDelete != null)
                {
                    dbContext.Checks.Remove(toDelete);
                    dbContext.SaveChanges();
                }
            }
            
        }

        public void CloneCheck(Check check)
        {
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {

                Check clone = new Check()
                {
                    Datetime = check.Datetime,
                    GateID = check.GateID,
                    Token = check.Token,
                    TokenId = check.TokenId,
                    Type = check.Type
                };
                dbContext.Checks.Add(clone);
                dbContext.SaveChanges();
                Gate g = dbContext.Gates.ToList().Find(x => x.GateID == check.GateID);
                g.Checks.Add(clone);
                this.ChangeGate(g.Name, g.LevelOfAccess, g);

            }
        }


        public int FindLastCheckID()
        {
            int lastIndex = -1;
            foreach(Check c in projectDBContext.Checks)
            {
                lastIndex = c.Id;
            }
            return lastIndex;
        }

        public Check FindLastCheck()
        {
            Check ret = new Check();
            foreach(Check c in projectDBContext.Checks)
            {
                ret = c;
            }
            return ret;
        }

        public Check FindCheckByID(int id)
        {
            using (ProjectDBContext dbContext = new ProjectDBContext())
            {
                return dbContext.Checks.ToList().Find(x => x.Id == id);
            }
            
        }

        
    }
}
