using System;
using System.ComponentModel.DataAnnotations.Schema;
using Control.Common;
using Control.Enum_Like;

namespace Control.Flights.Customer.Ticket
{
    public class Ticket : BaseEntity
    {
        private Flight.Entities.Flight _flight;
        private Passenger.Passenger _passenger;
        public String FlightClass { get; set; }
        private string _passengerSeat;

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

        public string PassengerSeat
        {
            get => _passengerSeat;
            set => _passengerSeat = value;
        }
    }
}

