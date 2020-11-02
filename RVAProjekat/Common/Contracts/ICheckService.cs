using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface ICheckService
    {
        string GenerateCheck(User user, Gate gate, CheckType type);

        //void ModifyCheck(DateTime newDate, Check check);
        
        //List<Check> GetChecks();
    }
}
