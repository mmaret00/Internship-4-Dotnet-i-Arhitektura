using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;

namespace PresentationLayer
{
    class Outputs
    {
        static public void ShowComponentsOfBuiltComputer(BuiltComputer builtComputer)
        {
            if (null != builtComputer.processor)
                Console.WriteLine($"\nProcesor:\nMarka: {builtComputer.processor.Brand}\tBroj jezgri: {builtComputer.processor.NumberOfCores}");

            if (0 != builtComputer.RAM.Count)
            {
                Console.WriteLine("\nRAM kartice:");
                for (int i = 0; i < builtComputer.RAM.Count; i++)
                {
                    Console.Write($"{i + 1}. RAM kartica: {builtComputer.RAM[i].Capacity}\n");
                }
            }
            if (null != builtComputer.hardDisk)
                Console.WriteLine($"\nHard disk:\nVrsta: {builtComputer.hardDisk.Type}\tKapacitet: {builtComputer.hardDisk.Capacity}\tTežina: {builtComputer.hardDisk.Weight} kg\n");

            if (null != builtComputer.computerCase)
                Console.WriteLine($"Kućište:\nMaterijal: {builtComputer.computerCase.Material}\tTežina: {builtComputer.computerCase.Weight} kg\n");
        }

        static public void ShowPreviouslyRecievedBonusComponents(List<BonusComponents> bonusComponents)
        {
            foreach (var component in bonusComponents)
            {
                for (int i = 0; i < component.bonusProcessors.Count; i++)
                {
                    Console.WriteLine($"Procesor: {component.bonusProcessors[i].Brand}, broj jezgri: {component.bonusProcessors[i].NumberOfCores}");
                }
                for (int i = 0; i < component.bonusRAM.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. RAM kartica: {component.bonusRAM[i].Capacity}");
                }
                for (int i = 0; i < component.bonusHardDisk.Count; i++)
                {
                    Console.WriteLine($"Hard disk: {component.bonusHardDisk[i].Type}, {component.bonusHardDisk[i].Capacity}");
                }
                for (int i = 0; i < component.bonusComputerCase.Count; i++)
                {
                    Console.WriteLine($"Kućište: {component.bonusComputerCase[i].Material}");
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
                Console.WriteLine($"{++i}. Marka: {processor.Brand}\t\tBroj jezgri: {processor.NumberOfCores}\t\tCijena: {processor.Price} kn");
            }
            Console.WriteLine("\nZa povratak na izbor komponenti unesi 0 ili prazan unos.\n" +
                "Unesi broj procesora kojeg želiš:");
        }

        static public void RAMOutput(int i)
        {
            Console.Clear();
            if (i > 0)
            {
                Console.WriteLine($"Odabrali ste {i}. RAM karticu od mogućih 4. Nastavlja se izbor " +
                    $"idućih kartica.\n");
            }

            Console.WriteLine("Ponuđene RAM kartice:");
            var j = 0;
            foreach (var card in DataLayer.DataSeed.listOfAvailableRAMs)
            {
                Console.WriteLine($"{++j}. Kapacitet: {card.Capacity}\tCijena: {card.Price} kn");
            }
            Console.WriteLine("\nZa povratak na izbor komponenti unesi 0 ili prazan unos.\n" +
                "Unesi broj kartice koju želiš:");
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
            Console.WriteLine("\nZa povratak na izbor komponenti unesi 0 ili prazan unos.\n" +
                "Unesi broj hard diska kojeg želiš:");
        }

        static public void ComputerCasesOutput()
        {
            Console.Clear();
            Console.WriteLine("Ponuđena kućišta:\n");
            int i = 0;
            foreach (var Case in DataLayer.DataSeed.listOfAvailableComputerCases)
            {
                Console.WriteLine($"{++i}. Materijal: {Case.Material}\t\tTežina: {Case.Weight} kg\t\tCijena: {Case.Price} kn");
            }
            Console.WriteLine("\nZa povratak na izbor komponenti unesi 0 ili prazan unos." +
                "\nUnesi broj kućišta kojeg želiš:");
        }

        static public void ShowComponentsChosenSoFar(BuiltComputer builtComputer)
        {
            if (ChecksAndVerifications.CheckIfAnyComponentsAreChosen(builtComputer))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Složili ste računalo sa specifikacijama:");
                ShowComponentsOfBuiltComputer(builtComputer);
                Console.ResetColor();
                Console.WriteLine("\n========================================================\n");
            }
        }
        public static void PrintAComputer(BuiltComputer builtComputer)
        {
            Console.WriteLine($"\nProcesor: {builtComputer.processor.Brand}, broj jezgri: {builtComputer.processor.NumberOfCores}\t\t{builtComputer.processor.Price} kn");
            for (int i = 0; i < builtComputer.RAM.Count; i++)
            {
                Console.Write($"{i + 1}. RAM kartica: {builtComputer.RAM[i].Capacity}\t\t\t{builtComputer.RAM[i].Price} kn\n");
            }
            Console.WriteLine($"Hard disk: {builtComputer.hardDisk.Type}, {builtComputer.hardDisk.Capacity}, {builtComputer.hardDisk.Weight} kg\t\t{builtComputer.hardDisk.Price} kn");
            Console.WriteLine($"Kućište: {builtComputer.computerCase.Material}, {builtComputer.computerCase.Weight} kg\t\t{builtComputer.computerCase.Price} kn");
        }
    }
}
