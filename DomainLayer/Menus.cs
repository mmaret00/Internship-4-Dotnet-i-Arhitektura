using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;

namespace DomainLayer
{
    public class Menus
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
        {//ovo u neki drugi class
            Console.Clear();
            builtComputer = BuildAComputer(User, builtComputer);
            if (null == builtComputer)
            {
                //builtComputer = new List<(Processor, List<RAM>, HardDisk, ComputerCase)>() { };
            }
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
                    Console.WriteLine($"{i+1}. kupljeno računalo:");
                    Outputs.ShowComponentsOfBuiltComputer(User.previouslyBoughtComputers[i]);
                    if (0 == User.previouslyBoughtComputers[i]._bonusComponents.Count) continue;
                    Console.WriteLine("Bonus komponente dobivene uz tu narudžbu:");
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
                var choice = MenuOutput(User);

                switch (choice)
                {
                    case '1':
                        builtComputer = SendListWithBuiltComputers(User, builtComputer);
                        break;
                    case '2':
                        ShowPreviouslyBoughtComputers(User);
                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine("\nOdjavili ste se s računa.");
                        PopUps.ReturnToMenu();
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
                var choice = DeliveryOrPickupMenu();

                switch (choice)
                {
                    case '1':
                        User.DeliverAtHome = false;
                        return true;
                    case '2':
                        User.DeliverAtHome = true;
                        return true;
                    case '0':
                        return false;
                    default:
                        Console.Clear();
                        Console.WriteLine("Molimo unesite jedan od dopuštenih brojeva (0-2)\n");
                        break;
                }
            }
        }

        static public int CheckoutOrBuildANewComputer()
        {
            Console.Clear();
            while (true)
            {
                var choice = CheckoutOrBuildANewComputerMenu();
                switch (choice)
                {
                    case '1':
                        return 1;
                    case '2':
                        break;
                    case '3':
                        return 0;
                    case '4':
                        Console.Clear();
                        return 2;
                    case '0':
                        return 0;
                    default:
                        Console.Clear();
                        Console.WriteLine("Molimo unesite jedan od dopuštenih brojeva (0-4)\n");
                        break;
                }
            }
        }

        static char CheckoutOrBuildANewComputerMenu()
        {
            Console.WriteLine("Složili ste računalo. Želite li:\n" +
               "1 - Vidjeti račun\n" +
               "2 - Vidjeti komponete koje ste odabrali\n" +
               "3 - Promijeniti neke komponente računala\n" +
               "4 - Složiti novo računalo\n" +
               "0 - Odustati od narudžbe?");

            char.TryParse(Console.ReadLine().Trim(), out char choice);

            return choice;
        }

        static public char BuildAComputerMenu()
        {
            Console.WriteLine("Unesi koju komponentu želiš odabrati:\n" +
               "1 - Procesor\n" +
               "2 - RAM\n" +
               "3 - Hard disk\n" +
               "4 - Kućište\n\n" +
               "5 - Slaganje novog računala\n" +
               "6 - Obračun\n" +
               "7 - Pregled dosad odabranih komponenti\n" +
               "0 - Odustajanje i povratak na glavni izbornik");

            char.TryParse(Console.ReadLine().Trim(), out char choice);

            return choice;
        }
    }
}
