using CabBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CabBooking.Controllers
{
    public class BookingRideController : ApiController
    {
        List<CabDriver> cabdriverlist = new List<CabDriver>();
        List<Bookings> pbooking = new List<Bookings>();
        List<Cab> cab = new List<Cab>();
        Dictionary<int, double> price = new Dictionary<int, double>();
        DriverWallet dw = new DriverWallet();
        CustomerWallet cw = new CustomerWallet();
        Dictionary<CabDriver, double> closestdrivers = new Dictionary<CabDriver, double>();


        //[HttpGet]
        //[System.Web.Http.Route("Api/BookRide")]

        public void BookRide(int clat, int clong, Customer cust, int cabtype, string ridetype, int dlat, int dlong)
        {
            CabDriver cd = new CabDriver();
            cd.CabDriverId = 1800;
            cd.CabDriverName = "Raju";
            cd.CabDriverRating = 5;
            cd.CabDriverlat = 4;
            cd.CabDriverlong = 15;
            cd.CabId = 2;
            cd.CabType = 0;
            cd.CityId = 3;
            cd.DriverStatus = 1;

            CabDriver cd2 = new CabDriver();
            cd2.CabDriverId = 12000;
            cd2.CabDriverName = "Rumesh";
            cd2.CabDriverRating = 5;
            cd2.CabDriverlat = 2;
            cd2.CabDriverlong = 6;
            cd2.CabId = 1;
            cd2.CabType = 0;
            cd2.CityId = 3;
            cd2.DriverStatus = 1;

            cabdriverlist.Add(cd);
            cabdriverlist.Add(cd2);
            dw.DriverId = 1800;
            dw.Amount = 1400;
            dw.DriverId = 12000;
            dw.Amount = 1600;
            price.Add(3, 300);
            if (ridetype == "Go")
            {
                CabDriver selectedcabdriver = null;
                cw.CustomerId = cust.CustomerId;
                cw.Amount = 1800;
                FindClosestDrivers(clat, clong, cabtype, cust.CityId);
                var closedrivers = from pair in closestdrivers
                                   orderby pair.Value ascending
                                   select pair;
                if (closestdrivers.Count() == 0)
                    Console.WriteLine("No driver found");
                else
                {
                    int i = 0;
                    foreach (KeyValuePair<CabDriver, double> pair in closestdrivers)
                    {
                        if (i < 3)
                        {
                            int status = NotifyDriver(pair.Key, dlat, dlong);

                            char driverselection = Convert.ToChar(Console.ReadLine());
                            if (driverselection == 'Y')
                            {
                                selectedcabdriver = pair.Key;
                                break;
                            }
                            else
                                i++;
                        }

                    }
                    if (selectedcabdriver == null)
                    { Console.WriteLine("No driver found"); return; }
                    Console.WriteLine("Cab driver selected " + selectedcabdriver.CabDriverName);
                    Console.ReadLine();
                    Bookings pbook = new Bookings();
                    pbook.BookingId = 1567;
                    pbook.BookingType = ridetype;
                    pbook.CityId = cust.CityId;
                    pbook.CustomerId = cust.CustomerId;
                    pbook.Destinationlatitude = dlat;
                    pbook.Destinationlongitude = dlong;
                    pbook.Price = (CalculateDistance(clat, clong, dlat, dlong) / 10000) * price[cust.CityId];
                    pbook.BookingStatus = 1;
                    pbook.CabDriverId = selectedcabdriver.CabDriverId;

                    Console.WriteLine("Trip booked");

                    // Keep polling if trip has completed
                    //if trip has completed

                    dw.Amount = dw.Amount + pbook.Price;
                    cw.Amount = cw.Amount - pbook.Price;
                    pbook.BookingStatus = 2;
                    Console.WriteLine("Trip completed");

                    Console.WriteLine("Drivers wallet : " + dw.DriverId + " " + dw.Amount);
                    Console.WriteLine("Customers wallet : " + cw.CustomerId + " " + cw.Amount);
                }
            }
        }

        public void FindClosestDrivers(int custlat, int custlong, int cabtype, int cityid)
        {
            double dist = 1000000000;
            CabDriver cdriverid = null;
            foreach (CabDriver cdriver in cabdriverlist)
            {
                if (cdriver.CabType == cabtype && cdriver.CityId == cityid)
                {
                    double cdist = CalculateDistance(custlat, custlong, cdriver.CabDriverlat, cdriver.CabDriverlong);
                    Console.WriteLine(cdist);
                    if (cdist < dist)
                    { dist = cdist; cdriverid = cdriver; closestdrivers.Add(cdriverid, dist); }
                }
            }
            return;
        }

        public double CalculateDistance(int sxloc, int syloc, int dxloc, int dyloc)
        {
            //SELECT *,(((acos(sin((@orig_lat * pi() / 180)) * sin((dest.latitude * pi() / 180)) + cos((@orig_lat * pi() / 180)) * cos((dest.latitude * pi() / 180)) * cos(((@orig_lon - dest.longitude) * pi() / 180)))) * 180 / pi()) * 60 * 1.1515 * 1609.344) as distance 
            // FROM nodes AS dest HAVING distance < @dist ORDER BY distance ASC LIMIT 100;
            double cdist = (((Math.Acos(Math.Sin((sxloc * Math.PI / 180)) * Math.Sin((dxloc * Math.PI / 180)) + Math.Cos((sxloc * Math.PI / 180)) * Math.Cos((dxloc * Math.PI / 180)) * Math.Cos(((syloc - dyloc) * Math.PI / 180)))) * 180 / Math.PI) * 60 * 1.1515 * 1609.344);
            return cdist;
        }

        public int NotifyDriver(CabDriver cdriver, int Destinationlatitude, int Destinationlongitude)
        {
            Console.WriteLine("Notifyingdriver : " + cdriver.CabDriverId + " " + cdriver.CabDriverName);
            Console.WriteLine("Destination coordinates : " + Destinationlatitude + " " + Destinationlongitude);
            return 1;
        }

    }
}
