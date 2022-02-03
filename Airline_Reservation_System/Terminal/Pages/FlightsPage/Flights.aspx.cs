using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;

public partial class Terminal_Pages_TerminalFlightsPage_Flights : System.Web.UI.Page
{
    private Label PageTitle;
    private Label PageParagraph;
    private Button GetBtn;
    private Button AddBtn;
    private Table ContentTable;
    private TableHeaderRow TableContentRow;
    private PlaceHolder GenericAddEditModal;
    private Label ModalTitleLabel;
    private LinkButton BtnModalCloseHeader;
    private LinkButton BtnModalSubmitFooter;
    private LinkButton BtnModalCloseFooter;

    private static RoutesController _routesController = new RoutesController();
    private static FlightController _flightController = new FlightController();
    private static AirportController _airportController = new AirportController();
    private static ITicketController _ticketController = new TicketController();
    private static AircraftController _aircraftController = new AircraftController();

    protected void Page_Load(object sender, EventArgs e)
    {
        ReadyTheControls();
        FlightsPageContent.SetPageContent(PageTitle, PageParagraph, GetBtn, AddBtn, TableContentRow);

        GetBtn.Click += new EventHandler(OnClickGetFlights);
        AddBtn.Click += new EventHandler(OnClickOpenAddFlightModal);
        BtnModalCloseHeader.Click += new EventHandler(OnClickCloseFlightModal);
        BtnModalCloseFooter.Click += new EventHandler(OnClickCloseFlightModal);
        
        GetFlights();
    }

    private void ReadyTheControls()
    {
        ContentPlaceHolder contentPlaceHolder = Master.Master.Master.FindControl("ContentPlaceHolder1").FindControl("contents") as ContentPlaceHolder;

        PageTitle = (Label) contentPlaceHolder.FindControl("PageTitle");
        PageParagraph = (Label) contentPlaceHolder.FindControl("PageParagraph");
        GetBtn = contentPlaceHolder.FindControl("GetBtn") as Button;
        AddBtn = contentPlaceHolder.FindControl("AddBtn") as Button;
        ContentTable = contentPlaceHolder.FindControl("ContentTable") as Table;
        TableContentRow = contentPlaceHolder.FindControl("TableContentRow") as TableHeaderRow;
        GenericAddEditModal = contentPlaceHolder.FindControl("GenericAddEditModal") as PlaceHolder;
        ModalTitleLabel = contentPlaceHolder.FindControl("ModalTitleLabel") as Label;
        BtnModalCloseHeader = contentPlaceHolder.FindControl("btnModalCloseHeader") as LinkButton;
        BtnModalSubmitFooter = contentPlaceHolder.FindControl("btnModalSubmitFooter") as LinkButton;
        BtnModalCloseFooter = contentPlaceHolder.FindControl("btnModalCloseFooter") as LinkButton;
    }

    private void OnClickGetFlights(object sender, EventArgs e)
    {
        ClearList();
        GetFlights();
    }
    
    private void OnClickOpenAddFlightModal(object sender, EventArgs e)
    {
        GetRoutes();
        GetAircrafts();
        ModalTitleLabel.Text = "Add Flight";
        Application["mode"] = "ADD";
        GenericAddEditModal.Visible = true;
    }

    private void OnClickCloseFlightModal(object sender, EventArgs e)
    {
        GenericAddEditModal.Visible = false;
    }

    private void GetRoutes()
    {
        List<Routes> routesList = _routesController.GetRoutes();

        foreach (Routes routes in routesList)
        {
            ListItem listItem = new ListItem();
            listItem.Text = routes.DepartureAirport.AirportName + " " + routes.ArrivalAirport.AirportName;
            listItem.Value = routes.ID.ToString();
            
            routeList.Items.Add(listItem);
        }
    }

    private void GetAircrafts()
    {
        List<Aircraft> aircraftList = _aircraftController.GetAircrafts();
        
        foreach (Aircraft aircraft in aircraftList)
        {
            ListItem listItem = new ListItem();
            listItem.Text = aircraft.TailNumber;
            listItem.Value = aircraft.ID.ToString();
            
            airplaneList.Items.Add(listItem);
        }
    }
    private void GetFlights()
    {
        List<Flight> flights = _flightController.GetFlights();
        
        foreach (Flight flight in flights)
        {
            TableRow tableRow = _flightController.ToTableRow(flight);
            
            Button editButton = new Button();
            editButton.Text = "Edit Flight";
            editButton.Click += new EventHandler(EditFlight);
            TableCell editButtonCell = new TableCell();
            editButtonCell.Controls.Add(editButton);

            Button removeButton = new Button();
            removeButton.Text = "Remove Flight";
            removeButton.Click += new EventHandler(DeleteFlight);
            TableCell removeButtonCell = new TableCell();
            removeButtonCell.Controls.Add(removeButton);

            tableRow.Cells.Add(editButtonCell);
            tableRow.Cells.Add(removeButtonCell);

            ContentTable.Rows.Add(tableRow);
        }
    }
    
