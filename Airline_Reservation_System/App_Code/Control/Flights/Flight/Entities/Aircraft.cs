using System;
using Control.Common;

namespace Control.Flights.Flight.Entities
{
    public class Aircraft : BaseEntity
{
    private string _tailNumber;
    private string _aircraftManufacturer;
    private string _aircraftModel;
    private DateTime _dateOfManufacture;
    private long _planeEconomyCapacity;
    private long _planeBusinessCapacity;

    public string TailNumber
    {
        get => _tailNumber;
        set => _tailNumber = value;
    }

    public string AircraftManufacturer
    {
        get => _aircraftManufacturer;
        set => _aircraftManufacturer = value;
    }

    public string AircraftModel
    {
        get => _aircraftModel;
        set => _aircraftModel = value;
    }

    public DateTime DateOfManufacture
    {
        get => _dateOfManufacture;
        set => _dateOfManufacture = value;
    }

    public long PlaneEconomyCapacity
    {
        get => _planeEconomyCapacity;
        set => _planeEconomyCapacity = value;
    }

    public long PlaneBusinessCapacity
    {
        get => _planeBusinessCapacity;
        set => _planeBusinessCapacity = value;
    }
}
}

