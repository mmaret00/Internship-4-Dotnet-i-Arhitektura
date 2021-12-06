using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;

namespace PresentationLayer.Bill
{
    class CalculationsForBill
    {
        static public double ComposeSingleBill(Buyer User, int j)
        {
            var totalPrice = User.currentlyBuiltComputers[j]._processor.Price + User.currentlyBuiltComputers[j]._hardDisk.Price + User.currentlyBuiltComputers[j]._computerCase.Price;
            for (int i = 0; i < User.currentlyBuiltComputers[j]._RAM.Count; i++)
            {
                totalPrice += User.currentlyBuiltComputers[j]._RAM[i].Price;
            }
            var assemblingPrice = (3 + User.currentlyBuiltComputers[j]._RAM.Count) * 25;
            var finalPrice = totalPrice + assemblingPrice;
            var totalWeight = User.currentlyBuiltComputers[j]._hardDisk.Weight + User.currentlyBuiltComputers[j]._computerCase.Weight;

            Bill.PrintSingleBilll(User, j, assemblingPrice, totalWeight, finalPrice);

            return finalPrice;
        }

        static public double TotalDeliveryCost(Buyer User)
        {
            var weight = 0d;
            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                weight += User.currentlyBuiltComputers[i]._hardDisk.Weight + User.currentlyBuiltComputers[i]._computerCase.Weight;
            }
            return DomainLayer.DevileryFeeCalculation.CalculateDeliveryCost(User, weight);
        }

        static public BuiltComputer PaymentProcess(Buyer User, double totalPriceOverall)
        {
            User.AmountOfMoneySpent += totalPriceOverall;
            if (User.AmountOfMoneySpent > 1000)
                User.LoyalCustomerDiscount = true;

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                User.previouslyBoughtComputers.Add(User.currentlyBuiltComputers[i]);
            }

            if (true == User.BuyerChoseToUseLoyalCustomerDiscount)
            {
                User.AmountOfMoneySpent = 0;
                User.LoyalCustomerDiscount = false;
            }

            User.currentlyBuiltComputers = new();
            Console.WriteLine("Kupnja uspješno obavljena.");
            PopUps.ReturnToMenu();
            return new BuiltComputer();
        }
    }
}
