using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking_3_Lavinia
{
    internal class OtherAssets : Assets
    {
        public OtherAssets(string type, string assetClass, string brand, DateTime purchased, bool isdeprecated)
        {
            ResourceType = type;
            AssetClass = assetClass;
            Brand = brand;
            Purchased = purchased;
            IsDeprecated = isdeprecated;
        }

        public override string ResourceType { get; set; }

        public string AssetClass { get; set; }

        public string Brand { get; set; }

        public override DateTime Purchased { get; set; }

        public override bool IsDeprecated { get; set; }


    }
}

