using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;

namespace DomainLayer
{
    class Bill
    {
        static public bool ConfirmingUsersChoice()
        {
            while (true)
            {
                var confirmLoyalCustomerDiscount = Console.ReadLine();

                if ("da" == confirmLoyalCustomerDiscount)
                {
                    return true;
                }
                else if ("ne" == confirmLoyalCustomerDiscount)
                {
                    return false;
                }
                else Console.WriteLine("Nedopušten unos, molimo unesite 'da' ili 'ne':");
            }
        }

        static public bool CheckIfUserHasALoyaltyDiscount(Buyer User)
        {
            if (true == User.LoyalCustomerDiscount)
            {
                Console.WriteLine("\nBudući da ste ranije potrošili preko 1000 kn, " +
                "imate priliku za popust od 100 kn. Želite li ga iskoristiti u " +
                "ovoj kupnji? Ako želite, upišite 'da' ili 'ne':");

                var returnValue = (true == ConfirmingUsersChoice());
                return returnValue;
            }
            return false;
        }

        static public int RepeatingDiscountCodeEntering()
        {
            Console.WriteLine("Unijeli ste pogrešan kod, želite li ponoviti unos? Upišite 'da' ili 'ne':");
            var userChoosingWhetherHeWantsToReenterCode = Console.ReadLine();
            if ("ne" == userChoosingWhetherHeWantsToReenterCode)
            {
                return 0;
            }
            else if ("da" == userChoosingWhetherHeWantsToReenterCode)
            {
                return 1;
            }
            else
            {
                Console.WriteLine("Nedopušten unos, molimo unesite 'da' ili 'ne':");
                return 2;
            }
        }

        static public double UserHasADiscountCode()
        {
            var correctEntry = false;
            while (false == correctEntry)
            {
                Console.WriteLine("Unesite kod za popust:");
                var discountCodeUserEntered = Console.ReadLine();

                var userEnteredCorrectCode = false;
                foreach (var code in DiscountCodes.SecretCodes)
                {
                    if (code.Key == discountCodeUserEntered)
                    {
                        Console.WriteLine("Uspješno ste unijeli validan kod. " +
                            $"Odobren vam je popust od {code.Value}%.");
                        userEnteredCorrectCode = true;
                        return (double)code.Value / 100;
                    }
                }
                while (false == userEnteredCorrectCode)
                {
                    var choiceForReenteringCode = RepeatingDiscountCodeEntering();
                    if (0 == choiceForReenteringCode)
                    {
                        userEnteredCorrectCode = true;
                        correctEntry = true;
                    }
                    else if (1 == choiceForReenteringCode)
                    {
                        userEnteredCorrectCode = true;
                    }
                }
            }
            return 0;
        }

        static public double CheckIfUserHasADiscountCode()
        {
            Console.WriteLine("Imate li kod za popust? Unesite 'da' ili 'ne':");
            while (true)
            {
                var confirmDiscountCode = Console.ReadLine();
                while ("da" == confirmDiscountCode)
                {
                    var valueToReturn = UserHasADiscountCode();
                    if (0 == valueToReturn) confirmDiscountCode = "";
                    else if (1 == valueToReturn) continue;
                    else return valueToReturn;
                }
                if ("ne" == confirmDiscountCode)
                {
                    return 0;
                }
                else Console.WriteLine("Nedopušten unos, molimo unesite 'da' ili 'ne':");
            }
        }

        static public void ThreeForTwoDiscountProcessors(Buyer User, BonusComponents bonus)
        {
            var boughtProcessors = new Dictionary<Processor, int>();

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                if (boughtProcessors.ContainsKey(User.currentlyBuiltComputers[i]._processor))
                {
                    boughtProcessors[User.currentlyBuiltComputers[i]._processor]++;
                }
                else
                {
                    boughtProcessors.Add(User.currentlyBuiltComputers[i]._processor, 1);
                }
            }
            ThreeForTwoDiscountProcessorsPrint(boughtProcessors, User, bonus);
        }

        static public void ThreeForTwoDiscountProcessorsPrint(Dictionary<Processor, int> boughtProcessors, Buyer User, BonusComponents bonus)
        {
            foreach (var processor in boughtProcessors)
            {
                if (processor.Value / 2 > 0)
                {
                    Console.WriteLine($"Kupili ste {processor.Value} procesora {processor.Key.Brand} " +
                        $"s {processor.Key.NumberOfCores} jezgri, " +
                        $"pa imate mogućnost dobiti {processor.Value / 2} istih procesora besplatno. " +
                        $"Želite li iskoristiti tu ponudu?");
                    if (ChecksAndVerifications.ConfimationCheck())
                    {
                        bonus.bonusProcessors.Add(processor.Key);
                    }
                }
            }
        }

