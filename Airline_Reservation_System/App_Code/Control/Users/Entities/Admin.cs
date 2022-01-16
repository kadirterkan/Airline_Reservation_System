using System.Collections.Generic;
using Control.Common;
using Control.Flights.Flight.Entities;

namespace Control.Users.Entities
{
    public class Admin : BaseEntity
    {
        private ICollection<Flight> Flights { get; set; }

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }
    }
}