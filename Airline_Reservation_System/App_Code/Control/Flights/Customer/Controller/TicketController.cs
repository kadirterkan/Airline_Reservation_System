using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public interface ITicketController
{
    Int32 GetAttenderCountByIdAndFlightClass(Int64 flightId, String flightClass);
}

public class TicketController : BaseController, ITicketController
{
    public TicketController()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
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
}