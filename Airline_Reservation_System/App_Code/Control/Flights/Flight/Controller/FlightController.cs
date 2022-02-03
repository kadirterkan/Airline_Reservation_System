using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;

public class FlightController : BaseController
{
    private static AirportController _airportController = new AirportController();
    private static ITicketController _ticketController = new TicketController();
    public FlightController()
    {
        
    }

    public Boolean AddFlight(Flight flight)
    {
        String commandText = @"INSERT INTO FLIGHT (CREATION_DATE, UPDATE_DATE, FLIGHT_NUMBER, FLIGHT_TIME_BY_MINUTES, GATE_NO, FLIGHT_TYPE, FLIGHT_ECONOMY_CAPACITY, FLIGHT_BUSINESS_CAPACITY, DEPARTURE_TIME, AIRCRAFT_ID, AVAILABLE_ROUTES_ID) VALUES(CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, @FLIGHT_NUMBER, @FLIGHT_TIME_BY_MINUTES, @GATE_NO, @FLIGHT_TYPE, @FLIGHT_ECONOMY_CAPACITY, @FLIGHT_BUSINESS_CAPACITY, @DEPARTURE_TIME, @AIRCRAFT_ID, @AVAILABLE_ROUTES_ID);";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@FLIGHT_NUMBER", SqlDbType.VarChar);
        command.Parameters.Add("@FLIGHT_TIME_BY_MINUTES", SqlDbType.Int);
        command.Parameters.Add("@GATE_NO", SqlDbType.VarChar);
        command.Parameters.Add("@FLIGHT_TYPE", SqlDbType.VarChar);
        command.Parameters.Add("@FLIGHT_ECONOMY_CAPACITY", SqlDbType.Int);
        command.Parameters.Add("@FLIGHT_BUSINESS_CAPACITY", SqlDbType.Int);
        command.Parameters.Add("@DEPARTURE_TIME", SqlDbType.DateTime);
        command.Parameters.Add("@AIRCRAFT_ID", SqlDbType.BigInt);
        command.Parameters.Add("@AVAILABLE_ROUTES_ID", SqlDbType.BigInt);
        command.Parameters["@FLIGHT_NUMBER"].Value = flight.FlightNumber;
        command.Parameters["@FLIGHT_TIME_BY_MINUTES"].Value = flight.FlightTimeByMinutes;
        command.Parameters["@GATE_NO"].Value = flight.GateNo;
        command.Parameters["@FLIGHT_TYPE"].Value = flight.FlightType;
        command.Parameters["@FLIGHT_ECONOMY_CAPACITY"].Value = flight.EcoCapacity;
        command.Parameters["@FLIGHT_BUSINESS_CAPACITY"].Value = flight.BusCapacity;
        command.Parameters["@DEPARTURE_TIME"].Value = flight.DepartureTime;
        command.Parameters["@AIRCRAFT_ID"].Value = flight.Aircraft.ID;
        command.Parameters["@AVAILABLE_ROUTES_ID"].Value = flight.FlightRoute.ID;

        return AddFlight(command);
    }

    private Boolean AddFlight(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.InsertCommand = command;
        
        Connection.Open();

        int returnValue = adapter.InsertCommand.ExecuteNonQuery();

        Connection.Close();

        return returnValue > 0;
    }

