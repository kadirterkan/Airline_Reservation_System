using System;
using System.Collections.Generic;
using Control.Common;
using Control.Enum_Like;
using Control.Flights.Customer.Ticket;

namespace Control.Passenger
{
    public class Passenger : BaseEntity
    {
        private string _firstName;
        private string _lastName;
        private GenderEnum _gender;
        private AgeEnum _age;
        private string _phoneNumber;
        public string EmailAddress { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public String PassportNumber { get; set; }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public GenderEnum Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public AgeEnum Age
        {
            get => _age;
            set => _age = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }

        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }
    }
}