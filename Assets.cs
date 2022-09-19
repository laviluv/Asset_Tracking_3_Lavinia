using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking_3_Lavinia
{
    internal class Assets
    {
        public virtual string? ResourceType { get; set; }
        public virtual DateTime Purchased { get; set; }
       // public string? Office { get; set; }

        public virtual string? Brand { get; set; }

        public virtual bool IsDeprecated { get; set; }
    }
}
