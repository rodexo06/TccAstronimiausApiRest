using System;

namespace OurWayApiRest.Model
{
    public class User
    {
        public int CIdUser { get; set; }
        public string CLogin { get; set; }
        public string SUserName { get; set; }
        public bool Enabled { get; set; }
        public DateTime DLastUpdate { get; set; }
        public DateTime DCreated { get; set; }

    }
}
