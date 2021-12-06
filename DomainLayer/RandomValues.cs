using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;

namespace DomainLayer
{
    public class RandomValues
    {
        static readonly Random RandomNumberGenerator = new();
        static public int RandomDiscountPercentage => RandomNumberGenerator.Next(98);
        static public int RandomDistance => RandomNumberGenerator.Next(949);
    }
}
