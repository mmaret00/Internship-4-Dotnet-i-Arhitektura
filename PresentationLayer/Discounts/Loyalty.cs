using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace PresentationLayer.Discounts
{
    class Loyalty
    {
        static public bool CheckIfUserHasALoyaltyDiscount(Buyer User)
        {
            if (true == User.LoyalCustomerDiscount)
            {
                Console.WriteLine("\nBudući da ste ranije potrošili preko 1000 kn, " +
                "imate priliku za popust od 100 kn. Želite li ga iskoristiti u " +
                "ovoj kupnji?:");

                var returnValue = (true == ChecksAndVerifications.ConfimationCheck());
                return returnValue;
            }
            return false;
        }
    }
}
