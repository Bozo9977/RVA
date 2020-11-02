using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DatabaseAccess
{
    public interface IDBContracts
    {
        void AddUserToDatabase(User user);
        void UpdateUserToDatabase(User user);
        List<User> GetAllUsers();
        bool ValidateUser(User user);
        void DeleteUserFromDatabase(User user);


        void GenerateToken(int userID, int level);
        void DeleteToken(int userId);
        Token GetUsersToken(User user);


        void AddGateToDataBase(Gate gate);
        void ChangeGate(string gateName, int levelOfAccess, Gate selectedGate);
        void DeleteGate(Gate selectedGate);
        string ValidateGateEntering(User user, Gate gate);
        string ValidateGateExiting(User user, Gate gate);
        List<Gate> GetGates();


        List<Check> GetAllChecks();
        void ModifyCheck(Check check);
        void DeleteCheck(Check check);
        void CloneCheck(Check check);
        int FindLastCheckID();
        Check FindLastCheck();
        Check FindCheckByID(int id);
        
        
        void BanUser(string username, int gateID);
    }
}
