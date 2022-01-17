namespace Control.Enum_Like
{
    public class FlightClassEnum
    {
        private FlightClassEnum(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }

        public static FlightClassEnum EconomicClass
        {
            get { return new FlightClassEnum("Economic Class"); }
        }

        public static FlightClassEnum BussinessClass
        {
            get { return new FlightClassEnum("Bussiness Class"); }
        }
    }
}