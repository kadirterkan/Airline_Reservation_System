using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Pages_Home_Transporting : System.Web.UI.Page
{
    private PlaceHolder PopUpModal;
    private Label ModalTitleLabel;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ReadyTheControls();
    }

    protected void ReadyTheControls()
    {
        ContentPlaceHolder contentPlaceHolder = Master.Master.Master.FindControl("ContentPlaceHolder1").FindControl("contents") as ContentPlaceHolder;
        
        PopUpModal = contentPlaceHolder.FindControl("PopUpModal") as PlaceHolder;
        ModalTitleLabel = contentPlaceHolder.FindControl("ModalTitleLabel") as Label;
    }

    protected void OnClickSelectDepartureAirport(object sender, EventArgs e)
    {
        PopUpModal.Visible = true;
        ModalTitleLabel.Text = "Select Departure Airport";
    }
    
    protected void OnClickSelectArrivalAirport(object sender, EventArgs e)
    {
        PopUpModal.Visible = true;
        ModalTitleLabel.Text = "Select Arrival Airport";
    }

    protected void OnClickClosePopUpModal(object sender, EventArgs e)
    {
        PopUpModal.Visible = false;
    }

    protected void OnRoundTripChecked(object sender, EventArgs e)
    {
        using (RadioButton radioButton = sender as RadioButton)
        {
            if (radioButton.Checked)
            {
                ReturningForm.Visible = true;
            }
        }
    }

    protected void OnOneWayChecked(object sender, EventArgs e)
    {
        using (RadioButton radioButton = sender as RadioButton)
        {
            if (radioButton.Checked)
            {
                ReturningForm.Visible = false;
            }
        }
    }
}