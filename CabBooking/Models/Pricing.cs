using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabBooking.Models
{
    public class Pricing
    {
        int cityid;
        string cityname;
        float price;

        public int CityId
        {
            get { return cityid; }
            set { cityid = value; }
        }

        public string CityName
        {
            get { return cityname; }
            set { cityname = value; }
        }


        public float Price
        {
            get { return price; }
            set { price = value; }
        }

       
    }
}