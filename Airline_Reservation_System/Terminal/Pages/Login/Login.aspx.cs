using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Users.Controller;

public partial class Terminal_Pages_TerminalLogin_Transporting : System.Web.UI.Page
{
    private static UserController _userController = new UserController();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void submitButton_OnClick(object sender, EventArgs e)
    {
        SubmitLogin();
    }
    
    private void SubmitLogin()
    {
        
        String username = userNameInput.Text;
        String password = passwordInput.Text;
        if (_userController.UserLogin(username, password))
        {
            MessageBox("You have successfully logged in.");
            Session["username"] = username;
            Session["userId"] = _userController.GetUserByUserName(username).ID;
            Response.Redirect("../FlightsPage/Flights.aspx");
        }
        else
        {
            ChangeLoginBoxColors(Color.Red);
            MessageBox("Wrong username or password, please try again.");
        }
    }
    
    private void MessageBox(String message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }

    private void ChangeLoginBoxColors(Color color)
    {
        userNameInput.BackColor = color;
        passwordInput.BackColor = color;
    }
}