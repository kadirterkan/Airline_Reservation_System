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
        private Airport _departureAirport;
        private Airport _arrivalAirport;
        private int _flightTimeByMinutes;
        private DateTime _departureTime;
        private DateTime _arrivalTime;
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

        public Airport DepartureAirport
        {
            get => _departureAirport;
            set => _departureAirport = value;
        }

        public Airport ArrivalAirport
        {
            get => _arrivalAirport;
            set => _arrivalAirport = value;
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

        public DateTime ArrivalTime
        {
            get => _arrivalTime;
            set => _arrivalTime = value;
        }

        public ICollection<Ticket> Tickets
        {
            get => _tickets;
            set => _tickets = value;
        }
    }
}