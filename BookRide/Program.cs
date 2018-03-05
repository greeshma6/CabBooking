using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabBooking.Controllers;
using CabBooking.Models;
using CabBooking;

namespace BookRide
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer cs = new Customer();
            cs.CityId = 3;
            cs.CustomerId = 1543;
            cs.CustomerName = "Priya";
            cs.CustomerRating = 4;
            int dlat = 4;
            int dlong = 3;
            int clat = 1;
            int clong =2;
            BookingRide bk = new BookingRide();
            //BookRide(int clat, int clong, Customer cust, int cabtype = 0 for 4 seater, 1 for 6 seater, string ridetype, int dlat, int dlong)
            bk.BookRide(clat, clong, cs, 0, "Go", dlat, dlong);
            Console.ReadLine();
        }
    }
}
