using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;

/// <summary>
/// AircraftController için özet açıklama
/// </summary>
public class AircraftController : BaseController
{
    public AircraftController()
    {

    }

    public Boolean AddAircraft(Aircraft aircraft)
    {
        String commandText = @"INSERT INTO AIRCRAFT (CREATION_DATE, UPDATE_DATE, TAIL_NUMBER, AIRCRAFT_MANUFACTURER, AIRCRAFT_MODEL, DATE_OF_MANUFACTURE, PLANE_BUSINESS_CAPACITY, PLANE_ECONOMY_CAPACITY) VALUES(CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, @TAIL_NUMBER, @AIRCRAFT_MANUFACTURER, @AIRCRAFT_MODEL, @DATE_OF_MANUFACTURE, @PLANE_BUSINESS_CAPACITY, @PLANE_ECONOMY_CAPACITY)";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@TAIL_NUMBER", SqlDbType.VarChar);
        command.Parameters.Add("@AIRCRAFT_MANUFACTURER", SqlDbType.VarChar);
        command.Parameters.Add("@AIRCRAFT_MODEL", SqlDbType.VarChar);
        command.Parameters.Add("@DATE_OF_MANUFACTURE", SqlDbType.DateTime);
        command.Parameters.Add("@PLANE_BUSINESS_CAPACITY", SqlDbType.Int);
        command.Parameters.Add("@PLANE_ECONOMY_CAPACITY", SqlDbType.Int);
        command.Parameters["@TAIL_NUMBER"].Value = aircraft.TailNumber;
        command.Parameters["@AIRCRAFT_MANUFACTURER"].Value = aircraft.AircraftManufacturer;
        command.Parameters["@AIRCRAFT_MODEL"].Value = aircraft.AircraftModel;
        command.Parameters["@DATE_OF_MANUFACTURE"].Value = aircraft.DateOfManufacture;
        command.Parameters["@PLANE_BUSINESS_CAPACITY"].Value = aircraft.PlaneBusinessCapacity;
        command.Parameters["@PLANE_ECONOMY_CAPACITY"].Value = aircraft.PlaneEconomyCapacity;

        return AddAircraft(command);
    }

    private Boolean AddAircraft(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.InsertCommand = command;
        
        Connection.Open();

        int returnValue = adapter.InsertCommand.ExecuteNonQuery();

        Connection.Close();

        return returnValue > 0;
    }

    public Boolean EditAircraft(Aircraft aircraft, String id)
    {
        String commandText = @"UPDATE AIRCRAFT SET UPDATE_DATE = CURRENT_TIMESTAMP, AIRCRAFT_MANUFACTURER = @AIRCRAFT_MANUFACTURER, AIRCRAFT_MODEL = @AIRCRAFT_MODEL, DATE_OF_MANUFACTURE = @DATE_OF_MANUFACTURE, PLANE_BUSINESS_CAPACITY = @PLANE_BUSINESS_CAPACITY, PLANE_ECONOMY_CAPACITY = @PLANE_ECONOMY_CAPACITY WHERE ID = @ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@TAIL_NUMBER", SqlDbType.VarChar);
        command.Parameters.Add("@AIRCRAFT_MANUFACTURER", SqlDbType.VarChar);
        command.Parameters.Add("@AIRCRAFT_MODEL", SqlDbType.VarChar);
        command.Parameters.Add("@DATE_OF_MANUFACTURE", SqlDbType.DateTime);
        command.Parameters.Add("@PLANE_BUSINESS_CAPACITY", SqlDbType.Int);
        command.Parameters.Add("@PLANE_ECONOMY_CAPACITY", SqlDbType.Int);
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters["@TAIL_NUMBER"].Value = aircraft.TailNumber;
        command.Parameters["@AIRCRAFT_MANUFACTURER"].Value = aircraft.AircraftManufacturer;
        command.Parameters["@AIRCRAFT_MODEL"].Value = aircraft.AircraftModel;
        command.Parameters["@DATE_OF_MANUFACTURE"].Value = aircraft.DateOfManufacture;
        command.Parameters["@PLANE_BUSINESS_CAPACITY"].Value = aircraft.PlaneBusinessCapacity;
        command.Parameters["@PLANE_ECONOMY_CAPACITY"].Value = aircraft.PlaneEconomyCapacity;
        command.Parameters["@ID"].Value = id;

