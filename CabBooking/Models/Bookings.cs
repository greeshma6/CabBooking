using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabBooking.Models
{
    public class Bookings
    {

        int bookid;
        string booktype;
        int bookstatus;
        int custid;
        int cabdriverid;
        int cityid;
        DateTime createdate;
        int destlat;
        int destlong;
        double price;
        int paymenttype;

        public int BookingId
        {
            get { return bookid; }
            set { bookid = value; }
        }

        public int BookingStatus
        {
            get { return bookstatus; }
            set { bookstatus = value; }
        }


        public string BookingType
        {
            get { return booktype; }
            set { booktype = value; }
        }

        public int CustomerId
        {
            get { return custid; }
            set { custid = value; }
        }

        public int CabDriverId
        {
            get { return cabdriverid; }
            set { cabdriverid = value; }
        }

        public DateTime CreateDate
        {
            get { return createdate; }
            set { createdate = value; }
        }

        public int CityId
        {
            get { return cityid; }
            set { cityid = value; }
        }

        public int Destinationlatitude
        {
            get { return destlat; }
            set { destlat = value; }
        }

        public int Destinationlongitude
        {
            get { return destlong; }
            set { destlong = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int  PaymentType
        {
            get { return paymenttype; }
            set { paymenttype = value; }
        }
    }
}