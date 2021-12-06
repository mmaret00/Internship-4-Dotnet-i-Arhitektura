using System;
using System.Collections.Generic;
using DataLayer.Entities;

namespace DataLayer
{
    public class Buyer : ListOfCustomers
    {
        private string name;
        public string Name { get => name; set => name = value; }

        private string address;
        public string Address { get => address; set => address = value; }

        private int distance;
        public int Distance { get => distance; set => distance = value; }

        private double amountOfMoneySpent;
        public double AmountOfMoneySpent { get => amountOfMoneySpent; set => amountOfMoneySpent = value; }

        private bool deliverAtHome;
        public bool DeliverAtHome { get => deliverAtHome; set => deliverAtHome = value; }

        private bool loyalCustomerDiscount;
        public bool LoyalCustomerDiscount { get => loyalCustomerDiscount; set => loyalCustomerDiscount = value; }

        private bool buyerChoseToUseLoyalCustomerDiscount;
        public bool BuyerChoseToUseLoyalCustomerDiscount { get => buyerChoseToUseLoyalCustomerDiscount; set => buyerChoseToUseLoyalCustomerDiscount = value; }

        public List<BuiltComputer> previouslyBoughtComputers = new();

        public List<BuiltComputer> currentlyBuiltComputers;

        public bool BuyerWillChooseBonusComponents;

        public bool ClaimedCodeDiscount;

        public bool ClaimedLoyaltyDiscount;

        public Buyer(string _name, string _address, int _distance)
        {
            Name = _name;
            Address = _address;
            Distance = _distance;
            AmountOfMoneySpent = 0;
            currentlyBuiltComputers = new();
        }
    }
}
