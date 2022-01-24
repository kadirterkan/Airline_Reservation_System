using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Components_MasterPage_BookingTemplate : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ReadyTheControls()
    {
        
    }

    protected void OnClickCloseModal(object sender, EventArgs e)
    {
        PopUpModal.Visible = false;
    }
}
