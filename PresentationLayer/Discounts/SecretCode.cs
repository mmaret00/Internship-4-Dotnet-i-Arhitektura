using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace PresentationLayer.Discounts
{
    public class SecretCode
    {
        static public bool RepeatingDiscountCodeEntering()
        {
            Console.WriteLine("Unijeli ste pogrešan kod, želite li ponoviti unos?");
            if (ChecksAndVerifications.ConfimationCheck()) return true;
            return false;
        }

        static public double CheckIfCodeExists(string discountCodeUserEntered)
        {
            foreach (var code in DomainLayer.SetDiscountCodes.listOfSecretCodes)
            {
                if (code.Code == discountCodeUserEntered)
                {
                    Console.WriteLine("Uspješno ste unijeli validan kod. " +
                        $"Odobren vam je popust od {code.DiscountPercentage}%.");
                    DomainLayer.SetDiscountCodes.listOfSecretCodes.Remove(code);
                    return (double)code.DiscountPercentage / 100;
                }
            }
            return 0;
        }

        static public double UserHasADiscountCode()
        {
            var correctEntry = false;
            while (false == correctEntry)
            {
                Console.WriteLine("Unesite kod za popust:");
                var discountCodeUserEntered = Console.ReadLine().Trim();

                var discountPercentage = CheckIfCodeExists(discountCodeUserEntered);
                if (0 != discountPercentage) return discountPercentage;
                
                var choiceForReenteringCode = RepeatingDiscountCodeEntering();
                if (false == choiceForReenteringCode) return 0;
            }
            return 0;
        }

        static public double CheckIfUserHasADiscountCode()
        {
            Console.Clear();
            Console.WriteLine("Imate li kod za popust?");
            if (ChecksAndVerifications.ConfimationCheck())
            {
                var valueToReturn = UserHasADiscountCode();
                return valueToReturn;
            }
            else return 0;
        }
    }
}
