using System;
using DataLayer;
using DomainLayer;
using DataLayer.Entities;
using System.Collections.Generic;
using PresentationLayer.Enums;

namespace PresentationLayer
{
    class Program
    {
        static void Main()
        {
            bool exitAll = false;
            while (!exitAll)
            {
                var correctEntry = LoginMenu();
                if(correctEntry) exitAll = true;
            }
        }

        static public bool LoginMenu()
        {
            var exitMenu = false;
            while (true != exitMenu)
            {
                var choice = (LoginMenuChoice)LoginMenuOutput();

                switch (choice)
                {
                  case LoginMenuChoice.Login:
                        var builtComputer = new BuiltComputer() { };
                        var User = EnterBuyerInfo();
                        if (null == User)
                        {
                            return false;
                        }
                        Menus.Menu(User, builtComputer);
                        break;
                    case LoginMenuChoice.Exit:
                        return true;
                    default:
                        Console.Clear();
                        Console.WriteLine("Molimo unesite jedan od dopuštenih brojeva (0 ili 1)\n");
                        break;
                }
            }
            return true;
        }

        static public char LoginMenuOutput()
        {
            Console.WriteLine($"Odaberite akciju:\n" +
                "1 - Prijavi se u račun\n" +
                "0 - Izlaz iz aplikacije");

            char.TryParse(Console.ReadLine().Trim(), out char choice);

            return choice;
        }

        static Buyer PutUserIntoListOfCustomers(string _name, string _address)
        {
            var User = new Buyer(_name, _address, DomainLayer.RandomValues.RandomDistance + 50);

            if (null != ListOfCustomers.BuyerExists(_name, _address))
            {
                User = ListOfCustomers.BuyerExists(_name, _address);
            }
            else
            {
                ListOfCustomers.CustomersList.Add(User);
            }
            return User;
        }

        static string EnterInfo(NameOrAddress choice)
        {
            string entry;
            if(NameOrAddress.Name == choice) Console.Write("Unesite ime i prezime. ");
            else Console.Write("\nUnesite adresu. ");
            while (true)
            {
                Console.Write("Za odustajanje od upisa, unesite prazan unos:\n");
                entry = Console.ReadLine().Trim();
                ValidityOfString validity;
                if(NameOrAddress.Name == choice) validity = (ValidityOfString)ChecksAndVerifications.CheckIfEntryIsValid(entry, choice);
                else validity = (ValidityOfString)ChecksAndVerifications.CheckIfEntryIsValid(entry, choice);

                if (ValidityOfString.GiveUp == validity)
                {
                    Console.WriteLine("Odustali ste od prijave na račun.");
                    PopUps.ReturnToLoginMenu();
                    return null;
                }

                else if (ValidityOfString.Unvalid == validity)
                {
                    if (NameOrAddress.Name == choice) Console.Write("\nMolimo upišite ime i prezime ispočetka. ");
                    else Console.Write("\nMolimo upišite adresu ispočetka. ");
                }
                else return entry;
            }
        }

        static Buyer EnterBuyerInfo()
        {
            Console.Clear();
            var name = EnterInfo(NameOrAddress.Name);
            if(null == name)
            {
                return null;
            }

            var address = EnterInfo(NameOrAddress.Address);
            if (null == address)
            {
                return null;
            }

            var User = PutUserIntoListOfCustomers(name, address);

            Console.Clear();
            return User;
        }
    }
}
