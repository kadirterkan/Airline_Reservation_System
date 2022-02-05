using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;

public partial class Components_FlightCard : System.Web.UI.UserControl
{
    
    public Flight Flight { get; set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        linkButton = new LinkButton();
        departureTime = new Label();
        departureAirport = new Label();
        flightDuration = new Label();
        arrivalTime = new Label();
        arrivalAirport = new Label();
        flightNumber = new Label();
        flightType = new Label();
        flightPrice = new Label();
        linkButton.ID = Flight.ID.ToString();
        this.ID = Flight.ID.ToString();
        departureTime.Text = Flight.DepartureTime.ToString("HH:MM");
        departureAirport.Text = Flight.FlightRoute.DepartureAirport.AirportName;
        flightDuration.Text = TimeSpan.FromMinutes(Flight.FlightTimeByMinutes).ToString();
        arrivalTime.Text = Flight.DepartureTime.ToString("HH:MM");
        arrivalAirport.Text = Flight.FlightRoute.ArrivalAirport.AirportName;
        flightNumber.Text = Flight.FlightNumber;
        flightType.Text = Flight.FlightType;
        flightPrice.Text = Flight.FlightPrice.ToString();
    }
}