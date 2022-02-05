using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Control.Passenger;

/// <summary>
/// PassengerController için özet açıklama
/// </summary>
public class PassengerController : BaseController
{
    public PassengerController()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }

    public Boolean AddPassenger(Passenger passenger)
    {
        String commandText = @"INSERT INTO PASSENGER(CREATION_DATE, UPDATE_DATE, FIRST_LAST_NAME, PASSPORT_NUMBER, GENDER, AGE, PHONE_NUMBER, EMAIL_ADDRESS) VALUES(CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, @FIRST_LAST_NAME, @PASSPORT_NUMBER, @GENDER, @AGE, @PHONE_NUMBER, @EMAIL_ADDRESS);";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@FIRST_LAST_NAME", SqlDbType.VarChar);
        command.Parameters.Add("@PASSPORT_NUMBER", SqlDbType.VarChar);
        command.Parameters.Add("@GENDER", SqlDbType.VarChar);
        command.Parameters.Add("@AGE", SqlDbType.VarChar);
        command.Parameters.Add("@PHONE_NUMBER", SqlDbType.VarChar);
        command.Parameters.Add("@EMAIL_ADDRESS", SqlDbType.VarChar);
        command.Parameters["@FIRST_LAST_NAME"].Value = passenger.FirstLastName;
        command.Parameters["@PASSPORT_NUMBER"].Value = passenger.PassportNumber;
        command.Parameters["@GENDER"].Value = passenger.Gender;
        command.Parameters["@AGE"].Value = passenger.Age;
        command.Parameters["@PHONE_NUMBER"].Value = passenger.PhoneNumber;
        command.Parameters["@EMAIL_ADDRESS"].Value = passenger.EmailAddress;

        return AddPassenger(command);
    }
    
    private Boolean AddPassenger(SqlCommand command)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();

        adapter.InsertCommand = command;
        
        Connection.Open();

        int returnValue = adapter.InsertCommand.ExecuteNonQuery();

        Connection.Close();

        return returnValue > 0;
    }

    public Passenger GetPassengerByPassengerId(Int64 passengerId)
    {
        String commandText = @"SELECT * FROM PASSENGER WHERE ID = @PASSENGER_ID";
        SqlCommand command = new SqlCommand(commandText, Connection);
        command.Parameters.Add("@PASSENGER_ID", SqlDbType.BigInt);
        command.Parameters["@PASSENGER_ID"].Value = passengerId;
        
        Connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        reader.Read();

        Passenger returnValue = ReaderToPassenger(reader);
        
        Connection.Close();
        
        return returnValue;
    }

    private Passenger ReaderToPassenger(SqlDataReader reader)
    {
        Passenger passenger = new Passenger();

        passenger.ID = Convert.ToInt64(reader["ID"]);

        passenger.FirstLastName = reader["FIRST_LAST_NAME"].ToString();

        passenger.PassportNumber = reader["PASSPORT_NUMBER"].ToString();

        return passenger;
    }
}