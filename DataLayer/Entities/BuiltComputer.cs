using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Entities
{
    public class BuiltComputer
    {
        public Processor processor;
        public List<RAM> RAM;
        public HardDisk hardDisk;
        public ComputerCase computerCase;
        public List<BonusComponents> bonusComponents;

        public BuiltComputer()
        {
            processor = null;
            RAM = new List<RAM>() { };
            hardDisk = null;
            computerCase = null;
            bonusComponents = new();
        }
    }
}
