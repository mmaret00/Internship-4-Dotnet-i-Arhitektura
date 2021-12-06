using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using PresentationLayer.Enums;

namespace PresentationLayer
{
    class Menus
    {
        static public void MessageWhenComputerIsNotBuilt()
        {
            Console.Clear();
            Console.WriteLine("Niste složili računalo! Povratak na slaganje.");
            PopUps.ReturnToMenu();
        }
        static public char MenuOutput(Buyer User)
        {
            Console.WriteLine($"Ime: {User.Name}\nAdresa: {User.Address}\n\n" +
                "Odaberite akciju:\n" +
                "1 - Sastavi i naruči novo računalo\n" +
                "2 - Prikaži moje narudžbe\n" +
                "0 - Odjavi se");

            char.TryParse(Console.ReadLine().Trim(), out char choice);

            return choice;
        }

        static public BuiltComputer SendListWithBuiltComputers(Buyer User, BuiltComputer builtComputer)
        {
            Console.Clear();
            builtComputer = BuildingComputer.BuildAComputer(User, builtComputer);
            return builtComputer;
        }

        static public void ShowPreviouslyBoughtComputers(Buyer User)
        {
            Console.Clear();
            if (0 == User.previouslyBoughtComputers.Count)
            {
                Console.WriteLine("Dosad niste kupili niti jedno računalo!");
            }
            else
            {
                Console.WriteLine("Prethodno kupljena računala:");
                for (int i = 0; i < User.previouslyBoughtComputers.Count; i++)
                {
                    Console.WriteLine("\n========================================================\n");
                    Console.WriteLine($"{i + 1}. kupljeno računalo:");
                    Outputs.PrintAComputer(User.previouslyBoughtComputers[i]);
                    if (0 == User.previouslyBoughtComputers[i]._bonusComponents.Count) continue;
                    Console.WriteLine("\nBonus komponente dobivene uz tu narudžbu:");
                    Outputs.ShowPreviouslyRecievedBonusComponents(User.previouslyBoughtComputers[i]._bonusComponents);
                }
            }
            PopUps.ReturnToMenu();
        }

        static public void Menu(Buyer User, BuiltComputer builtComputer)
        {
            var exitMenu = false;
            while (true != exitMenu)
            {
                var choice = (MainMenuChoice)MenuOutput(User);

                switch (choice)
                {
                    case MainMenuChoice.Build:
                        builtComputer = SendListWithBuiltComputers(User, builtComputer);
                        break;
                    case MainMenuChoice.ShowOrders:
                        ShowPreviouslyBoughtComputers(User);
                        break;
                    case MainMenuChoice.LogOut:
                        Console.Clear();
                        Console.WriteLine("Odjavili ste se s računa.");
                        PopUps.ReturnToLoginMenu();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Molimo unesite jedan od dopuštenih brojeva (0-2)\n");
                        break;
                }
            }
        }

        static public char DeliveryOrPickupMenu()
        {
            Console.WriteLine("Želite li:\n" +
                    "1 - Osobno preuzeti paket (besplatno),\n" +
                    "2 - Da vam se paket dostavi na adresu (plaća se ovisno o kilaži i udaljenosti),\n" +
                    "0 - Odustati od kupnje?\n" +
                    "Unesite broj:");

            char.TryParse(Console.ReadLine().Trim(), out char choice);

            return choice;
        }

        static public bool DeliveryOrPickup(Buyer User)
        {
            Console.Clear();
            while (true)
            {
                var choice = (DeliveryOrPickupChoice)DeliveryOrPickupMenu();

                switch (choice)
                {
                    case DeliveryOrPickupChoice.Pickup:
                        User.DeliverAtHome = false;
                        return true;
                    case DeliveryOrPickupChoice.Devilery:
                        User.DeliverAtHome = true;
                        return true;
                    case DeliveryOrPickupChoice.GiveUp:
                        return false;
                    default:
                        Console.Clear();
                        Console.WriteLine("Molimo unesite jedan od dopuštenih brojeva (0-2)\n");
                        break;
                }
            }
        }

        static public bool ChangeColorOfComponentOptions(string option, bool chosen)
        {
            if(chosen)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(option);
            Console.ResetColor();

            return false;
        }

        static public void PrintComponentOptions(BuiltComputer builtComputer)
        {
            var chosen = false;

            if (null != builtComputer._processor) chosen = true;
            chosen = ChangeColorOfComponentOptions("1 - Procesor", chosen);

            if (0 != builtComputer._RAM.Count) chosen = true;
            chosen = ChangeColorOfComponentOptions("2 - RAM", chosen);

            if (null != builtComputer._hardDisk) chosen = true;
            chosen = ChangeColorOfComponentOptions("3 - Hard disk", chosen);

            if (null != builtComputer._computerCase) chosen = true;
                     ChangeColorOfComponentOptions("4 - Kućište\n", chosen);
        }

        static public void PrintAdditionalOptions()
        {
            Console.WriteLine("Dodatno:\n" +
               "5 - Slaganje novog računala\n" +
               "6 - Obračun\n" +
               "0 - Odustajanje i povratak na glavni izbornik" +
               "\n\nUnesite izbor:");
        }

        static public char BuildAComputerMenu(BuiltComputer builtComputer)
        {
            Console.WriteLine("Zelenom bojom će biti obojane komponente koje su odabrane, a crvenom " +
                "koje nisu. Da bi promijenili odabrane komponente samo odaberite nove.");
            Console.WriteLine("\nKomponente:");

            PrintComponentOptions(builtComputer);
            PrintAdditionalOptions();

            char.TryParse(Console.ReadLine().Trim(), out char choice);

            return choice;
        }
    }
}
