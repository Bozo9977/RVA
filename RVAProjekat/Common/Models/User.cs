using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class User 
    {
        #region Fields
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public String Username { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public USER_TYPE Type { get; set; }
        [DataMember]
        public bool Baned { get; set; }

        #endregion

        #region Constructor
        public User() { }

        public User(User user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
            this.Name = user.Name;
            this.LastName = user.LastName;
            this.Type = user.Type;
        }
        public User(String userName, String password)
        {
            Username = userName;
            Password = password;
        }


        
       
        #endregion

    }
}
