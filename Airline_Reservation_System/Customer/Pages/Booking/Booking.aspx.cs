using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Control.Flights.Customer.Ticket;
using Control.Flights.Flight.Entities;

public partial class Customer_Pages_Booking_Booking : System.Web.UI.Page
{
    private FlightController _flightController = new FlightController();
    private RoutesController _routesController = new RoutesController();

    protected void Page_Load(object sender, EventArgs e)
    {
        // dateOfFlight.Text = DateTime.Now.ToString("MMMM dd yyyy",new CultureInfo("us-US"));
        GetDate();
    }

    private void GetDate()
    {
        BookingPageContent.SetPageContent(TableContentRow);

        dateOfFlight.Text = Convert.ToDateTime(Application["departureDate"]).ToString("MMMM dd yyyy",new CultureInfo("us-US"));
        String departureAirportIdString = Application["departureAirportId"].ToString();
        Int64 departureAirportId = Convert.ToInt64(departureAirportIdString);
        String arrivalAirportIdString = Application["arrivalAirportId"].ToString();
        Int64 arrivalAirportId = Convert.ToInt64(arrivalAirportIdString);
        Application["routeId"] = _routesController.GetRouteIdWithAirports(departureAirportId, arrivalAirportId).ToString();

        GetFlights();
    }

    private void GetFlights()
    {
        ClearList();
        String flightClass = Application["flightClass"].ToString();
        int passengerCount = Convert.ToInt32(Application["childrenCount"]) + Convert.ToInt32(Application["adultCount"]);

        foreach (Flight flight in _flightController.GetFlightsByDateAndRouteId(Convert.ToDateTime(Application["departureDate"]),Convert.ToInt64(Application["routeId"])))
        {
            // Components_FlightCard userControl = new Components_FlightCard();
            // userControl.Flight = flight;
            TableRow tableRow = _flightController.ToTableRowForBooking(flight);

            TableCell tableCell = new TableCell();
            Button button = new Button();
            button.Text = "Checkout";
            tableCell.Controls.Add(button);

            tableRow.Cells.Add(tableCell);

            Int32 count = 0;
            
            foreach (Ticket ticket in flight.Tickets)
            {
                if (ticket.FlightClass.Equals(flightClass))
                {
                    count++;
                }
            }
            
            if (flightClass == "BUSINESS")
            {
                if (flight.BusCapacity >= passengerCount + count)
                {
                    ContentTable.Rows.Add(tableRow);
                }
            } else if (flightClass == "ECONOMY")
            {
                Boolean test = flight.EcoCapacity >= passengerCount + count;
                if (flight.EcoCapacity >= passengerCount + count)
                {
                    ContentTable.Rows.Add(tableRow);
                }
            }
        }
    }

    private void OnFlightSelected(object sender, EventArgs e)
    {
        using (Button button = sender as Button)
        {
            using (TableRow tableRow = button.Parent.Parent as TableRow)
            {
                Application["flightId"] = tableRow.Cells[0].Text;
                Response.Redirect("../Reservation/Reservation.aspx");
            }
        }
    }
    
    private void ClearList()
    {
        ContentTable.Rows.Clear();

        ContentTable.Rows.Add(TableContentRow);
    }

    protected void OnClickAddDay(object sender, EventArgs e)
    {
        DateTime dateTime = Convert.ToDateTime(dateOfFlight.Text,new CultureInfo("us-US"));
        dateTime = dateTime.AddDays(1.0);
        Application["departureDate"] = dateTime.ToString("MMMM dd yyyy",new CultureInfo("us-US"));
    }
    
    protected void OnClickDecreaseDay(object sender, EventArgs e)
    {
        DateTime dateTime = Convert.ToDateTime(dateOfFlight.Text,new CultureInfo("us-US"));
        dateTime = dateTime.AddDays(-1.0);
        Application["departureDate"] = dateTime.ToString("MMMM dd yyyy",new CultureInfo("us-US"));
    }
}