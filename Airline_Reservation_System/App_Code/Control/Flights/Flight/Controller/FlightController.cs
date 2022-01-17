using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Control.Flights.Flight.Entities;

public class FlightController : BaseController
{
    public FlightController()
    {
        
    }

    public List<Airport> GetDestinationsFromAirportId(long airportId)
    {
        string commandText = "SELECT COUNTRY.ID,COUNTRY_NAME,TO_AIRPORT_ID,AIRPORT_NAME,IATA_CODE,AIRPORT_CITY" + 
                             " FROM Available_Routes" + 
                             " INNER JOIN AIRPORT ON TO_AIRPORT_ID = AIRPORT.ID " +
                             " INNER JOIN COUNTRY ON AIRPORT.COUNTRY_ID = COUNTRY.ID" + 
                             " WHERE FROM_AIRPORT_ID = @ID;";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters["@ID"].Value = airportId;
        
        SqlDataReader reader = command.ExecuteReader();
        
        return ReaderToList(reader);
    }

    private List<Airport> ReaderToList(SqlDataReader reader)
    {
        List<Airport> destinationAirports = new List<Airport>();
        
        Connection.Open();
        
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
        
        country.ID = Convert.ToInt64(reader["COUNTRY.ID"]);
        country.CountryName = reader["COUNTRY_NAME"].ToString();

        return country;
    }

    private Airport ReaderToAirport(SqlDataReader reader, Country country)
    {
        Airport airport = new Airport();
        
        airport.ID = Convert.ToInt64(reader["TO_AIRPORT_ID"]);
        airport.IATACode = reader["IATA_CODE"].ToString();
        airport.AirportCity = reader["AIRPORT_CITY"].ToString();
        airport.AirportName = reader["AIRPORT_NAME"].ToString();
        airport.Country = country;

        return airport;
    }
}