    public Boolean EditFlight(Flight flight, String id)
    {
        String commandText = @"UPDATE FLIGHT SET UPDATE_DATE = CURRENT_TIMESTAMP, FLIGHT_NUMBER = @FLIGHT_NUMBER, FLIGHT_TIME_BY_MINUTES = @FLIGHT_TIME_BY_MINUTES, GATE_NO = @GATE_NO, FLIGHT_TYPE = @FLIGHT_TYPE, FLIGHT_ECONOMY_CAPACITY = @FLIGHT_ECONOMY_CAPACITY, FLIGHT_BUSINESS_CAPACITY = @FLIGHT_BUSINESS_CAPACITY, DEPARTURE_TIME = @DEPARTURE_TIME, AIRCRAFT_ID = @AIRCRAFT_ID, AVAILABLE_ROUTES_ID = @AVAILABLE_ROUTES_ID WHERE ID = @ID;";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@FLIGHT_NUMBER", SqlDbType.VarChar);
        command.Parameters.Add("@FLIGHT_TIME_BY_MINUTES", SqlDbType.Int);
        command.Parameters.Add("@GATE_NO", SqlDbType.VarChar);
        command.Parameters.Add("@FLIGHT_TYPE", SqlDbType.VarChar);
        command.Parameters.Add("@FLIGHT_ECONOMY_CAPACITY", SqlDbType.Int);
        command.Parameters.Add("@FLIGHT_BUSINESS_CAPACITY", SqlDbType.Int);
        command.Parameters.Add("@DEPARTURE_TIME", SqlDbType.DateTime);
        command.Parameters.Add("@AIRCRAFT_ID", SqlDbType.BigInt);
        command.Parameters.Add("@AVAILABLE_ROUTES_ID", SqlDbType.BigInt);
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters["@FLIGHT_NUMBER"].Value = flight.FlightNumber;
        command.Parameters["@FLIGHT_TIME_BY_MINUTES"].Value = flight.FlightTimeByMinutes;
        command.Parameters["@GATE_NO"].Value = flight.GateNo;
        command.Parameters["@FLIGHT_TYPE"].Value = flight.FlightType;
        command.Parameters["@FLIGHT_ECONOMY_CAPACITY"].Value = flight.EcoCapacity;
        command.Parameters["@FLIGHT_BUSINESS_CAPACITY"].Value = flight.BusCapacity;
        command.Parameters["@DEPARTURE_TIME"].Value = flight.DepartureTime;
        command.Parameters["@AIRCRAFT_ID"].Value = flight.Aircraft.ID;
        command.Parameters["@AVAILABLE_ROUTES_ID"].Value = flight.FlightRoute.ID;
        command.Parameters["@ID"].Value = Convert.ToInt64(id);

        return EditFlight(command);
    }

    private Boolean EditFlight(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.UpdateCommand = command;
        
        Connection.Open();
        
        int returnValue = adapter.UpdateCommand.ExecuteNonQuery();
        
        Connection.Close();

        return returnValue > 0;
    }

    public Boolean DeleteFlight(long ID)
    {
        String commandText = @"DELETE FROM FLIGHT WHERE ID = @ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters["@ID"].Value = ID;

        return DeleteFlight(command);
    }

    private Boolean DeleteFlight(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.DeleteCommand = command;
        
        Connection.Open();

        int returnValue = adapter.DeleteCommand.ExecuteNonQuery();
        
        Connection.Close();

        return returnValue > 0;
    }

    public List<Flight> GetFlights()
    {
        String commandText = @"SELECT * FROM FLIGHT INNER JOIN AIRCRAFT ON FLIGHT.AIRCRAFT_ID = AIRCRAFT.ID INNER JOIN AVAILABLE_ROUTES ON FLIGHT.AVAILABLE_ROUTES_ID = AVAILABLE_ROUTES.ID;";

        SqlCommand command = new SqlCommand(commandText, Connection);

        return CommandToFlightList(command);
    }

    private List<Flight> CommandToFlightList(SqlCommand command)
    {
        List<Flight> flights = new List<Flight>();
        
        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            flights.Add(ReaderToFlight(reader));
        }
        
        Connection.Close();

