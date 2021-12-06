using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DomainLayer
{
    public class SetDiscountCodes
    {
        public static readonly List<DiscountCode> listOfSecretCodes = new()
        {
            new DiscountCode(code: "kodtjsifra", discountPercentage: RandomValues.RandomDiscountPercentage + 1),
            new DiscountCode(code: "drugasifra", discountPercentage: RandomValues.RandomDiscountPercentage + 1),
            new DiscountCode(code: "qweqweqweq", discountPercentage: RandomValues.RandomDiscountPercentage + 1)
        };
    }
}
