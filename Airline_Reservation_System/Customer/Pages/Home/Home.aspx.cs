using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;
using NHibernate.Mapping;

public partial class Customer_Pages_Home_Transporting : System.Web.UI.Page
{
    private PlaceHolder PopUpModal;
    private Label ModalTitleLabel;

    private static CountryController _countryController = new CountryController();
    private static AirportController _airportController = new AirportController();

    protected void Page_Load(object sender, EventArgs e)
    {
        ReadyTheControls();

        // Application["flightRequest"] = new Flight();
    }

    protected void ReadyTheControls()
    {
        ContentPlaceHolder contentPlaceHolder = Master.Master.Master.FindControl("ContentPlaceHolder1").FindControl("contents") as ContentPlaceHolder;
        
        PopUpModal = contentPlaceHolder.FindControl("PopUpModal") as PlaceHolder;
        ModalTitleLabel = contentPlaceHolder.FindControl("ModalTitleLabel") as Label;
    }

    protected void OnClickSelectDepartureAirport(object sender, EventArgs e)
    {
        arrivalAirportButton.Enabled = false;
        countryIn.Text = null;
        airportIn.Text = null;
        countryList.Items.Clear();
        airportList.Items.Clear();
        GetDepartureCountryList();
        PopUpModal.Visible = true;
        AirportInputHolder.Visible = false;
        ModalTitleLabel.Text = "Select Departure Airport";
        Application["airportType"] = "DEPARTURE";
    }
    
    protected void OnClickSelectArrivalAirport(object sender, EventArgs e)
    {
        countryIn.Text = null;
        airportIn.Text = null;
        countryList.Items.Clear();
        airportList.Items.Clear();
        GetArrivalCountryList();
        PopUpModal.Visible = true;
        AirportInputHolder.Visible = false;
        ModalTitleLabel.Text = "Select Arrival Airport";
        Application["airportType"] = "ARRIVAL";
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

    private void GetDepartureCountryList()
    {
        foreach (Country country in _countryController.GetCountries())
        {
            ListItem listItem = new ListItem();
            listItem.Text = country.CountryName;
            listItem.Value = country.ID.ToString();
            
            countryList.Items.Add(listItem);
        }
    }

    private void GetArrivalCountryList()
    {
        foreach (Country country in _countryController.GetArrivalCountriesByAirportId(Convert.ToInt64(Application["departureAirportId"])))
        {
            ListItem listItem = new ListItem();
            listItem.Text = country.CountryName;
            listItem.Value = country.ID.ToString();
            
            countryList.Items.Add(listItem);
        }
    }

    private void GetAirportWithCountryId(Int64 countryId)
    {
        foreach (Airport airport in _airportController.GetAirportsByCountryId(countryId))
        {
            ListItem listItem = new ListItem();
            listItem.Text = airport.AirportName;
            listItem.Value = airport.ID.ToString();
        }
    }

    protected void countryList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        countryIn.Text = countryList.SelectedItem.Text;
        if (Application["airportType"].Equals("DEPARTURE"))
        {
            foreach (Airport airport in _airportController.GetAirportsByCountryId(Convert.ToInt64(countryList.SelectedValue)))
            {
                ListItem listItem = new ListItem();
                listItem.Text = airport.AirportName;
                listItem.Value = airport.ID.ToString();
                
                airportList.Items.Add(listItem);
            }
        }
        else if (Application["airportType"].Equals("ARRIVAL"))
        {
            foreach (Airport airport in _airportController.GetArrivalAirportsByAirportIdAndCountryId(Convert.ToInt64(Application["departureAirportId"]),Convert.ToInt64(countryList.SelectedValue)))
            {
                ListItem listItem = new ListItem();
                listItem.Text = airport.AirportName;
                listItem.Value = airport.ID.ToString();
                
                airportList.Items.Add(listItem);
            }
        }
        AirportInputHolder.Visible = true;
    }

    protected void BtnModalSubmitFooter_OnClick(object sender, EventArgs e)
    {
        if (Application["airportType"].Equals("DEPARTURE"))
        {
            Application["departureAirportId"] = airportList.SelectedValue;
            departureAirportButton.Text = airportList.SelectedItem.Text;
        }
        else if (Application["airportType"].Equals("ARRIVAL"))
        {
            Application["arrivalAirportId"] = airportList.SelectedValue;
            arrivalAirportButton.Text = airportList.SelectedItem.Text;
        }
        PopUpModal.Visible = false;
        arrivalAirportButton.Enabled = true;
    }
    
    private void MessageBox(String message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }

    protected void airportList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        airportIn.Text = airportList.SelectedItem.Text;
    }

    protected void showFlights_OnClick(object sender, EventArgs e)
    {
        String departureAirportId = "?departureAirportId=" + Application["departureAirportId"].ToString();
        String arrivalAirportId = "?arrivalAirportId=" +Application["arrivalAirportId"].ToString();
        Application["departureDate"] = departingDateIn.Text;
        Application["adultCount"] = adultCount.Text;
        Application["childrenCount"] = childrenCount.Text;
        Application["flightClass"] = travelClassList.SelectedValue;
        
        Response.Redirect("../Booking/Booking.aspx");
    }
}