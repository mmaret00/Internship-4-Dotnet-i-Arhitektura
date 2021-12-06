using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class BonusComponents
    {
        public List<Processor> bonusProcessors = new();
        public List<RAM> bonusRAM = new();
        public List<HardDisk> bonusHardDisk = new();
        public List<ComputerCase> bonusComputerCase = new();
    }
}
