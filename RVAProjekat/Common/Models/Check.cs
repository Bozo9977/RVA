using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract]
    public class Check {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Datetime { get; set; }
        [DataMember]
        public CheckType Type { get; set ; }
        [DataMember]
        public Token Token { get; set; }
        [DataMember]
        public int GateID { get; set; }

        [ForeignKey("Token"),Column("TokenId")]
        [DataMember]
        public int TokenId { get; set; }

        public Check(){

		}

		~Check(){

		}

        
    }//end Check

}//end namespace PSI.RVA