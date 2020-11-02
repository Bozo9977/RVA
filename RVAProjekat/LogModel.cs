using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProjekat
{
    public class LogModel
    {
        public TimeSpan TimeStamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
