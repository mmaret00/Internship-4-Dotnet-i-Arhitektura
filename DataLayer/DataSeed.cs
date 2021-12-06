using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Enums;

namespace DataLayer
{
    public class DataSeed
    {
        public static readonly List<Processor> listOfAvailableProcessors = new()
        {
            new Processor(_brand: ProcessorBrands.AMD, _numberOfCores: 10, _price: 499.99),
            new Processor(_brand: ProcessorBrands.AMD, _numberOfCores: 8, _price: 399.99),
            new Processor(_brand: ProcessorBrands.Intel, _numberOfCores: 8, _price: 349.99),
            new Processor(_brand: ProcessorBrands.Intel, _numberOfCores: 4, _price: 249.99),
        };

        public static readonly List<RAM> listOfAvailableRAMs = new()
        {
            new RAM(_capacity: "4GB", _price: 199.99),
            new RAM(_capacity: "8GB", _price: 349.99)
        };

        public static readonly List<HardDisk> listOfAvailableHardDisks = new()
        {
            new HardDisk(_type: HardDiskTypes.HDD, _capacity: "2TB", _weight: 2, _price: 799.99),
            new HardDisk(_type: HardDiskTypes.HDD, _capacity: "1TB", _weight: 1, _price: 599.99),
            new HardDisk(_type: HardDiskTypes.SSD, _capacity: "2TB", _weight: 0, _price: 899.99),
            new HardDisk(_type: HardDiskTypes.SSD, _capacity: "1TB", _weight: 0, _price: 799.99)
        };

        public static readonly List<ComputerCase> listOfAvailableComputerCases = new()
        {
            new ComputerCase(_material: ComputerCaseMaterials.Metalno, _weight: 1.5, _price: 299.99),
            new ComputerCase(_material: ComputerCaseMaterials.Plastično, _weight: 1, _price: 399.99),
            new ComputerCase(_material: ComputerCaseMaterials.Karbonsko, _weight: 0.5, _price: 499.99)
        };
    }
}
