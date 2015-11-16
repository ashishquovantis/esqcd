using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Infrastructure.Util
{
   public static class Util
    {
        public static int parseInt(String val, int defValue)
        {
            if (val == null)
                return defValue;

            int newVal = 0;
            try
            {
                newVal = int.Parse(val);
            }
            catch (Exception)
            {
                return defValue;
            }

            return newVal;
        }
    }
}
