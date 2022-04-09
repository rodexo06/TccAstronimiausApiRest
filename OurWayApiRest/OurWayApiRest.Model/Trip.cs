using System;
using System.Collections.Generic;
using System.Text;

namespace OurWayApiRest.Model
{
    class Trip
    {
        public int CIdTrip{ get; set; }
        public DateTime DTrip{ get; set; }
  public DateTime DClosed{ get; set; }
  public DateTime DFinish{ get; set; }
  public int CIdBranch{ get; set; }
        public bool HaveMan{ get; set; }
        public bool Enabled{ get; set; }
        public int CIdUserCreated{ get; set; }
        public string XTripStatus { get; set; }
  public string XTripReason { get; set; }
    }

    class UserTrip
    {
        public int CIdUser{ get; set; }
        public int CIdTrip{ get; set; }
        public bool Enabled{ get; set; }
        public DateTime DLastUpdate{ get; set; }
}
}

