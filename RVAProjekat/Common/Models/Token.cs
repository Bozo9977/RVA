using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Models {
    [DataContract]
	public class Token {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int LevelOfAccess { get; set; }

        public Token(){

		}

		~Token(){

		}

       
    }//end Token

}//end namespace PSI.RVA