using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using PresentationLayer.Discounts;

namespace PresentationLayer.Bill
{
    class Bill
    {
        static public void PrintUsersData(Buyer User)
        {
            Console.Clear();
            Console.WriteLine("========================================================\n" +
                $"Kupac:\nIme i prezime: {User.Name}\nAdresa: {User.Address}\nUdaljenost: {User.Distance} km" +
                "\n========================================================\n");
        }

        static public void PrintSingleBilll(Buyer User, int j, int assemblingPrice, double totalWeight, double finalPrice)
        {
            Console.WriteLine($"{j + 1}. RAČUN:");
            Outputs.PrintAComputer(User.currentlyBuiltComputers[j]);

            Console.WriteLine($"\nUkupna težina računala: {totalWeight} kg");
            Console.WriteLine($"\nCijena sastavljanja računala: {assemblingPrice} kn");
            Console.WriteLine($"\nUkupna cijena računala: {Math.Round(finalPrice, 2)} kn");
        }

        static public double PrintChosenComponents(Buyer User)
        {
            var totalPriceOverall = 0d;

            for (int j = 0; j < User.currentlyBuiltComputers.Count; j++)
            {
                var finalPrice = CalculationsForBill.ComposeSingleBill(User, j);
                totalPriceOverall += finalPrice;
                Console.WriteLine("\n========================================================\n");
            }

            PrintTotalPriceOfAllComputers(totalPriceOverall, User);
            return totalPriceOverall;
        }

        static void PrintTotalPriceOfAllComputers(double totalPriceOverall, Buyer User)
        {
            var deliveryCost = CalculationsForBill.TotalDeliveryCost(User);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n========================================================\n" +
            $"Cijena dostave: {Math.Round(deliveryCost, 2)} kn\n" +
            $"Ukupna cijena: {Math.Round(totalPriceOverall + deliveryCost, 2)} kn.\n" +
            "========================================================\n");
            Console.ResetColor();
        }

        static public void PrintFinalPrice(double totalPriceOverall)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================================\n" +
            $"Ukupna cijena nakon mogućih popusta: {Math.Round(totalPriceOverall, 2)} kn.\n" +
            "========================================================\n");
            Console.ResetColor();
        }

        static public BuiltComputer PrintBill(BuiltComputer builtComputer, Buyer User)
        {
            PrintUsersData(User);
            var totalPriceOverall = PrintChosenComponents(User);
            User.BuyerWillChooseBonusComponents = false;

            Console.WriteLine("Želite li vidjeti popuste?");
            if (ChecksAndVerifications.ConfimationCheck())
            {
                PopUps.ProgressToDiscountMenu();
                totalPriceOverall = DiscountsMenu.DiscountMenu(User, totalPriceOverall);
            }

            if(User.BuyerWillChooseBonusComponents)
                builtComputer.bonusComponents.Add(ThreeForTwo.ThreeForTwoDiscount(User));

            PrintFinalPrice(totalPriceOverall);

            Console.WriteLine("Želite li platiti?");
            if (ChecksAndVerifications.ConfimationCheck())
            {
                return CalculationsForBill.PaymentProcess(User, totalPriceOverall);
            }
            Console.Clear();
            User.currentlyBuiltComputers = new();
            Console.WriteLine("Odustali ste od kupnje.\n\nPovratak na glavni izvornik.");
            PopUps.ReturnToMenu();
            return new BuiltComputer();
        }
    }
}
