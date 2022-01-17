using System.ComponentModel.DataAnnotations.Schema;
using Control.Common;

namespace Control.Flights.Flight.Entities;

public class Airport : BaseEntity
{
    private Country _country;
    private string _airportName;
    private string _airportCity;
    private string _iataCode;

    public Country Country
    {
        get => _country;
        set => _country = value;
    }

    public string AirportName
    {
        get => _airportName;
        set => _airportName = value;
    }

    public string AirportCity
    {
        get => _airportCity;
        set => _airportCity = value;
    }

    public string IATACode
    {
        get => _iataCode;
        set => _iataCode = value;
    }
}