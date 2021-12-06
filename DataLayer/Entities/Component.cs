using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Component
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private double _weight;
        public double Weight { get => _weight; set => _weight = value; }

        private double _price;
        public double Price { get => _price; set => _price = value; }
    }
}
