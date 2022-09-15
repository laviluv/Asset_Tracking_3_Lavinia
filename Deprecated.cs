using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Tracking_3_Lavinia
{
    internal class Deprecated
    {

        public bool CheckDeprecated(DateTime purchaseTime)
        {
            DateTime CurrentTime = DateTime.Now;
            TimeSpan timeSpan = CurrentTime - purchaseTime;

            if (timeSpan.TotalDays > 1004)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
