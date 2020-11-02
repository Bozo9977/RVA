using Common.Models;
using Server.DatabaseAccess;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataBaseProvider projectDBContext = new DataBaseProvider();
            //User u = new User() { Username = "admin", Password="admin" };
            //projectDBContext.AddUserToDatabase(u);

            //DataBaseProvider provider = new DataBaseProvider();
            //User u = new User() { Username = "admin", Password = "admin", Name = "admin", LastName = "admin" };
            //provider.AddUserToDatabase(u);


            //Gate g = new Gate() { Name = "Gate2", Checks = new List<Check>() { new Check() { Token = new Token(), Datetime = DateTime.Now, Type = CheckType.IN } } };
            //provider.AddGateToDataBase(g);

            new DataInitializer();

            Service servisi = new Service();
            servisi.Open();
            Console.ReadLine();
            servisi.Close();
        }
    }
}
