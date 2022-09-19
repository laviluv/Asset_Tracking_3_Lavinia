using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking_3_Lavinia
{
    class Computers : Assets
    {
        public Computers(string brand, DateTime purchased, bool isdeprecated)
        {
            Brand = brand;
            Purchased = purchased;
            IsDeprecated = isdeprecated;
        }

        public override string ResourceType => "computers";
        public override string Brand { get => base.Brand; set => base.Brand = value; }
       // public override string Brand { get; set; }
        public override DateTime Purchased { get => base.Purchased; set => base.Purchased = value; }

        public override bool IsDeprecated { get => base.IsDeprecated; set => base.IsDeprecated = value; }

    }
}


