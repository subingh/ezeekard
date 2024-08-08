using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Data.Entities.Domain
{
    public class AllClientDetails
    {
        public int Id { get; set; }
        public Guid ClientId { get; set; }
        public virtual Client Client {  get; set; }
        public virtual ClientExtraInfo ClientExtraInfo { get; set; }
        public virtual Company Company { get; set; }
        public virtual CompanyExtraInfo CompanyExtraInfo { get; set; }
    }
}
