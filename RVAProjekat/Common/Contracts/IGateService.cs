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
    public interface IGateService
    {
        [OperationContract]
        bool AddGate(string name, int levelOfAccess);

        [OperationContract]
        List<Gate> GetAllGates();

        [OperationContract]
        void BanUser(string username, int gateID);

        [OperationContract]
        bool ChangeGate(string gateName, int levelOfAccess, Gate selectedGate);
        [OperationContract]
        void DeleteGate(Gate selectedGate);
        [OperationContract]
        List<Check> GetChecks();
        [OperationContract]
        void ModifyCheck(DateTime newDate, Check check);

        [OperationContract]
        void DeleteCheck(Check check);

        [OperationContract]
        void CloneCheck(Check check);
        [OperationContract]
        bool ValidateCheckChange(Check check);
        [OperationContract]
        bool ValidateCheckDeletion(Check check);

        [OperationContract]
        int FindLastCheckID();

        [OperationContract]
        Check FindLastCheck();
        //[OperationContract]
        //void AddCheck()
        [OperationContract]
        Check FindCheckByID(int id);
        [OperationContract]
        List<Check> SearchedChecks(string searchParam, DateTime selectedDate);
    }
}
