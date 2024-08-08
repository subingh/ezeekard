using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Data.Entities.Domain
{
    public class Error
    {
        public long ErrorId { get; set; }
        public int ErrorType { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ClientId { get; set; }
    }
}
