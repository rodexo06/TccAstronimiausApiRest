using System;
using System.Collections.Generic;
using System.Text;

namespace OurWayApiRest.Model
{
    public class CheckinOut
        {
            public int CIdCheckinOut { get; set; }
            public int CIdUser { get; set; }
            public int CIdTrip { get; set; }
            public DateTime DCheckin { get; set; }
            public DateTime DCheckout { get; set; }
            public string XCoordIn { get; set; }
            public string YCoordIn { get; set; }
            public string XCoordOut { get; set; }
            public string YCoordOut { get; set; }
            public bool Enabled { get; set; }
            public DateTime DLastUpdate { get; set; }

        }
    }
