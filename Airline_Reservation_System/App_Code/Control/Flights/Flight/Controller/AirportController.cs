﻿using Control.Flights.Flight.Entities;
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
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
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
        
        return destinationAirports;
    }

    
    private Country ReaderToCountry(SqlDataReader reader)
    {
        Country country = new Country();
        
        country.ID = Convert.ToInt64(reader["COUNTRY_ID"]);
        country.CountryName = reader["COUNTRY_NAME"].ToString();

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