    private void DeleteFlight(object sender, EventArgs e)
    {
        using (Button button = sender as Button)
        {
            using (TableRow tableRow = button.Parent.Parent as TableRow)
            {
                if (_flightController.DeleteFlight(Convert.ToInt64(tableRow.Cells[0].Text)))
                {
                    MessageBox("Flight successfully deleted");
                }
                else
                {
                    MessageBox("Flight deletion has been declined");
                }
            }
        }
    }
    
    private void EditFlight(object sender, EventArgs e)
    {
        GetRoutes();
        GetAircrafts();
        ModalTitleLabel.Text = "Edit Flight";
        Application["mode"] = "EDIT";
        GenericAddEditModal.Visible = true;

        using (Button button = sender as Button)
        {
            using (TableRow tableRow = button.Parent.Parent as TableRow)
            {
                Flight flight = _flightController.GetFlightById(Convert.ToInt64(tableRow.Cells[0].Text));
                Application["editFlightId"] = tableRow.Cells[0].Text;
                flightNumberIn.Text = flight.FlightNumber;
                airplaneList.SelectedValue = flight.Aircraft.ID.ToString();
                airplaneNumberIn.Text = flight.Aircraft.TailNumber;
                routeList.SelectedValue = flight.FlightRoute.ID.ToString();
                routeIn.Text = _airportController.GetAirportById(flight.FlightRoute.DepartureAirport.ID).AirportName +
                               " " + _airportController.GetAirportById(flight.FlightRoute.ArrivalAirport.ID)
                                   .AirportName;
                departureDate.Text = flight.DepartureTime.ToString();
                flightLength.Text = flight.FlightTimeByMinutes.ToString();
                economyCapacity.Attributes.Add("min",flight.EcoCapacity.ToString());
                economyCapacity.Text = flight.EcoCapacity.ToString();
                businessCapacity.Attributes.Add("min",flight.BusCapacity.ToString());
                businessCapacity.Text = flight.BusCapacity.ToString();
                gateNo.Text = flight.GateNo;
            }
        }
    }
    
    private void AddRoute(object sender, EventArgs e)
    {
        Flight flight = new Flight();
        flight.FlightNumber = flightNumberIn.Text;
        flight.Aircraft = new Aircraft();
        flight.Aircraft.ID = Convert.ToInt64(airplaneList.SelectedValue);
        flight.FlightRoute = new Routes();
        flight.FlightRoute.ID = Convert.ToInt64(routeList.SelectedValue);
        flight.DepartureTime = Convert.ToDateTime(departureDate.Text);
        flight.FlightTimeByMinutes = Convert.ToInt32(flightLength.Text);
        flight.EcoCapacity = Convert.ToInt32(economyCapacity.Text);
        flight.BusCapacity = Convert.ToInt32(businessCapacity.Text);
        flight.GateNo = gateNo.Text;
        
        // TODO ADD DIFFERENT TYPE OF FLIGHTS
        flight.FlightType = "DIRECT";

        if (Application["mode"].Equals("ADD"))
        {
            if (_flightController.AddFlight(flight))
            {
                MessageBox("You have successfully added flight");
                GenericAddEditModal.Visible = false;
            }
            else
            {
                MessageBox("Something went wrong");
            }
        }else if (Application["mode"].Equals("EDIT"))
        {
            if (_flightController.EditFlight(flight, Application["editFlightId"].ToString()))
            {
                MessageBox("You have successfully edited flight");
                GenericAddEditModal.Visible = false;
            }
            else
            {
                MessageBox("Something went wrong");
            }
        }
    }
    
    private void ClearList()
    {
        ContentTable.Rows.Clear();

        ContentTable.Rows.Add(TableContentRow);
    }

    private void MessageBox(String message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }

    protected void routeList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        routeIn.Text = routeList.SelectedItem.Text;
    }

    protected void airplaneList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        airplaneNumberIn.Text = airplaneList.SelectedItem.Text;
    }
}