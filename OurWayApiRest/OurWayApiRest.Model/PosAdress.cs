using System;

namespace OurWayApiRest.Model
{
    public class PosAdress
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string? streetName { get; set; }
        public string? streetNumber { get; set; }
        public string? zipCode { get; set; }
    }
}
