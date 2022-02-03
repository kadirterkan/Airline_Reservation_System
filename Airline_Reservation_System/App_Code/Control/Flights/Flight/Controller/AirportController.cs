using Control.Flights.Flight.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// AirportController için özet açıklama
/// </summary>
public class AirportController : BaseController
{
    public AirportController()
    {

    }

    public List<Airport> GetAirportsByCountryId(Int64 countryId)
    {
        String commandText = @"SELECT * FROM AIRPORT WHERE COUNTRY_ID = @COUNTRY_ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@COUNTRY_ID",SqlDbType.BigInt);
        command.Parameters["@COUNTRY_ID"].Value = countryId;
        
        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        List<Airport> returnList = ReaderToList(reader);

        Connection.Close();

        return returnList;
    }

    public List<Airport> GetArrivalAirportsByAirportIdAndCountryId(Int64 airportId, Int64 countryId)
    {
        String commandText = @"SELECT * FROM AIRPORT INNER JOIN AVAILABLE_ROUTES as AR ON AIRPORT.ID = AR.AIRPORT2 WHERE AR.AIRPORT1 = @ID AND COUNTRY_ID = @COUNTRY_ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@COUNTRY_ID",SqlDbType.BigInt);
        command.Parameters.Add("@ID",SqlDbType.BigInt);
        command.Parameters["@COUNTRY_ID"].Value = countryId;
        command.Parameters["@ID"].Value = airportId;
        
        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        List<Airport> returnList = ReaderToList(reader);

        Connection.Close();

        return returnList;
    }

    public Airport GetAirportById(long id)
    {
        String commandText = @"SELECT * FROM AIRPORT AS AR INNER JOIN COUNTRY AS C ON AR.COUNTRY_ID = C.ID WHERE AR.ID = @ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters["@ID"].Value = id;

        return GetAirportById(command);
    }

    private Airport GetAirportById(SqlCommand command)
    {
        Connection.Open();
        
        SqlDataReader reader = command.ExecuteReader();

        reader.Read();
        
        Airport returnObject = ReaderToAirport(reader, ReaderToCountry(reader));
        
        Connection.Close();

        return returnObject;
    }

    public Boolean AddAirport(Airport airport)
    {
        String commandText = @"INSERT INTO AIRPORT (CREATION_DATE, UPDATE_DATE, IATA_CODE, AIRPORT_NAME, AIRPORT_CITY, COUNTRY_ID) VALUES (CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, @IATA, @NAME, @CITY, @CID)";

        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@IATA",SqlDbType.VarChar);
        command.Parameters.Add("@NAME",SqlDbType.VarChar);
        command.Parameters.Add("@CITY",SqlDbType.VarChar);
        command.Parameters.Add("@CID",SqlDbType.BigInt);
        command.Parameters["@IATA"].Value = airport.IATACode;
        command.Parameters["@NAME"].Value = airport.AirportName;
        command.Parameters["@CITY"].Value = airport.AirportCity;
        command.Parameters["@CID"].Value = airport.Country.ID;
        
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.InsertCommand = command;
        Connection.Open();
        if (adapter.InsertCommand.ExecuteNonQuery() > 0)
        {
            Connection.Close();
            return true;
        }
        else
        {
            Connection.Close();
            return false;
        }
    }
    public Boolean DeleteAirport(long airportID)
    {
        String commandText = @"DELETE FROM AIRPORT WHERE ID = @ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters["@ID"].Value = airportID;
        
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.DeleteCommand = command;
        Connection.Open();
        if (adapter.DeleteCommand.ExecuteNonQuery() > 0)
        {
            Connection.Close();
            return true;
        }
        else
        {
            Connection.Close();
            return false;
        }
    }

    public List<Airport> GetAirports()
    {
        String commandText = "SELECT * FROM AIRPORT AS AR INNER JOIN COUNTRY AS C ON AR.COUNTRY_ID = C.ID";
        SqlCommand command = new SqlCommand(commandText, Connection);

        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        List<Airport> returnList = ReaderToList(reader);

        Connection.Close();

        return returnList;
    }
    
    private List<Airport> ReaderToList(SqlDataReader reader)
    {
        List<Airport> destinationAirports = new List<Airport>();     
        
        while (reader.Read())
        {
            destinationAirports.Add(ReaderToAirport(reader,ReaderToCountry(reader)));
        }
        
        Connection.Close();

        return destinationAirports;
    }
    
    private Country ReaderToCountry(SqlDataReader reader)
    {
        Country country = new Country();
        
        country.ID = Convert.ToInt64(reader["COUNTRY_ID"]);
        country.CountryName = reader["COUNTRY.COUNTRY_NAME"].ToString();

        return country;
    }
    
    private Airport ReaderToAirport(SqlDataReader reader, Country country)
    {
        Airport airport = new Airport();
        
        airport.ID = Convert.ToInt64(reader["ID"]);
        airport.IATACode = reader["IATA_CODE"].ToString();
        airport.AirportCity = reader["AIRPORT_CITY"].ToString();
        airport.AirportName = reader["AIRPORT_NAME"].ToString();
        airport.Country = country;
        
        return airport;
    }
    public ListItem AirportToListItem(Airport airport)
    {
        ListItem listItem = new ListItem();
        listItem.Text = airport.AirportName;
        listItem.Value = airport.ID.ToString();

        return listItem;
    }
    
    public TableRow ToTableRow(Airport airport)
    {
        TableRow tableRow = new TableRow();
        
        TableCell ID = new TableCell();
        ID.Text = airport.ID.ToString();
        
        TableCell airportName = new TableCell();
        airportName.Text = airport.AirportName;

        TableCell airportCountry = new TableCell();
        airportCountry.Text = airport.Country.CountryName;

        TableCell airportCity = new TableCell();
        airportCity.Text = airport.AirportCity;

        TableCell airportIATA = new TableCell();
        airportIATA.Text = airport.IATACode;

        tableRow.Cells.Add(ID);
        tableRow.Cells.Add(airportName);
        tableRow.Cells.Add(airportCountry);
        tableRow.Cells.Add(airportCity);
        tableRow.Cells.Add(airportIATA);

        return tableRow;
    }
}