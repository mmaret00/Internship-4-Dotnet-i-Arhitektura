using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class DiscountCode
    {
        public string Code;

        public int DiscountPercentage;
        public DiscountCode(string _code, int _discountPercentage)
        {
            Code = _code;
            DiscountPercentage = _discountPercentage;
        }

    }
}
