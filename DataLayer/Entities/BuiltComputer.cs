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
        public Processor _processor;
        public List<RAM> _RAM;
        public HardDisk _hardDisk;
        public ComputerCase _computerCase;
        public List<BonusComponents> _bonusComponents;

        public BuiltComputer()
        {
            _processor = null;
            _RAM = new List<RAM>() { };
            _hardDisk = null;
            _computerCase = null;
            _bonusComponents = new();
        }
    }
}
