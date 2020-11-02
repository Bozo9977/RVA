using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [DataContract]
	public class Gate {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DataMember]
        public int GateID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public ICollection<Check> Checks { get; set; }
        [DataMember]
        public int LevelOfAccess { get; set; }
        

        public Gate(){
            Checks = new List<Check>();
		}

		~Gate(){

		}

        
    }//end Gate

}//end namespace PSI.RVA