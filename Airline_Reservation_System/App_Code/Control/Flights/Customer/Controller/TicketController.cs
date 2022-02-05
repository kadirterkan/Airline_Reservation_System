using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Control.Flights.Customer.Ticket;
using Control.Flights.Flight.Entities;
using Control.Passenger;
using NHibernate.Type;


public interface ITicketController
{
    Boolean AddTicketsByPassengerListAndFlightIdAndFlightClassAndUserId(List<Passenger> passengers, Int64 flightId, String flightClass, Int64 userId);
    
    Int32 GetAttenderCountByIdAndFlightClass(Int64 flightId, String flightClass);

    List<Ticket> GetTicketsByFlightId(Int64 flightId);

    List<Ticket> GetTicketsByUserId(Int64 userId);
}

public class TicketController : BaseController, ITicketController
{
    private PassengerController _passengerController = new PassengerController();

    private FlightController _flightController = new FlightController();

    private AirportController _airportController = new AirportController();
    
    public Boolean AddTicketsByPassengerListAndFlightIdAndFlightClassAndUserId(List<Passenger> passengers, Int64 flightId, String flightClass, Int64 userId)
    { 
        
        String commandText = @"INSERT INTO TICKET(CREATION_DATE, UPDATE_DATE, PASSENGER_SEAT, FLIGHT_CLASS, FLIGHT_ID, PASSENGER_ID, USER_ID) VALUES (CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, @PASSENGER_SEAT, @FLIGHT_CLASS, @FLIGHT_ID, IDENT_CURRENT('PASSENGER'), @USER_ID)";

        foreach (Passenger passenger in passengers)
        {
            _passengerController.AddPassenger(passenger);

            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@PASSENGER_SEAT", SqlDbType.VarChar);
            command.Parameters.Add("@FLIGHT_CLASS", SqlDbType.VarChar);
            command.Parameters.Add("@FLIGHT_ID", SqlDbType.BigInt);
            command.Parameters.Add("@USER_ID", SqlDbType.BigInt);
            command.Parameters["@PASSENGER_SEAT"].Value = Convert.ToString(GetAttenderCountByIdAndFlightClass(flightId, flightClass) + 1);
            command.Parameters["@FLIGHT_CLASS"].Value = flightClass;
            command.Parameters["@FLIGHT_ID"].Value = flightId;
            command.Parameters["@USER_ID"].Value = userId;

            if (!AddTicket(command))
            {
                return false;
            }
        }

        return true;
    }
    
    private Boolean AddTicket(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.InsertCommand = command;
        
        Connection.Open();

        int returnValue = adapter.InsertCommand.ExecuteNonQuery();

        Connection.Close();

        return returnValue > 0;
    }

    public List<Ticket> GetTicketsByUserId(Int64 userId)
    {
        String commandText = @"SELECT * FROM TICKET WHERE TICKET.USER_ID = @USER_ID;";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@USER_ID", SqlDbType.BigInt);
        command.Parameters["@USER_ID"].Value = userId;
        
        return CommandToTickets(command);
    }

    public Int32 GetAttenderCountByIdAndFlightClass(Int64 flightId, String flightClass)
    {
        String commandText = @"SELECT COUNT(*) FROM TICKET WHERE FLIGHT_ID = @FLIGHT_ID AND FLIGHT_CLASS = @FLIGHT_CLASS;";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@FLIGHT_ID", SqlDbType.BigInt);
        command.Parameters.Add("@FLIGHT_CLASS", SqlDbType.VarChar);
        command.Parameters["@FLIGHT_ID"].Value = flightId;
        command.Parameters["@FLIGHT_CLASS"].Value = flightClass;

        Connection.Open();
        
        Int32 returnValue = Convert.ToInt32(command.ExecuteScalar());
        
        Connection.Close();
        
        return returnValue;
    }

    public List<Ticket> GetTicketsByFlightId(Int64 flightId)
    {
        String commandText = @"SELECT * FROM TICKET WHERE FLIGHT_ID = @FLIGHT_ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@FLIGHT_ID", SqlDbType.BigInt);
        command.Parameters["@FLIGHT_ID"].Value = flightId;

        return CommandToTickets(command);
    }
    
    private List<Ticket> CommandToTickets(SqlCommand command)
    {
        List<Ticket> tickets = new List<Ticket>();
        
        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            tickets.Add(ReaderToTicket(reader));
        }
        
        Connection.Close();

        return tickets;
    }

    private Ticket ReaderToTicket(SqlDataReader reader)
    {
        Ticket ticket = new Ticket();

        ticket.ID = Convert.ToInt64(reader["ID"]);

        ticket.FlightClass = reader["FLIGHT_CLASS"].ToString();

        ticket.PassengerSeat = reader["PASSENGER_SEAT"].ToString();

        ticket.Flight = new Flight();
        ticket.Flight.ID = Convert.ToInt64(reader["FLIGHT_ID"]);

        ticket.Passenger = new Passenger();
        ticket.Passenger.ID = Convert.ToInt64(reader["PASSENGER_ID"]);

        return ticket;
    }
    
    public TableRow ToTableRow(Ticket ticket)
    {
        TableRow tableRow = new TableRow();

        ticket.Passenger = _passengerController.GetPassengerByPassengerId(ticket.Passenger.ID);
        ticket.Flight = _flightController.GetFlightById(ticket.Flight.ID);
        
        TableCell ID = new TableCell();
        ID.Text = ticket.ID.ToString();
        
        TableCell passengerName = new TableCell();
        passengerName.Text = ticket.Passenger.FirstLastName;

        TableCell passportNumber = new TableCell();
        passportNumber.Text = ticket.Passenger.PassportNumber;

        TableCell flightClass = new TableCell();
        flightClass.Text = ticket.FlightClass;
            
        TableCell flightNumber = new TableCell();
        flightNumber.Text = ticket.Flight.FlightNumber;

        TableCell departureAirportName = new TableCell();
        departureAirportName.Text = _airportController.GetAirportById(ticket.Flight.FlightRoute.DepartureAirport.ID).AirportName;

        TableCell departureTime = new TableCell();
        departureTime.Text = ticket.Flight.DepartureTime.ToString();
            
        TableCell arrivalAirportName = new TableCell();
        arrivalAirportName.Text = _airportController.GetAirportById(ticket.Flight.FlightRoute.ArrivalAirport.ID).AirportName;
        
        tableRow.Cells.Add(ID);
        tableRow.Cells.Add(passengerName);
        tableRow.Cells.Add(passportNumber);
        tableRow.Cells.Add(flightClass);
        tableRow.Cells.Add(flightNumber);
        tableRow.Cells.Add(departureAirportName);
        tableRow.Cells.Add(departureTime);
        tableRow.Cells.Add(arrivalAirportName);

        return tableRow;
    }

}