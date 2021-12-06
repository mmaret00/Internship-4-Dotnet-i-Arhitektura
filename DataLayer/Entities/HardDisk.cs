using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class HardDisk : Component
    {
        public HardDiskTypes Type;
        public string Capacity;

        public HardDisk(HardDiskTypes _type, string _capacity, double _weight, double _price)
        {
            Type = _type;
            Capacity = _capacity;
            Weight = _weight;
            Price = _price;
        }
    }
}
