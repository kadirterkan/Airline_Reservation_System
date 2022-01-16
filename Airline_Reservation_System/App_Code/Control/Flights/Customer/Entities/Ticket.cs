using System.ComponentModel.DataAnnotations.Schema;
using Control.Common;

namespace Control.Flights.Customer.Ticket;

public class Ticket : BaseEntity
{
    private Flight.Entities.Flight _flight;
    private Passenger.Passenger _passenger;
    private string _passengerSeat;
    private string _paymentMethod;

    public Flight.Entities.Flight FlightId
    {
        get => _flight;
        set => _flight = value;
    }

    public Passenger.Passenger PassengerId
    {
        get => _passenger;
        set => _passenger = value;
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