        return EditAircraft(command);
    }

    private Boolean EditAircraft(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.UpdateCommand = command;
        
        Connection.Open();
        
        int returnValue = adapter.UpdateCommand.ExecuteNonQuery();
        
        Connection.Close();

        return returnValue > 0;
    }

    public Boolean DeleteAircraft(long ID)
    {
        String commandText = @"DELETE FROM AIRCRAFT WHERE ID = @ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters["@ID"].Value = ID;

        return DeleteAircraft(command);
    }

    private Boolean DeleteAircraft(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.DeleteCommand = command;
        
        Connection.Open();

        int returnValue = adapter.DeleteCommand.ExecuteNonQuery();
        
        Connection.Close();

        return returnValue > 0;
    }

    public List<Aircraft> GetAircrafts()
    {
        String commandText = "SELECT * FROM AIRCRAFT";

        SqlCommand command = new SqlCommand(commandText, Connection);

        return CommandToAircraftList(command);
    }

    private List<Aircraft> CommandToAircraftList(SqlCommand command)
    {
        List<Aircraft> countries = new List<Aircraft>();
        
        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            countries.Add(ReaderToCountry(reader));
        }
        
        Connection.Close();

        return countries;
    }

    private Aircraft ReaderToCountry(SqlDataReader reader)
    {
        Aircraft aircraft = new Aircraft();

        aircraft.ID = Convert.ToInt64(reader["ID"]);
        aircraft.AircraftManufacturer = reader["AIRCRAFT_MANUFACTURER"].ToString();
        aircraft.AircraftModel = reader["AIRCRAFT_MODEL"].ToString();
        aircraft.TailNumber = reader["TAIL_NUMBER"].ToString();
        aircraft.DateOfManufacture = Convert.ToDateTime(reader["DATE_OF_MANUFACTURE"]);
        aircraft.PlaneBusinessCapacity = Convert.ToInt32(reader["PLANE_BUSINESS_CAPACITY"]);
        aircraft.PlaneEconomyCapacity = Convert.ToInt32(reader["PLANE_ECONOMY_CAPACITY"]);

        return aircraft;
    }

    public TableRow ToTableRow(Aircraft aircraft)
    {
        TableRow tableRow = new TableRow();

        TableCell ID = new TableCell();
        ID.Text = aircraft.ID.ToString();
        
        TableCell aircraftTailNumber = new TableCell();
        aircraftTailNumber.Text = aircraft.TailNumber;

        TableCell aircraftManufacturer = new TableCell();
        aircraftManufacturer.Text = aircraft.AircraftManufacturer;

        TableCell aircraftModel = new TableCell();
        aircraftModel.Text = aircraft.AircraftModel;

        TableCell dateOfManufacture = new TableCell();
        dateOfManufacture.Text = aircraft.DateOfManufacture.ToString("dd.MM.yyyy");

        TableCell planeBusinessCapacity = new TableCell();
        planeBusinessCapacity.Text = aircraft.PlaneBusinessCapacity.ToString();

        TableCell planeEconomyCapacity = new TableCell();
        planeEconomyCapacity.Text = aircraft.PlaneEconomyCapacity.ToString();
        
        tableRow.Cells.Add(ID);
        tableRow.Cells.Add(aircraftTailNumber);
        tableRow.Cells.Add(aircraftManufacturer);
        tableRow.Cells.Add(aircraftModel);
        tableRow.Cells.Add(dateOfManufacture);
        tableRow.Cells.Add(planeBusinessCapacity);
        tableRow.Cells.Add(planeEconomyCapacity);

        return tableRow;
    }
}