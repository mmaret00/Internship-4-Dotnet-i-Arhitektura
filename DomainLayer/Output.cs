using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;

namespace DomainLayer
{
    public class Outputs//ovo bi valjda tribalo nekako stavit u presentation
    {/*
        static public void ShowComponentsOfBuiltComputer(BuiltComputer builtComputer)
        {
            Console.WriteLine("Složili ste računalo sa specifikacijama:");
            if (null != builtComputer._processor)
                Console.WriteLine($"\nProcesor:\nMarka: {builtComputer._processor.Brand}\tBroj jezgri: {builtComputer._processor.NumberOfCores}");

            if (null != builtComputer._RAM)
            {
                Console.WriteLine("\nRAM kartice:");
                for (int i = 0; i < builtComputer._RAM.Count; i++)
                {
                    Console.Write($"{i + 1}. RAM kartica: {builtComputer._RAM[i].Capacity}\n");
                }
            }
            if (null != builtComputer._hardDisk)
                Console.WriteLine($"\nHard disk:\nVrsta: {builtComputer._hardDisk.Type}\tKapacitet: {builtComputer._hardDisk.Capacity}\tTežina: {builtComputer._hardDisk.Weight} kg\n");

            if (null != builtComputer._computerCase)
                Console.WriteLine($"\nKućište:\nMaterijal: {builtComputer._computerCase.Material}\tTežina: {builtComputer._computerCase.Weight} kg\n");
        }

        static public void ShowPreviouslyRecievedBonusComponents(List<BonusComponents> bonusComponents)
        {
            foreach (var component in bonusComponents)
            {
                for (int i = 0; i < component.bonusProcessors.Count; i++)
                {
                    Console.WriteLine($"\nProcesor:\nMarka: {component.bonusProcessors[i].Brand}\tBroj jezgri: {component.bonusProcessors[i].NumberOfCores}");
                }
                for (int i = 0; i < component.bonusRAM.Count; i++)
                {
                    Console.Write($"{i+1}. RAM kartica: {component.bonusRAM[i].Capacity}\n");
                }
                for (int i = 0; i < component.bonusHardDisk.Count; i++)
                {
                    Console.WriteLine($"\nHard disk:\nVrsta: {component.bonusHardDisk[i].Type}\tKapacitet: {component.bonusHardDisk[i].Capacity}\n");
                }
                for (int i = 0; i < component.bonusComputerCase.Count; i++)
                {
                    Console.WriteLine($"\nKućište:\nMaterijal: {component.bonusComputerCase[i].Material}\n");
                }
            }
        }

        static public void ProcessorOutput()
        {
            Console.Clear();
            Console.WriteLine("Ponuđeni procesori:\n");
            var i = 0;
            foreach (var processor in DataLayer.DataSeed.listOfAvailableProcessors)
            {
                Console.WriteLine($"{++i}. Marka: {processor.Brand}\tBroj jezgri: {processor.NumberOfCores}\tCijena: {processor.Price} kn");
            }
            Console.WriteLine("\nUnesi broj procesora kojeg želiš:");
        }

        static public void RAMOutput()
        {
            Console.Clear();
            Console.WriteLine("Ponuđene RAM kartice:");
            var i = 0;
            foreach (var card in DataLayer.DataSeed.listOfAvailableRAMs)
            {
                Console.WriteLine($"{++i}. Kapacitet: {card.Capacity}\tCijena: {card.Price} kn");
            }
            Console.WriteLine("\nUnesi broj kartice koju želiš:");
        }

        static public void HardDiskOutput()
        {
            Console.Clear();
            Console.WriteLine("Ponuđeni hard diskovi:\n");
            var i = 0;
            foreach (var Disk in DataLayer.DataSeed.listOfAvailableHardDisks)
            {
                Console.WriteLine($"{++i}. Vrsta: {Disk.Type}\tMemorija: {Disk.Capacity}\tTežina: {Disk.Weight} kg\tCijena: {Disk.Price} kn");
            }
            Console.WriteLine("\nUnesi broj hard diska kojeg želiš:");
        }

        static public void ComputerCasesOutput()
        {
            Console.Clear();
            Console.WriteLine("Ponuđena kućišta:\n");
            int i = 0;
            foreach (var Case in DataLayer.DataSeed.listOfAvailableComputerCases)
            {
                Console.WriteLine($"{++i}. Materijal: {Case.Material}\tTežina: {Case.Weight} kg\tCijena: {Case.Price} kn");
            }
            Console.WriteLine("\nUnesi broj kućišta kojeg želiš:");
        }*/
    }
}
