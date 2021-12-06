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
            new DiscountCode(_code: "kodtjsifra", _discountPercentage: RandomValues.RandomDiscountPercentage + 1),
            new DiscountCode(_code: "drugasifra", _discountPercentage: RandomValues.RandomDiscountPercentage + 1),
            new DiscountCode(_code: "qweqweqweq", _discountPercentage: RandomValues.RandomDiscountPercentage + 1)
        };
    }
}
