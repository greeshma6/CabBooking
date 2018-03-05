using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabBooking.Models
{
    public class CabDriver
    {
        int cid;
        int cdriverid;
        int ctypeid;
        string cdrivername;
        int crating;
        int cityid;
        int driverlat;
        int driverlong;
        int status;

        public int CabId
        {
            get { return cid; }
            set { cid = value; }
        }

        public int CabType
        {
            get { return ctypeid; }
            set { ctypeid = value; }
        }

        public int CityId
        {
            get { return cityid; }
            set { cityid = value; }
        }
        public int CabDriverId
        {
            get { return cdriverid; }
            set { cdriverid = value; }
        }

        public string CabDriverName
        {
            get { return cdrivername; }
            set { cdrivername = value; }
        }

        public int CabDriverRating
        {
            get { return crating; }
            set { crating = value; }
        }

        public int CabDriverlat
        {
            get { return driverlat; }
            set { driverlat = value; }
        }

        public int CabDriverlong
        {
            get { return driverlong; }
            set { driverlong = value; }
        }

        public int DriverStatus
        {
            get { return status; }
            set { status = value; }
        }

    }
}