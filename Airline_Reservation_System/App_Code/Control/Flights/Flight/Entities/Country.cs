using Control.Common;

namespace Control.Flights.Flight.Entities
{
    public class Country : BaseEntity
    {
        private string _countryName;

        public string CountryName
        {
            get => _countryName;
            set => _countryName = value;
        }
    }
}