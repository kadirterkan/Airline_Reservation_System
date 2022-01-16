using System;
using System.Collections.Generic;
using Control.Common;
using Control.Enum_Like;
using Control.Flights.Customer.Ticket;

namespace Control.Passenger;

public class Passenger : BaseEntity
{
    private string _firstName;
    private string _lastName;
    private GenderEnum _gender;
    private long _age;
    private string _phoneNumber;
    private string _address;
    private ICollection<Ticket> Tickets { get; set; }
    
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

    public long Age
    {
        get => _age;
        set => _age = value;
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = value;
    }

    public string Address
    {
        get => _address;
        set => _address = value;
    }
    
    public void AddTicket(in Ticket ticket) {
        Tickets.Add(ticket);
    }
}