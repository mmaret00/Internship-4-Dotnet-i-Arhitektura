using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class RAM : Component
    {
        public string Capacity;
    
        public RAM(string _capacity, double _price)
        {
            Capacity = _capacity;
            Weight = 0;
            Price = _price;
        }
    }
}
