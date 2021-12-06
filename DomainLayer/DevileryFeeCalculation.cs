using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DomainLayer
{
    public class DevileryFeeCalculation
    {
        static public double CalculateDeliveryCost(Buyer User, double totalWeight)
        {
            if (User.DeliverAtHome)
            {
                return CalculateShippingFee(User.Distance, totalWeight);
            }
            else return 0;
        }

        static double CalculateShippingFee(int distance, double weight)
        {
            if (3 > weight)
            {
                return (5 * ((double)distance / 10));
            }
            else if (3 < weight && 10 > weight)
            {
                return (3 * ((double)distance / 5));
            }
            else
            {
                return (50 + (10 * ((double)distance / 20)));
            }
        }
    }
}
