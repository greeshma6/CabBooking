using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabBooking.Models
{
    public class CustomerWallet
    {
        int cid;
        double amount;

        public int CustomerId
        {
            get { return cid; }
            set { cid = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}