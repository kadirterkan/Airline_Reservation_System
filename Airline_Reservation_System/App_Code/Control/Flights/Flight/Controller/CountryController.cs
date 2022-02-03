using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;

/// <summary>
/// CountryController için özet açıklama
/// </summary>
public class CountryController : BaseController
{
    public CountryController()
    {
    }

    public List<Country> GetArrivalCountriesByAirportId(Int64 airportId)
    {
        String commandText = @"SELECT * FROM COUNTRY INNER JOIN AIRPORT ON AIRPORT.COUNTRY_ID = COUNTRY.ID INNER JOIN AVAILABLE_ROUTES ON AIRPORT2.ID = AIRPORT.ID WHERE AVAILABLE_ROUTES.AIRPORT2 = @ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@ID",SqlDbType.BigInt);
        command.Parameters["@ID"].Value = airportId;

        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        List<Country> returnList = ReaderToCountryList(reader);
        
        Connection.Close();

        return returnList;
    }

    public List<Country> GetCountries()
    {
        String commandText = "SELECT * FROM COUNTRY";

        SqlCommand command = new SqlCommand(commandText, Connection);
        
        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        List<Country> returnList = ReaderToCountryList(reader);
        
        Connection.Close();

        return returnList;
    }

    private List<Country> ReaderToCountryList(SqlDataReader reader)
    {
        List<Country> countries = new List<Country>();

        while (reader.Read())
        {
            countries.Add(ReaderToCountry(reader));
        }

        return countries;
    }
    
    private Country ReaderToCountry(SqlDataReader reader)
    {
        Country country = new Country();
        
        country.ID = Convert.ToInt64(reader["ID"]);
        country.CountryName = reader["COUNTRY_NAME"].ToString();

        return country;
    }

    public ListItem CountryToListItem(Country country)
    {
        ListItem listItem = new ListItem();

        listItem.Text = country.CountryName;
        listItem.Value = country.ID.ToString();

        return listItem;
    }
}