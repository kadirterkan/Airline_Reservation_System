using System;
using System.Collections.Generic;
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
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
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