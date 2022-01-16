using System.ComponentModel.DataAnnotations.Schema;
using Control.Common;
using Control.Enum_Like;

namespace Control.Flights.Customer.Ticket
{
    public class Ticket : BaseEntity
    {
        private Flight.Entities.Flight _flight;
        private Passenger.Passenger _passenger;
        private FlightClassEnum _flightClass;
        private string _passengerSeat;
        private string _paymentMethod;

        public Flight.Entities.Flight Flight
        {
            get => _flight;
            set => _flight = value;
        }

        public Passenger.Passenger Passenger
        {
            get => _passenger;
            set => _passenger = value;
        }

        public FlightClassEnum FlightClass
        {
            get => _flightClass;
            set => _flightClass = value;
        }

        public string PassengerSeat
        {
            get => _passengerSeat;
            set => _passengerSeat = value;
        }

        public string PaymentMethod
        {
            get => _paymentMethod;
            set => _paymentMethod = value;
        }
    }
}

