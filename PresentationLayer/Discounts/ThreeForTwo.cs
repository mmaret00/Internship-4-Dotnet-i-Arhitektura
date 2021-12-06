using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;

namespace PresentationLayer.Discounts
{
    class ThreeForTwo
    {
        static public void ThreeForTwoDiscountProcessors(Buyer User, BonusComponents bonus)
        {
            var boughtProcessors = new Dictionary<Processor, int>();

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                if (boughtProcessors.ContainsKey(User.currentlyBuiltComputers[i]._processor))
                {
                    boughtProcessors[User.currentlyBuiltComputers[i]._processor]++;
                }
                else
                {
                    boughtProcessors.Add(User.currentlyBuiltComputers[i]._processor, 1);
                }
            }
            ThreeForTwoDiscountProcessorsPrint(boughtProcessors, bonus);
        }

        static public void ThreeForTwoDiscountProcessorsPrint(Dictionary<Processor, int> boughtProcessors, BonusComponents bonus)
        {
            foreach (var processor in boughtProcessors)
            {
                if (processor.Value / 2 <= 0) continue;
                Console.WriteLine($"Kupili ste {processor.Value} procesora {processor.Key.Brand} " +
                    $"s {processor.Key.NumberOfCores} jezgri, " +
                    $"pa imate mogućnost dobiti {processor.Value / 2} istih procesora besplatno. " +
                    $"Želite li iskoristiti tu ponudu?");
                if (!ChecksAndVerifications.ConfimationCheck()) continue;
                bonus.bonusProcessors.Add(processor.Key);
            }
        }

        static public void ThreeForTwoDiscountRAM(Buyer User, BonusComponents bonus)
        {
            var boughtRAM = new Dictionary<RAM, int>();

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                for (int j = 0; j < User.currentlyBuiltComputers[i]._RAM.Count; j++)
                {
                    if (boughtRAM.ContainsKey(User.currentlyBuiltComputers[i]._RAM[j]))
                    {
                        boughtRAM[User.currentlyBuiltComputers[i]._RAM[j]]++;
                    }
                    else
                    {
                        boughtRAM.Add(User.currentlyBuiltComputers[i]._RAM[j], 1);
                    }
                }
            }
            ThreeForTwoDiscountRAMPrint(boughtRAM, bonus);
        }

        static public void ThreeForTwoDiscountRAMPrint(Dictionary<RAM, int> boughtRAM, BonusComponents bonus)
        {
            foreach (var card in boughtRAM)
            {
                if (card.Value / 2 <= 0) continue;

                Console.WriteLine($"Kupili ste {card.Value} RAM kartica od {card.Key.Capacity} TB, " +
                    $"pa imate mogućnost dobiti {card.Value / 2} istih RAM kartica besplatno. " +
                    $"Želite li iskoristiti tu ponudu?");
                if (!ChecksAndVerifications.ConfimationCheck()) continue;
                bonus.bonusRAM.Add(card.Key);
            }
        }

        static public void ThreeForTwoDiscountHardDisks(Buyer User, BonusComponents bonus)
        {
            var boughtHardDisks = new Dictionary<HardDisk, int>();

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                if (boughtHardDisks.ContainsKey(User.currentlyBuiltComputers[i]._hardDisk))
                {
                    boughtHardDisks[User.currentlyBuiltComputers[i]._hardDisk]++;
                }
                else
                {
                    boughtHardDisks.Add(User.currentlyBuiltComputers[i]._hardDisk, 1);
                }
            }
            ThreeForTwoDiscountHardDisksPrint(boughtHardDisks, bonus);
        }

        static public void ThreeForTwoDiscountHardDisksPrint(Dictionary<HardDisk, int> boughtHardDisks, BonusComponents bonus)
        {
            foreach (var disk in boughtHardDisks)
            {
                if (disk.Value / 2 <= 0) continue;
                
                Console.WriteLine($"Kupili ste {disk.Value} hard diskova {disk.Key.Type} " +
                    $"s {disk.Key.Capacity}, " +
                    $"pa imate mogućnost dobiti {disk.Value / 2} istih hard diskova besplatno. " +
                    $"Želite li iskoristiti tu ponudu?");
                if (!ChecksAndVerifications.ConfimationCheck()) continue;
                bonus.bonusHardDisk.Add(disk.Key);
                
            }
        }

        static public void ThreeForTwoDiscountComputerCases(Buyer User, BonusComponents bonus)
        {
            var boughtComputerCases = new Dictionary<ComputerCase, int>();

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                if (boughtComputerCases.ContainsKey(User.currentlyBuiltComputers[i]._computerCase))
                {
                    boughtComputerCases[User.currentlyBuiltComputers[i]._computerCase]++;
                }
                else
                {
                    boughtComputerCases.Add(User.currentlyBuiltComputers[i]._computerCase, 1);
                }
            }
            ThreeForTwoDiscountComputerCasesPrint(boughtComputerCases, bonus);
        }

        static public void ThreeForTwoDiscountComputerCasesPrint(Dictionary<ComputerCase, int> boughtComputerCases, BonusComponents bonus)
        {
            foreach (var Case in boughtComputerCases)
            {
                if (Case.Value / 2 <= 0) continue;
                Console.WriteLine($"Kupili ste {Case.Key.Material} kućište {Case.Value} puta, " +
                    $"pa imate mogućnost dobiti {Case.Value / 2} istih kućišta besplatno. " +
                    $"Želite li iskoristiti tu ponudu?");
                if (!ChecksAndVerifications.ConfimationCheck()) continue;
                    bonus.bonusComputerCase.Add(Case.Key);
            }
        }

        static public BonusComponents ThreeForTwoDiscount(Buyer User)
        {
            var bonus = new BonusComponents();

            ThreeForTwoDiscountProcessors(User, bonus);
            ThreeForTwoDiscountHardDisks(User, bonus);
            ThreeForTwoDiscountComputerCases(User, bonus);
            ThreeForTwoDiscountRAM(User, bonus);

            return bonus;
        }
    }
}
