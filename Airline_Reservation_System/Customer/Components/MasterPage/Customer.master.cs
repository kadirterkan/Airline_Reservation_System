using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Components_MasterPage_Customer : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // if (Session["username"] == null && Session["authorization"] == null)
        // {
        //     Response.Redirect("../../Pages/Login/Login.aspx");
        // }
    }

    protected void OnClick(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["authorization"] = null;
        Response.Redirect("../../Pages/Login/Login.aspx");
    }
}
