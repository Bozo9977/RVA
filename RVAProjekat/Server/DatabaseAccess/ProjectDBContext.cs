using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.DatabaseAccess
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<BanedUser> BanedUsers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RVAProjekat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
