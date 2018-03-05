using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CabBooking.Models
{
    public class Cab
    {
        int cabid;
        string cabno;
        int cabtype;

        public int CabId
        {
            get { return cabid; }
            set { cabid = value; }
        }

        public string CabNum
        {
            get { return cabno; }
            set { cabno = value; }
        }

        public int CabType
        {
            get { return cabtype; }
            set { cabtype = value; }
        }
    }
}