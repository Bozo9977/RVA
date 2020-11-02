using Common.Models;
using Server.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class DataInitializer
    {
        public DataInitializer()
        {
            PopulateDatabase();
        }

        public void PopulateDatabase()
        {
            using(ProjectDBContext dbContext = new ProjectDBContext())
            {

                if(dbContext.Users.Count() == 0)
                {
                    User Admin = new User()
                    {
                        Name = "Admin",
                        LastName = "Admin",
                        Username = "admin",
                        Password = "admin",
                        Type = USER_TYPE.ADMIN
                    };

                    User user = new User()
                    {
                        Name = "user",
                        LastName = "user",
                        Username = "user",
                        Password = "user",
                        Type = USER_TYPE.USER
                    };

                    dbContext.Users.Add(Admin);
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                    Token adminToken = new Token()
                    {
                        LevelOfAccess = 10,
                        UserID = dbContext.Users.ToList()[0].Id
                    };

                    dbContext.Tokens.Add(adminToken);
                    dbContext.SaveChanges();
                }

                if (dbContext.Tokens.Count() == 0)
                {
                    Token adminToken = new Token()
                    {
                        LevelOfAccess = 10,
                        UserID = dbContext.Users.ToList()[0].Id
                    };

                    dbContext.Tokens.Add(adminToken);
                    dbContext.SaveChanges();
                }

                if (dbContext.Gates.Count() == 0 /*&& dbContext.Checks.Count() == 0*/)
                {
                    Gate gate1 = new Gate()
                    {
                        Name = "Front gate",
                        LevelOfAccess = 2
                    };

                    Gate gate2 = new Gate()
                    {
                        Name = "Back gate",
                        LevelOfAccess = 3
                    };

                    dbContext.Gates.Add(gate1);
                    dbContext.Gates.Add(gate2);
                    dbContext.SaveChanges();


                    //Check adminCheck = new Check()
                    //{
                    //    Datetime = DateTime.Today,
                    //    Token = dbContext.Tokens.ToList().Find(t => t.UserID == dbContext.Users.ToList()[0].Id),
                    //    Type = CheckType.IN,
                    //    GateID = dbContext.Gates.ToList()[0].GateID
                    //};

                    //dbContext.Checks.Add(adminCheck);
                    //dbContext.SaveChanges();
                }

                if(dbContext.Checks.Count()== 0)
                {
                    if(dbContext.Tokens.Count() != 0)
                    {
                        Check newCheck = new Check()
                        {
                            Datetime = DateTime.Today,
                            Token = dbContext.Tokens.ToList()[0],
                            Type = CheckType.IN,
                            TokenId = dbContext.Tokens.ToList()[0].Id,
                            GateID = dbContext.Gates.ToList()[0].GateID
                        };

                        dbContext.Checks.Add(newCheck);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        
                        Check newCheck = new Check()
                        {
                            Datetime = DateTime.Today,
                            Token = dbContext.Tokens.ToList()[0],
                            Type = CheckType.IN,
                            TokenId = dbContext.Tokens.ToList()[0].Id,
                            GateID = dbContext.Gates.ToList()[0].GateID
                        };
                        dbContext.Add(newCheck);
                        dbContext.SaveChanges();
                    }
                    
                }


                

                List<Gate> gates = dbContext.Gates.ToList();
            }
        }
    }
}
