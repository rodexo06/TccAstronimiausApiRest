namespace OurWayApiRest.Model
{
    public class TripCard
    {
        public Trip trip { get; set; }
        public User UserCreated { get; set; }
        public PosAdress origin { get; set; }
        public PosAdress destination { get; set; }
        public GeneralDescription tripStatus { get; set; }
        public int quantityTrip { get; set; }
        public bool haveMan { get; set; }
        public double journeyTime { get; set; }
    }
}
