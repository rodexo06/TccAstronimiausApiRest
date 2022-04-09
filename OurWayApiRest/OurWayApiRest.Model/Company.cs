using System;

namespace OurWayApiRest.Model
{
    class Company
    {
        public int CIdCompany { get; set; }
        public string SCompany { get; set; }
        public bool Enabled { get; set; }
        public DateTime DLastUpdate { get; set; }
    }
    class BranchCompany
    {
        public int CIdCompany { get; set; }
        public int CIdBranch { get; set; }
        public bool Enabled { get; set; }
        public DateTime DLastUpdate { get; set; }
    }
}
