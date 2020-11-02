using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
  
    [DataContract(Name = "USER_TYPE")]
    public enum USER_TYPE {[EnumMember] ADMIN = 0, [EnumMember] USER }

    [DataContract(Name ="CheckType")]
    public enum CheckType { [EnumMember] IN=0, [EnumMember] OUT}
}
