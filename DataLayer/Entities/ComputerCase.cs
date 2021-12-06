using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class ComputerCase : Component
    {
        public ComputerCaseMaterials Material;
        public ComputerCase(ComputerCaseMaterials _material, double _weight, double _price)
        {
            Material = _material;
            Weight = _weight;
            Price = _price;
        }
    }
}
