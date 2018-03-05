using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabBooking.Models
{
    public class DriverWallet
    {
        int did;
        string accno;
        double amount;

        public int DriverId
        {
            get { return did; }
            set { did = value; }
        }

        public string AccountNo
        {
            get { return accno; }
            set { accno = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}