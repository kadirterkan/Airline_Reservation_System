using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ASP;
using Control.Enum_Like;
using Control.Passenger;
using Control.Users.Controller;
using Control.Users.Entities;
using Control = System.Web.UI.Control;

public partial class Customer_Pages_Reservation_Reservation : System.Web.UI.Page
{
    private UserController _userController = new UserController();
    private TicketController _ticketController = new TicketController();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        AddPanels();

        BaseUser baseUser = _userController.GetUserByUserName("CUSTOMER");

        Application["email"] = baseUser.EMail;
    }

    private void AddPanels()
    {
        // Int32 adultCount = Convert.ToInt32(Application["adultCount"]);
        // Int32 childrenCount = Convert.ToInt32(Application["childrenCount"]);

        foreach (int range in Enumerable.Range(1, 5))
        {
            TabPanel tabPanel = new TabPanel();
            tabPanel.ID = "adultPassengerPanel" + range;
            tabPanel.HeaderText = "Adult Passenger " + range;

            components_passengertabcontainer_ascx tabContainer =
                new components_passengertabcontainer_ascx();

            tabPanel.Controls.Add(tabContainer);

            adultPassengersTabContainer.Tabs.Add(tabPanel);
        }
        
        foreach (int range in Enumerable.Range(1, 5))
        {
            TabPanel tabPanel = new TabPanel();
            tabPanel.ID = "childrenPassengerPanel" + range;
            tabPanel.HeaderText = "Child Passenger " + range;

            components_passengertabcontainer_ascx tabContainer =
                new components_passengertabcontainer_ascx();
            
            tabPanel.Controls.Add(tabContainer);
            
            childrenPassengersTabContainer.Tabs.Add(tabPanel);
        }
        
    }

    protected void CheckoutBtn_OnClick(object sender, EventArgs e)
    {
        Application["phoneNumber"] = phoneNumberId.Text;
        List<Passenger> passengers = new List<Passenger>();

        foreach (TabPanel panel in adultPassengersTabContainer.Tabs)
        {
            foreach (System.Web.UI.Control panelControl in panel.Controls)
            {
                TextBox nameSurnameIn = panelControl.FindControl("nameSurnameIn") as TextBox;
                TextBox passaportNoIn = panelControl.FindControl("passaportNoIn") as TextBox;
                RadioButtonList genderIn = panelControl.FindControl("genderIn") as RadioButtonList;

                Passenger passenger = new Passenger();
                passenger.Age = AgeEnum.Adult;
                passenger.Gender = genderIn.SelectedValue;
                passenger.EmailAddress = Application["email"].ToString();
                passenger.PhoneNumber = Application["phoneNumber"].ToString();
                passenger.FirstLastName = nameSurnameIn.Text;
                passenger.PassportNumber = passaportNoIn.Text;

                passengers.Add(passenger);
            }
        }
        
        foreach (TabPanel panel in childrenPassengersTabContainer.Tabs)
        {
            foreach (System.Web.UI.Control panelControl in panel.Controls)
            {
                TextBox nameSurnameIn = panelControl.FindControl("nameSurnameIn") as TextBox;
                TextBox passaportNoIn = panelControl.FindControl("passaportNoIn") as TextBox;
                RadioButtonList genderIn = panelControl.FindControl("genderIn") as RadioButtonList;

                Passenger passenger = new Passenger();
                passenger.Age = AgeEnum.Children;
                passenger.Gender = genderIn.SelectedValue;
                passenger.EmailAddress = Application["email"].ToString();
                passenger.PhoneNumber = Application["phoneNumber"].ToString();
                passenger.FirstLastName = nameSurnameIn.Text;
                passenger.PassportNumber = passaportNoIn.Text;

                passengers.Add(passenger);
            }
        }

        if (_ticketController.AddTicketsByPassengerListAndFlightIdAndFlightClassAndUserId(passengers, Convert.ToInt64(Application["flightId"]),Application["flightClass"].ToString(), Convert.ToInt64(Application["userId"])))
        {
            MessageBox("Reservation Successful!");
            MessageBox("Now you will be redirected to the tickets page");
        
            Response.Redirect("../Tickets/Tickets.aspx");
        }
        else
        {
            MessageBox("Something went wrong");

            Response.Redirect("../Home/Home.aspx");
        }
    }
    
    private void MessageBox(String message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }
}