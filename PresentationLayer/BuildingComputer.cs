using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using PresentationLayer.Bill;
using PresentationLayer.Enums;

namespace PresentationLayer
{
    class BuildingComputer
    {
        static public BuiltComputer SaveBuiltComputerAndStartBuildingANewOne()
        {
            Console.Clear();
            Console.WriteLine("\nRačunalo koje ste odabrali je spremljeno, sada slažete novo računalo.");
            PopUps.ReturnToBuildingWithoutChoosing();
            return new BuiltComputer();
        }

        static public BuiltComputer BuildAComputer(Buyer User, BuiltComputer builtComputer)
        {
            Console.Clear();
            while (true)
            {
                Outputs.ShowComponentsChosenSoFar(builtComputer);
                var choice = (BuildComputerChoice)Menus.BuildAComputerMenu(builtComputer);
                switch (choice)
                {
                    case BuildComputerChoice.Processor:
                        ChooseProcessor(builtComputer);
                        break;
                    case BuildComputerChoice.RAM:
                        ChooseRAM(builtComputer);
                        break;
                    case BuildComputerChoice.HardDisk:
                        ChooseHardDisk(builtComputer);
                        break;
                    case BuildComputerChoice.ComputerCase:
                        ChooseCase(builtComputer);
                        break;
                    case BuildComputerChoice.BuildNewComputer:
                        if (ChecksAndVerifications.CheckIfAllComponentsAreChosen(builtComputer))
                        {
                            User.currentlyBuiltComputers.Add(builtComputer);
                            builtComputer = SaveBuiltComputerAndStartBuildingANewOne();
                        }
                        break;
                    case BuildComputerChoice.Checkout:
                        if (ChecksAndVerifications.CheckIfAllComponentsAreChosen(builtComputer))
                        {
                            return Checkout(builtComputer, User);
                        }
                        break;
                    case BuildComputerChoice.GiveUp:
                        Console.Clear();
                        if (ChecksAndVerifications.ConfirmGivingUpOnBuildingAComputer())
                        {
                            builtComputer = new BuiltComputer();
                            return builtComputer;
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Molimo unesite jedan od dopuštenih brojeva (0-6)\n");
                        break;
                }
            }
        }

        static void ChooseProcessor(BuiltComputer builtComputer)
        {
            while (true)
            {
                Outputs.ProcessorOutput();
                int.TryParse(Console.ReadLine().Trim(), out int choice);

                if (0 == choice)
                {
                    PopUps.ReturnToBuildingWithoutChoosing();
                    return;
                }
                if (choice >= 1 && choice <= DataLayer.DataSeed.listOfAvailableProcessors.Count)
                {
                    PopUps.ReturnToBuilding();
                    builtComputer._processor = DataLayer.DataSeed.listOfAvailableProcessors[choice - 1];
                    return;
                }
                PopUps.UserEnteredUnacceptableChoice();
            }
        }

        static void ChooseRAM(BuiltComputer builtComputer)
        {
            var chosenRAMList = new List<RAM>() { };
            for (int i = 0; i < 4; i++)
            {
                Outputs.RAMOutput(i);

                int.TryParse(Console.ReadLine().Trim(), out int choice);
                if (0 == choice) break;

                if (choice < 1 || choice > DataLayer.DataSeed.listOfAvailableRAMs.Count)
                {
                    PopUps.UserEnteredUnacceptableChoice();
                    i--;
                    continue;
                }

                if(0 == i)
                {
                    builtComputer._RAM.Clear();
                }
                    
                chosenRAMList.Add(DataLayer.DataSeed.listOfAvailableRAMs[choice - 1]);
                builtComputer._RAM.Add(chosenRAMList[i]);
                if (3 == i) break;
            }
            PopUps.ReturnToBuilding();
        }

        static void ChooseHardDisk(BuiltComputer builtComputer)
        {
            while (true)
            {
                Outputs.HardDiskOutput();
                int.TryParse(Console.ReadLine().Trim(), out int choice);

                if (0 == choice)
                {
                    PopUps.ReturnToBuildingWithoutChoosing();
                    return;
                }
                if (choice >= 1 && choice <= DataLayer.DataSeed.listOfAvailableHardDisks.Count)
                {
                    PopUps.ReturnToBuilding();
                    builtComputer._hardDisk = DataLayer.DataSeed.listOfAvailableHardDisks[choice - 1];
                    return;
                }
                PopUps.UserEnteredUnacceptableChoice();
            }
        }

        static void ChooseCase(BuiltComputer builtComputer)
        {
            while (true)
            {
                Outputs.ComputerCasesOutput();
                int.TryParse(Console.ReadLine().Trim(), out int choice);

                if (0 == choice)
                {
                    PopUps.ReturnToBuildingWithoutChoosing();
                    return;
                }
                if (choice >= 1 && choice <= DataLayer.DataSeed.listOfAvailableComputerCases.Count)
                {
                    PopUps.ReturnToBuilding();
                    builtComputer._computerCase = DataLayer.DataSeed.listOfAvailableComputerCases[choice - 1];
                    return;
                }
                PopUps.UserEnteredUnacceptableChoice();
            }
        }

        static BuiltComputer Checkout(BuiltComputer builtComputer, Buyer User)
        {
            Console.WriteLine("Slijedi obračun.");
            PopUps.ClickAnyKeyToContinue();

            if (Menus.DeliveryOrPickup(User))
            {
                User.currentlyBuiltComputers.Add(builtComputer);
                return Bill.Bill.PrintBill(builtComputer, User);
            }
            else
            {
                PopUps.UserGaveUpOnBuiltPC();
                return new BuiltComputer();
            }
        }
    }
}
