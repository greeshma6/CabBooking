using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabBooking.Models
{
    public class Customer
    {
        int cid;
        string cname;
        int crating;
        int cityid;
        int clat;
        int clong;
        public int CustomerId
        {
            get { return cid; }
            set { cid = value; }
        }

        public string CustomerName
        {
            get { return cname; }
            set { cname = value; }
        }

        public int CityId
        {
            get { return cityid; }
            set { cityid = value; }
        }

        public int CustomerRating
        {
            get { return crating; }
            set { crating = value; }
        }

        public int Customerlat
        {
            get { return clat; }
            set { clat = value; }
        }

        public int Customerlong
        {
            get { return clong; }
            set { clong = value; }
        }
    }
}