using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class Processor : Component
    {

        public int _numberOfCores;
        public int NumberOfCores { get; set; }

        public ProcessorBrands Brand;

        public Processor(ProcessorBrands _brand, int _numberOfCores, double _price)
        {
            Brand = _brand;
            NumberOfCores = _numberOfCores;
            Weight = 0;
            Price = _price;
        }
    }
}
