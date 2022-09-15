using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking_3_Lavinia
{
    class CellPhones : Assets
    {
        public CellPhones(string cellType, string brand, DateTime purchased, bool isdeprecated)
        {
            CellType = cellType;
            Brand = brand;
            Purchased = purchased;
            IsDeprecated = isdeprecated;
        }

        public override string ResourceType => "cellphones";
        public string CellType { get; set; }
        public string Brand { get; set; }

        public override DateTime Purchased { get => base.Purchased; set => base.Purchased = value; }
        public override bool IsDeprecated { get => base.IsDeprecated; set => base.IsDeprecated = value; }

    }
}
