using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using PresentationLayer.Enums;

namespace PresentationLayer.Discounts
{
    public class DiscountsMenu
    {
        static public double DiscountMenu(Buyer User, double totalPriceOverall)
        {
            var exitMenu = false;
            while (true != exitMenu)
            {
                Console.Clear();
                var choice = (DiscountMenuChoice)DiscountMenuOutput();

                switch (choice)
                {
                    case DiscountMenuChoice.Loyalty:
                        totalPriceOverall = LoyaltyDiscountCheck(User, totalPriceOverall);
                        break;
                    case DiscountMenuChoice.Quantity:
                        Console.Clear();
                        Console.WriteLine("Aktivirali ste popust na količinu. Kad nastavite s " +
                            "plaćanjem ćete dobiti ponudu za odabir besplatnih komponenti.\n");
                        User.BuyerWillChooseBonusComponents = true;
                        PopUps.ReturnToDiscountMenu();
                        break;
                    case DiscountMenuChoice.Code:
                        totalPriceOverall = CodeDiscountCheck(totalPriceOverall, User);
                        break;
                    case DiscountMenuChoice.Continue:
                        Console.WriteLine("Nastavljate s plaćanjem računa.");
                        Console.Clear();
                        return totalPriceOverall; ;
                    default:
                        Console.Clear();
                        Console.WriteLine("Molimo unesite jedan od dopuštenih brojeva (0-3)\n");
                        break;
                }
            }
            return totalPriceOverall;
        }

        static public char DiscountMenuOutput()
        {
            Console.WriteLine("Odaberite popust:\n" +
                "1 - Popust za vjerno članstvo\n" +
                "2 - Za svake dvije iste komponente u narudžbi, treća gratis\n" +
                "3 - Popust unosom koda\n" +
                "0 - Nastavak na plaćanje računa");

            char.TryParse(Console.ReadLine().Trim(), out char choice);

            return choice;
        }

        static public double LoyaltyDiscountCheck(Buyer User, double totalPriceOverall)
        {
            if (true == User.BuyerChoseToUseLoyalCustomerDiscount)
            {
                Console.Clear();
                Console.WriteLine("Već ste iskoristili ovaj popust!");
                PopUps.ReturnToDiscountMenu();
                return totalPriceOverall;
            }

            if (Loyalty.CheckIfUserHasALoyaltyDiscount(User))
            {
                totalPriceOverall -= 100;
                User.BuyerChoseToUseLoyalCustomerDiscount = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Dosad niste potrošili više od 1000 kn pa nemate pravo " +
                "na popust za vjerno članstvo!\n");
                PopUps.ReturnToDiscountMenu();
            }

            return totalPriceOverall;
        }

        static public double CodeDiscountCheck(double totalPriceOverall, Buyer User)
        {
            if(true == User.ClaimedCodeDiscount)
            {
                Console.Clear();
                Console.WriteLine("Već ste iskoristili ovaj popust!");
                PopUps.ReturnToDiscountMenu();
                return totalPriceOverall;
            }
            var discount = SecretCode.CheckIfUserHasADiscountCode();
            if (0 != discount)
            {
                User.ClaimedCodeDiscount = true;
                totalPriceOverall *= (1 - discount);
            }
            PopUps.ReturnToDiscountMenu();
            return totalPriceOverall;
        }
    }
}
