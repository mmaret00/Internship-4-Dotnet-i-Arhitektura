using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;

namespace DomainLayer
{
    public class ChecksAndVerifications
    {/*
        static public bool CheckIfAddressIsValid(string name)
        {
            if (CheckIfAddressIsLettersAndNumbersOnly(name) && CheckIfStringIsEmpty(name, false))
            {
                return true;
            }
            return false;
        }

        static public bool CheckIfNameIsValid(string name)
        {
            if (CheckIfNameIsLettersOnly(name) && CheckIfStringIsEmpty(name, true))
            {
                return true;
            }
            return false;
        }

        static bool CheckIfStringIsEmpty(string name, bool choice)
        {
            if (0 == name.Length)
            {
                if (true == choice) Console.WriteLine("Nedopušten je unos praznog imena!");
                if (false == choice) Console.WriteLine("Nedopušten je unos prazne adrese!");
                //PopUps.ReturnToMenu(); stavit nesto
                return false;
            }
            return true;
        }

        static bool CheckIfNameIsLettersOnly(string name)
        {
            if (!NameLettersCheck(name))
            {
                Console.WriteLine("Ime treba sadržavati samo slova i razmake!");
                return false;
            }
            if (!name.Any(Char.IsWhiteSpace))
            {
                Console.WriteLine("Molimo upišite i ime i prezime!");
                return false;
            }
            return true;
        }

        static bool CheckIfStringIsAtLeastFiveLettersLong(string name)//napravit ovo, ndms
        {
            if (name.Length < 5)
            {
                Console.WriteLine("Ime i prezime trebaju sadržavati barem po dva slova!");
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
            if (!address.Any(Char.IsWhiteSpace))
            {
                Console.WriteLine("Adresa treba sadržavati ulicu i kućni broj!");
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
            if (null == builtComputer._processor && null == builtComputer._RAM && null == builtComputer._hardDisk && null == builtComputer._computerCase)
            {
                Menus.MessageWhenComputerIsNotBuilt();
                return false;
            }
            else return true;
        }
        */
    }
}
