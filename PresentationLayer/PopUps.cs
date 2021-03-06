using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    class PopUps
    {
        static public void ReturnToMenu()
        {
            Console.WriteLine("\nKliknite bilo koju tipku za povratak na glavni izbornik.");
            Console.ReadKey();
            Console.Clear();
        }

        static public void ReturnToBuilding()
        {
            Console.WriteLine("\nOdabrane komponente su spremljene.");
            ReturnToBuildingWithoutChoosing();

        }

        static public void ReturnToBuildingWithoutChoosing()
        {
            Console.WriteLine("Kliknite bilo koju tipku za povratak na izbor komponenti.");
            Console.ReadKey();
            Console.Clear();
        }
        static public void ProgressToDiscountMenu()
        {
            Console.WriteLine("\nKliknite bilo koju tipku za nastavak na izbor popusta.");
            Console.ReadKey();
        }

        static public void ReturnToDiscountMenu()
        {
            Console.WriteLine("\nKliknite bilo koju tipku za povratak na izbor popusta.");
            Console.ReadKey();
        }

        static public void ClickAnyKeyToContinue()
        {
            Console.WriteLine("\nKliknite bilo koju tipku za nastavak.");
            Console.ReadKey();
            Console.Clear();
        }

        static public void UserEnteredUnacceptableChoice()
        {
            Console.WriteLine("Unijeli ste nedopušten unos, molimo ponovite ga.");
            Console.WriteLine("\nKliknite bilo koju tipku za nastavak izbora.");
            Console.ReadKey();
            Console.Clear();
        }

        static public void UserGaveUpOnBuiltPC()
        {
            Console.Clear();
            Console.WriteLine("Odustali ste od računala. Slijedi povratak na glavni izbornik.");
            ClickAnyKeyToContinue();
        }
        static public void ReturnToLoginMenu()
        {
            Console.WriteLine("Povratak na početni zaslon.");
            ClickAnyKeyToContinue();
        }
    }
}