        static public void ThreeForTwoDiscountRAM(Buyer User, BonusComponents bonus)
        {
            var boughtRAM = new Dictionary<RAM, int>();

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                for (int j = 0; j < User.currentlyBuiltComputers[i]._RAM.Count; j++)
                {
                    if (boughtRAM.ContainsKey(User.currentlyBuiltComputers[i]._RAM[j]))
                    {
                        boughtRAM[User.currentlyBuiltComputers[i]._RAM[j]]++;
                    }
                    else
                    {
                        boughtRAM.Add(User.currentlyBuiltComputers[i]._RAM[j], 1);
                    }
                }
            }
            ThreeForTwoDiscountRAMPrint(boughtRAM, User, bonus);
        }

        static public void ThreeForTwoDiscountRAMPrint(Dictionary<RAM, int> boughtRAM, Buyer User, BonusComponents bonus)
        {
            foreach (var card in boughtRAM)
            {
                if (card.Value / 2 > 0)//continue umisto ugnjezdavanja i to
                {
                    Console.WriteLine($"Kupili ste {card.Value} RAM kartica od {card.Key.Capacity} TB, " +
                        $"pa imate mogućnost dobiti {card.Value / 2} istih RAM kartica besplatno. " +
                        $"Želite li iskoristiti tu ponudu?");
                    if (ChecksAndVerifications.ConfimationCheck())
                    {
                        bonus.bonusRAM.Add(card.Key);
                    }
                }
            }
        }

        static public void ThreeForTwoDiscountHardDisks(Buyer User, BonusComponents bonus)
        {
            var boughtHardDisks = new Dictionary<HardDisk, int>();

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                if (boughtHardDisks.ContainsKey(User.currentlyBuiltComputers[i]._hardDisk))
                {
                    boughtHardDisks[User.currentlyBuiltComputers[i]._hardDisk]++;
                }
                else
                {
                    boughtHardDisks.Add(User.currentlyBuiltComputers[i]._hardDisk, 1);
                }
            }
            ThreeForTwoDiscountHardDisksPrint(boughtHardDisks, User, bonus);
        }

        static public void ThreeForTwoDiscountHardDisksPrint(Dictionary<HardDisk, int> boughtHardDisks, Buyer User, BonusComponents bonus)
        {
            foreach (var disk in boughtHardDisks)
            {
                if (disk.Value / 2 > 0)
                {
                    Console.WriteLine($"Kupili ste {disk.Value} hard diskova {disk.Key.Type} " +
                        $"s {disk.Key.Capacity}, " +
                        $"pa imate mogućnost dobiti {disk.Value / 2} istih hard diskova besplatno. " +
                        $"Želite li iskoristiti tu ponudu?");
                    if (ChecksAndVerifications.ConfimationCheck())
                    {
                        bonus.bonusHardDisk.Add(disk.Key);
                    }
                }
            }
        }

        static public void ThreeForTwoDiscountComputerCases(Buyer User, BonusComponents bonus)
        {
            var boughtComputerCases = new Dictionary<ComputerCase, int>();

            for (int i = 0; i < User.currentlyBuiltComputers.Count; i++)
            {
                if (boughtComputerCases.ContainsKey(User.currentlyBuiltComputers[i]._computerCase))
                {
                    boughtComputerCases[User.currentlyBuiltComputers[i]._computerCase]++;
                }
                else
                {
                    boughtComputerCases.Add(User.currentlyBuiltComputers[i]._computerCase, 1);
                }
            }
            ThreeForTwoDiscountComputerCasesPrint(boughtComputerCases, User, bonus);
        }

        static public void ThreeForTwoDiscountComputerCasesPrint(Dictionary<ComputerCase, int> boughtComputerCases, Buyer User, BonusComponents bonus)
        {
            foreach (var Case in boughtComputerCases)
            {
                if (Case.Value / 2 > 0)
                {
                    Console.WriteLine($"Kupili ste {Case.Key.Material} kućište {Case.Value} puta, " +
                        $"pa imate mogućnost dobiti {Case.Value / 2} istih kućišta besplatno. " +
                        $"Želite li iskoristiti tu ponudu?");
                    if (ChecksAndVerifications.ConfimationCheck())
                    {
                        bonus.bonusComputerCase.Add(Case.Key);
                    }
                }
            }
        }

        static public BonusComponents ThreeForTwoDiscount(Buyer User)
        {
            var bonus = new BonusComponents();

            ThreeForTwoDiscountProcessors(User, bonus);
            ThreeForTwoDiscountHardDisks(User, bonus);
            ThreeForTwoDiscountComputerCases(User, bonus);
            ThreeForTwoDiscountRAM(User, bonus);

            return bonus;
        }

        static public void PrintUsersData(Buyer User)
        {
            Console.Clear();
            Console.WriteLine("\n========================================================\n" +
                $"Kupac:\nIme i prezime: {User.Name}\nAdresa: {User.Address}\nUdaljenost: {User.Distance} km" +
                "\n========================================================\n");
        }

        static public double PrintSingleBill(Buyer User, int j)
        {
            var totalPrice = User.currentlyBuiltComputers[j]._processor.Price + User.currentlyBuiltComputers[j]._hardDisk.Price + User.currentlyBuiltComputers[j]._computerCase.Price;

            Console.WriteLine($"{j+1}. Račun:");
            Outputs.ShowComponentsOfBuiltComputer(User.currentlyBuiltComputers[j]);

            for (int i = 0; i < User.currentlyBuiltComputers[j]._RAM.Count; i++)
            {
                totalPrice += User.currentlyBuiltComputers[j]._RAM[i].Price;
            }

            var assemblingPrice = (3 + User.currentlyBuiltComputers[j]._RAM.Count) * 25;
            Console.WriteLine($"\n\nCijena sastavljanja računala: {assemblingPrice} kn");
            var totalWeight = User.currentlyBuiltComputers[j]._hardDisk.Weight + User.currentlyBuiltComputers[j]._computerCase.Weight;
            Console.WriteLine($"\nUkupna težina: {totalWeight} kg");

            double deliveryCost = CalculateDeliveryCost(User, totalWeight);
            Console.WriteLine($"\nCijena dostave: {deliveryCost} kn");
            var finalPrice = totalPrice + deliveryCost + assemblingPrice;
            Console.WriteLine($"\n\nUkupna cijena: {Math.Round(finalPrice, 2)} kn");
            Console.WriteLine("\n========================================================\n");

            return finalPrice;
        }

        static public double CalculateDeliveryCost(Buyer User, double totalWeight)
        {
            if (User.DeliverAtHome)
            {
                return CalculateShippingFee(User.Distance, totalWeight);
            }
            else return 0;
        }

        static public double PrintChosenComponents(Buyer User)
        {
            var totalPriceOverall = 0d;

            for (int j = 0; j < User.currentlyBuiltComputers.Count; j++)
            {
                var finalPrice = PrintSingleBill(User, j);
                totalPriceOverall += finalPrice;
                Console.WriteLine("\n========================================================\n");
            }
            Console.WriteLine($"Ukupna cijena svih računala: {Math.Round(totalPriceOverall, 2)} kn.");

            return totalPriceOverall;
        }

        static public double CheckIfUserHasDiscounts(Buyer User, double totalPriceOverall)
        {
            if (CheckIfUserHasALoyaltyDiscount(User))
            {
                totalPriceOverall -= 100;
                User.BuyerChoseToUseLoyalCustomerDiscount = true;
            }

            var discount = CheckIfUserHasADiscountCode();
            if (0 != discount)
            {
                totalPriceOverall *= (1 - discount);
            }

            return totalPriceOverall;
        }

        static public BuiltComputer PrintBill(BuiltComputer builtComputer, Buyer User)
        {
            PrintUsersData(User);
            var totalPriceOverall = PrintChosenComponents(User);
            totalPriceOverall = CheckIfUserHasDiscounts(User, totalPriceOverall);

            Console.WriteLine($"Ukupna cijena svih računala nakon svih popusta: {Math.Round(totalPriceOverall, 2)} kn.");
            builtComputer._bonusComponents.Add(ThreeForTwoDiscount(User));

            while (true)
            {
                Console.WriteLine("\nŽelite li platiti? Unesite 'da' ili 'ne':");
                var confirmation = Console.ReadLine();
                if ("da" == confirmation)
                {
                    builtComputer = PaymentProcess(User, builtComputer, totalPriceOverall);
                    PopUps.ReturnToMenu();
                    return builtComputer;
                }
                else if ("ne" == confirmation)
                {
                    builtComputer = new BuiltComputer();
                    Console.WriteLine("Odustali ste od kupnje složenog računala.\n\nPovratak na glavni izvornik.");
                    PopUps.ReturnToMenu();
                    return builtComputer;
                }
                else Console.WriteLine("Nedopušten unos, molimo unesite 'da' ili 'ne':");
            }
        }

        static BuiltComputer PaymentProcess(Buyer User, BuiltComputer builtComputer, double totalPriceOverall)
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
            builtComputer = new BuiltComputer();
            Console.WriteLine("Kupnja uspješno obavljena.");
            return builtComputer;
        }

        static double CalculateShippingFee(int distance, double weight)
        {
            if (3 > weight)
            {
                return (5 * ((double)distance / 10));
            }
            else if (3 < weight && 10 > weight)
            {
                return (3 * ((double)distance / 5));
            }
            else
            {
                return (50 + (10 * ((double)distance / 20)));
            }
        }
    }
}
