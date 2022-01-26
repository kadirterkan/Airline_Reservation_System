using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Control.Common;
using Control.Flights.Flight.Entities;

/// <summary>
/// Routes için özet açıklama
/// </summary>
public class Routes : BaseEntity
{
    public Airport DepartureAirport { get; set; }
    public Airport ArrivalAirport { get; set; }
    
    public Routes()
    {
        
    }
}