using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Control.Common;
using Control.Flights.Customer.Ticket;

namespace Control.Flights.Flight.Entities
{
    public class Flight : BaseEntity
    {
        private string _flightNumber;
        private Aircraft _aircraft;
        public Routes FlightRoute { get; set; }
        private int _flightTimeByMinutes;
        private DateTime _departureTime;
        public String GateNo { get; set; }
        public long FlightPrice { get; set; }
        public int EcoCapacity { get; set; }
        public int BusCapacity { get; set; }
        public string FlightType { get; set; }
        private ICollection<Ticket> _tickets;

        public string FlightNumber
        {
            get => _flightNumber;
            set => _flightNumber = value;
        }

        public Aircraft Aircraft
        {
            get => _aircraft;
            set => _aircraft = value;
        }

        public int FlightTimeByMinutes
        {
            get => _flightTimeByMinutes;
            set => _flightTimeByMinutes = value;
        }

        public DateTime DepartureTime
        {
            get => _departureTime;
            set => _departureTime = value;
        }

        public ICollection<Ticket> Tickets
        {
            get => _tickets;
            set => _tickets = value;
        }
    }
}