using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class Customer_Pages_Booking_Booking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // dateOfFlight.Text = DateTime.Now.ToString("MMMM dd yyyy",new CultureInfo("us-US"));
    }

    protected void OnClickAddDay(object sender, EventArgs e)
    {
        DateTime dateTime = Convert.ToDateTime(dateOfFlight.Text,new CultureInfo("us-US"));
        dateTime = dateTime.AddDays(1.0);
        dateOfFlight.Text = dateTime.ToString("MMMM dd yyyy",new CultureInfo("us-US"));
    }
    
    protected void OnClickDecreaseDay(object sender, EventArgs e)
    {
        DateTime dateTime = Convert.ToDateTime(dateOfFlight.Text,new CultureInfo("us-US"));
        dateTime = dateTime.AddDays(-1.0);
        dateOfFlight.Text = dateTime.ToString("MMMM dd yyyy",new CultureInfo("us-US"));
    }
}