        return flights;
    }

    private Flight ReaderToFlight(SqlDataReader reader)
    {
        Flight flight = new Flight();

        flight.ID = Convert.ToInt64(reader["ID"]);
        flight.FlightType = reader["FLIGHT_TYPE"].ToString();
        flight.DepartureTime = Convert.ToDateTime(reader["DEPARTURE_TIME"]);
        flight.FlightNumber = reader["FLIGHT_NUMBER"].ToString();
        flight.FlightTimeByMinutes = Convert.ToInt32(reader["FLIGHT_TIME_BY_MINUTES"]);
        flight.GateNo = reader["GATE_NO"].ToString();
        
        flight.FlightRoute = new Routes();
        flight.FlightRoute.ID = Convert.ToInt64(reader["AVAILABLE_ROUTES_ID"]);
        
        flight.FlightRoute.DepartureAirport = new Airport();
        flight.FlightRoute.DepartureAirport.ID = Convert.ToInt64(reader["AIRPORT1"]);

        flight.FlightRoute.ArrivalAirport = new Airport();
        flight.FlightRoute.ArrivalAirport.ID = Convert.ToInt64(reader["AIRPORT2"]);

        flight.Aircraft = new Aircraft();
        flight.Aircraft.ID = Convert.ToInt64(reader["AIRCRAFT_ID"]);
        flight.Aircraft.AircraftManufacturer = reader["AIRCRAFT_MANUFACTURER"].ToString();
        flight.Aircraft.AircraftModel = reader["AIRCRAFT_MODEL"].ToString();
        flight.Aircraft.TailNumber = reader["TAIL_NUMBER"].ToString();
        flight.Aircraft.DateOfManufacture = Convert.ToDateTime(reader["DATE_OF_MANUFACTURE"]);
        flight.Aircraft.OnActiveDuty = true;
        flight.Aircraft.PlaneBusinessCapacity = Convert.ToInt32(reader["PLANE_BUSINESS_CAPACITY"]); 
        flight.Aircraft.PlaneEconomyCapacity = Convert.ToInt32(reader["PLANE_ECONOMY_CAPACITY"]); 

        return flight;
    }

    public Flight GetFlightById(Int64 flightId)
    {
        String commandText = @"SELECT * FROM FLIGHT INNER JOIN AIRCRAFT ON FLIGHT.AIRCRAFT_ID = AIRCRAFT.ID INNER JOIN AVAILABLE_ROUTES ON FLIGHT.AVAILABLE_ROUTES_ID = AVAILABLE_ROUTES.ID WHERE FLIGHT.ID = @ID ;";
        SqlCommand command = new SqlCommand(commandText,Connection);
        command.Parameters.Add("@ID",SqlDbType.BigInt);
        command.Parameters["@ID"].Value = flightId;
        
        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        reader.Read();

        Flight returnValue = ReaderToFlight(reader);
        
        Connection.Close();
        
        return returnValue;
    }
    
    public TableRow ToTableRow(Flight flight)
    {
        TableRow tableRow = new TableRow();

        TableCell ID = new TableCell();
        ID.Text = flight.ID.ToString();
        
        TableCell flightNumber = new TableCell();
        flightNumber.Text = flight.FlightNumber;

        TableCell flightDepartureDate = new TableCell();
        flightDepartureDate.Text = flight.DepartureTime.ToString();

        TableCell departureAirportName = new TableCell();
        departureAirportName.Text = _airportController.GetAirportById(flight.FlightRoute.DepartureAirport.ID).AirportName;

        TableCell arrivalAirportName = new TableCell();
        arrivalAirportName.Text = _airportController.GetAirportById(flight.FlightRoute.ArrivalAirport.ID).AirportName;

        TableCell planeBusinessCapacity = new TableCell();
        planeBusinessCapacity.Text = _ticketController.GetAttenderCountByIdAndFlightClass(flight.ID, "BUSINESS").ToString();

        TableCell planeEconomyCapacity = new TableCell();
        planeBusinessCapacity.Text = _ticketController.GetAttenderCountByIdAndFlightClass(flight.ID, "ECONOMY").ToString();
        
        tableRow.Cells.Add(ID);
        tableRow.Cells.Add(flightNumber);
        tableRow.Cells.Add(flightDepartureDate);
        tableRow.Cells.Add(departureAirportName);
        tableRow.Cells.Add(arrivalAirportName);
        tableRow.Cells.Add(planeBusinessCapacity);
        tableRow.Cells.Add(planeEconomyCapacity);

        return tableRow;
    }
}