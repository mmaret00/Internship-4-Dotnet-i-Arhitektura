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
    class ChecksAndVerifications
    {
        static public ValidityOfString CheckIfEntryIsValid(string entry, NameOrAddress choice)
        {
            if (CheckIfStringIsEmpty(entry))
            {
                return ValidityOfString.GiveUp;
            }
            if(NameOrAddress.Name == choice)
                if (CheckIfNameIsLettersOnly(entry) && CheckIfStringHasSpaces(entry, NameOrAddress.Name) && CheckIfStringIsAtLeastFiveLettersLong(entry))
                {
                    return ValidityOfString.Valid;
                }
            if(NameOrAddress.Address == choice)
                if (CheckIfAddressIsLettersAndNumbersOnly(entry) && CheckIfStringHasSpaces(entry, NameOrAddress.Address) && CheckIfStringIsAtLeastFiveLettersLong(entry))
                {
                    return ValidityOfString.Valid;
                }
            return ValidityOfString.Unvalid;
        }

        static bool CheckIfStringIsEmpty(string name)
        {
            if (0 == name.Length)
            {
                return true;
            }
            return false;
        }

        static bool CheckIfNameIsLettersOnly(string name)
        {
            if (!NameLettersCheck(name))
            {
                Console.WriteLine("\nIme treba sadržavati samo slova i razmake!");
                return false;
            }
            return true;
        }

        static bool CheckIfStringHasSpaces(string entry, NameOrAddress choice)
        {
            if (!entry.Any(Char.IsWhiteSpace))
            {
                if(NameOrAddress.Name == choice)
                    Console.WriteLine("\nTrebate upisati i ime i prezime!");
                else
                    Console.WriteLine("Adresa treba sadržavati ulicu i kućni broj!");

                return false;
            }
            return true;
        }

        static bool CheckIfStringIsAtLeastFiveLettersLong(string entry)
        {
            if (entry.Length < 5)
            {
                Console.WriteLine("Unos treba sadržavati barem pet znakova!");
                return false;
            }
            return true;
        }

        static bool CheckIfAddressIsLettersAndNumbersOnly(string address)
        {
            if (!AddressLettersAndNumbersCheck(address))
            {
                Console.WriteLine("Adresa treba sadržavati samo slova, brojeve i razmake!");
                return false;
            }
            return true;
        }

        static bool NameLettersCheck(string name)
        {
            foreach (var letter in name)
            {
                if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                {
                    return false;
                }
            }
            return true;
        }

        static bool AddressLettersAndNumbersCheck(string address)
        {
            foreach (var letter in address)
            {
                if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter) && !char.IsNumber(letter))
                {
                    return false;
                }
            }
            return true;
        }

        static public bool ConfimationCheck()
        {
            while (true)
            {
                Console.WriteLine("Molimo unesite 'da' ili 'ne':");
                var choice = Console.ReadLine().Trim().ToUpper();

                if ("DA" == choice) return true;
                else if ("NE" == choice) return false;
                else Console.WriteLine("Nedopušten unos.");
            }
        }

        static public bool CheckIfAllComponentsAreChosen(BuiltComputer builtComputer)
        {
            if (null == builtComputer._processor || null == builtComputer._RAM || null == builtComputer._hardDisk || null == builtComputer._computerCase)
            {
                Menus.MessageWhenComputerIsNotBuilt();
                return false;
            }
            else return true;
        }

        static public bool CheckIfAnyComponentsAreChosen(BuiltComputer builtComputer)
        {
            if (null == builtComputer._processor && 0 == builtComputer._RAM.Count && null == builtComputer._hardDisk && null == builtComputer._computerCase)
            {
                return false;
            }
            return true;
        }

        static public bool ConfirmGivingUpOnBuildingAComputer()
        {
            Console.WriteLine("Jeste li sigurni da želite odustati od računala?");
            if (ChecksAndVerifications.ConfimationCheck())
            {
                PopUps.UserGaveUpOnBuiltPC();
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Povratak na izbor komponenti");
                PopUps.ReturnToMenu();
                return false;
            }
        }
    }
}
