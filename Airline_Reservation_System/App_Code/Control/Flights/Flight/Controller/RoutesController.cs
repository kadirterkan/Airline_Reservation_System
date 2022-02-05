using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;


public class RoutesController : BaseController
{
    private AirportController _airportController = new AirportController();

    public Int64 GetRouteIdWithAirports(Int64 airport1, Int64 airport2)
    {
        String commandText = @"SELECT ID FROM AVAILABLE_ROUTES as AR WHERE AIRPORT1 = @AIRPORT1 AND AIRPORT2 = @AIRPORT2";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@AIRPORT1", SqlDbType.BigInt);
        command.Parameters.Add("@AIRPORT2", SqlDbType.BigInt);
        command.Parameters["@AIRPORT1"].Value = airport1;
        command.Parameters["@AIRPORT2"].Value = airport2;

        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        reader.Read();

        Int64 returnValue = Convert.ToInt64(reader["ID"]);
        
        Connection.Close();

        return returnValue;
    }
    
    public Boolean AddRoute(Routes routes)
    {
        String commandText =
            @"INSERT INTO AVAILABLE_ROUTES (CREATION_DATE, UPDATE_DATE, AIRPORT1, AIRPORT2) VALUES(CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, @AIRPORT1, @AIRPORT2)";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@AIRPORT1", SqlDbType.BigInt);
        command.Parameters.Add("@AIRPORT2", SqlDbType.BigInt);
        command.Parameters["@AIRPORT1"].Value = routes.DepartureAirport.ID;
        command.Parameters["@AIRPORT2"].Value = routes.ArrivalAirport.ID;

        return AddRoute(command);
    }

    private Boolean AddRoute(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.InsertCommand = command;

        Connection.Open();

        int returnValue = adapter.InsertCommand.ExecuteNonQuery();

        Connection.Close();

        return returnValue > 0;
    }

    public Boolean DeleteRoute(long ID)
    {
        String commandText = @"DELETE FROM AVAILABLE_ROUTES WHERE ID = @ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters["@ID"].Value = ID;

        return DeleteRoute(command);
    }

    private Boolean DeleteRoute(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.DeleteCommand = command;

        Connection.Open();

        int returnValue = adapter.DeleteCommand.ExecuteNonQuery();

        Connection.Close();

        return returnValue > 0;
    }

    public List<Routes> GetRoutes()
    {
        String commandText = "SELECT * FROM AVAILABLE_ROUTES";

        SqlCommand command = new SqlCommand(commandText, Connection);

        return CommandToRoutesList(command);
    }

    private List<Routes> CommandToRoutesList(SqlCommand command)
    {
        List<Routes> routes = new List<Routes>();

        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            routes.Add(ReaderToRoutes(reader));
        }

        Connection.Close();

        foreach (Routes route in routes)
        {
            route.ArrivalAirport = _airportController.GetAirportById(route.ArrivalAirport.ID);
            route.DepartureAirport = _airportController.GetAirportById(route.DepartureAirport.ID);
        }

        return routes;
    }

    private Routes ReaderToRoutes(SqlDataReader reader)
    {
        Routes route = new Routes();

        route.ID = Convert.ToInt64(reader["ID"]);
        route.DepartureAirport.ID = Convert.ToInt64(reader["AIRPORT1"]);
        route.ArrivalAirport.ID = Convert.ToInt64(reader["AIRPORT2"]);

        return route;
    }

    public TableRow ToTableRow(Routes routes)
    {
        TableRow tableRow = new TableRow();

        TableCell ID = new TableCell();
        ID.Text = routes.ID.ToString();

        TableCell fromAirport = new TableCell();
        fromAirport.Text = routes.DepartureAirport.AirportName;

        TableCell fromAirportCountry = new TableCell();
        fromAirportCountry.Text = routes.DepartureAirport.Country.CountryName;

        TableCell toAirport = new TableCell();
        toAirport.Text = routes.ArrivalAirport.AirportName;

        TableCell toAirportCountry = new TableCell();
        toAirportCountry.Text = routes.ArrivalAirport.Country.CountryName;

        tableRow.Cells.Add(ID);
        tableRow.Cells.Add(fromAirport);
        tableRow.Cells.Add(fromAirportCountry);
        tableRow.Cells.Add(toAirport);
        tableRow.Cells.Add(toAirportCountry);

        return tableRow;
    }
}