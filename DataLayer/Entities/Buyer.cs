using System;
using System.Collections.Generic;
using DataLayer.Entities;

namespace DataLayer
{
    public class Buyer : ListOfCustomers
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        private string _address;
        public string Address { get => _address; set => _address = value; }

        private int _distance;
        public int Distance { get => _distance; set => _distance = value; }

        private double _amountOfMoneySpent;
        public double AmountOfMoneySpent { get => _amountOfMoneySpent; set => _amountOfMoneySpent = value; }

        private bool _deliverAtHome;
        public bool DeliverAtHome { get => _deliverAtHome; set => _deliverAtHome = value; }

        private bool _loyalCustomerDiscount;
        public bool LoyalCustomerDiscount { get => _loyalCustomerDiscount; set => _loyalCustomerDiscount = value; }

        private bool _buyerChoseToUseLoyalCustomerDiscount;
        public bool BuyerChoseToUseLoyalCustomerDiscount { get => _buyerChoseToUseLoyalCustomerDiscount; set => _buyerChoseToUseLoyalCustomerDiscount = value; }

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
