using System;
using System.ComponentModel.DataAnnotations;

namespace OurWayApiRest.Model
{
    public class Adress
    {
        [Key]
        public int CIdAddress { get; set; }
        public string SStreet { get; set; }
        public string SNumber { get; set; }
        public string SComplement { get; set; }
        public string SZipCode { get; set; }
        public int CIdState { get; set; }
        public int CIdCountry { get; set; }
        public string XCoord { get; set; }
        public string YCoord { get; set; }
        public bool Enabled { get; set; }
        public DateTime DLastUpdate { get; set; }

        public Adress(int cIdAddress, string sStreet, string sNumber, string sComplement, string sZipCode, int cIdState, int cIdCountry, string xCoord, string yCoord, bool enabled, DateTime dLastUpdate)
        {
            this.CIdAddress = cIdAddress;
            this.SStreet = sStreet;
            this.SNumber = sNumber;
            this.SComplement = sComplement;
            this.SZipCode = sZipCode;
            this.CIdState = cIdState;
            this.CIdCountry = cIdCountry;
            this.XCoord = xCoord;
            this.YCoord = yCoord;
            this.Enabled = enabled;
            this.DLastUpdate = dLastUpdate;
        }
    }

    public class UserAddress
    {
        public UserAddress(int cIdUser, int cIdAddress, bool enabled, DateTime dLastUpdate)
        {
            this.CIdUser = cIdUser;
            this.CIdAddress = cIdAddress;
            this.Enabled = enabled;
            this.DLastUpdate = dLastUpdate;
        }

        public int CIdUser { get; set; }
        public int CIdAddress { get; set; }
        public bool Enabled { get; set; }
        public DateTime DLastUpdate { get; set; }

    }

}
