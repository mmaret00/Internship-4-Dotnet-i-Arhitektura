using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ListOfCustomers
    {
        public static readonly List<Buyer> CustomersList = new();

        public static Buyer BuyerExists(string _name, string _address)
        {
            foreach (var buyer in CustomersList)
            {
                if (_name == buyer.Name && _address == buyer.Address)
                    return buyer;
            }
            return null;
        }
    }
}
