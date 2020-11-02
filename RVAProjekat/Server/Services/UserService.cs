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
    public class UserService : IUserService
    {
        IDBContracts database = new DataBaseProvider();
        object x = new object();

        public bool AddUser(User user)
        {
            MyLogger.Instance().Log("Add user -- initiated", "Service", "INFO");
            try
            {
                lock (x)
                {
                    if (database.ValidateUser(user))
                        database.AddUserToDatabase(user);
                    else
                    {
                        MyLogger.Instance().Log("Add user -- FAIL!", "Service", "INFO");
                        return false;
                    }                        
                    MyLogger.Instance().Log("Add user -- SUCCESS!", "Service", "INFO");
                    return true;
                }
                
            }catch(Exception e){
                MyLogger.Instance().Log("Add user -- FAIL!", "Service", "FATAL");
                return false;
            }
        }

        public bool ChangeInfo(User user)
        {
            MyLogger.Instance().Log("Change user -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    User userToUpdate = database.GetAllUsers().Find(x => x.Username == user.Username);
                    userToUpdate.Name = user.Name;
                    userToUpdate.LastName = user.LastName;
                    userToUpdate.Password = user.Password;
                    database.UpdateUserToDatabase(userToUpdate);
                    MyLogger.Instance().Log("Change info -- SUCCESS!", "Service", "INFO");
                    return true;
                }
                
            }
            catch(Exception e)
            {
                MyLogger.Instance().Log("Change info -- FAIL!", "Service", "FATAL");
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            MyLogger.Instance().Log("Delete user -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    database.DeleteUserFromDatabase(user);
                    MyLogger.Instance().Log("Delete user -- SUCCESS", "Service", "INFO");
                    return true;
                }
                
            }
            catch(Exception e)
            {
                MyLogger.Instance().Log("Delete user -- ERROR!", "Service", "FATAL");
                return false;
            }
        }

        

        public User Login(string username, string password)
        {
            MyLogger.Instance().Log("Login -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    List<User> users = database.GetAllUsers();
                    User retVal = users.SingleOrDefault(x => x.Username == username && x.Password == password);
                    if(retVal == null)
                    {
                        MyLogger.Instance().Log("Login -- ERROR", "Service", "ERROR");
                    }
                    else
                    {
                        MyLogger.Instance().Log("Login -- SUCCESS", "Service", "INFO");
                    }
                    return retVal;
                }
                
               
            }
            catch(Exception e)
            {
                MyLogger.Instance().Log("Login -- ERROR", "Service", "FATAL");
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            //MyLogger.Instance().Log("Get all users -- CALLED", "Service", "INFO");
            try
            {
                lock (x)
                {
                    //MyLogger.Instance().Log("Get all users -- SUCCESS", "Service", "INFO");
                    return database.GetAllUsers();
                }
            }
            catch
            {
                MyLogger.Instance().Log("Get all users -- ERROR", "Service", "FATAL");
                return null;
            }
            
        }

        public bool ValidateUser(User user)
        {
            MyLogger.Instance().Log("Validate user -- called", "Service", "INFO");
            try
            {
                lock (x)
                {
                    
                    return database.ValidateUser(user);
                }
            }
            catch
            {
                MyLogger.Instance().Log("Validate user -- FAIL!", "Service", "FATAL");
                return false;
            }
            
        }
    }
}
