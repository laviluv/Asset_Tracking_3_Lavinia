using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking_3_Lavinia
{
    internal class OtherAssets : Assets
    {
        public OtherAssets(string resourcetype, string brand, DateTime purchased, bool isdeprecated)
        {
            ResourceType = resourcetype;
            Brand = brand;
            Purchased = purchased;
            IsDeprecated = isdeprecated;
        }

        public override string ResourceType { get; set; }

        // public string Brand { get; set; }
        public override string Brand { get => base.Brand; set => base.Brand = value; }

        public override DateTime Purchased { get; set; }

        public override bool IsDeprecated { get; set; }


    }
}

