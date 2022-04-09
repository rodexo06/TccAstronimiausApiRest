using System;

namespace OurWayApiRest.Model
{
    public class Login
    {
        public int CIdUser { get; set; }
        public string CLogin { get; set; }
        public string CPassword { get; set; }
        public bool SSO { get; set; }
        public string SUserLegacy { get; set; }
        public int CIdCompany { get; set; }

    }
}
