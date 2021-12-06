using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Component
    {
        private double weight;
        public double Weight { get => weight; set => weight = value; }

        private double price;
        public double Price { get => price; set => price = value; }
    }
}
