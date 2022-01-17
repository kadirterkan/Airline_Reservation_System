using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Linq;
using System.Web;

public class BaseController
{
    protected SqlConnection Connection;
    
    public BaseController()
    {
        Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ARS"].ConnectionString);
    }
}