using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Users.Controller;

public partial class Customer_Pages_CustomerLogin_Transporting : System.Web.UI.Page
{
    private UserController _userController;

    protected void Page_Load(object sender, EventArgs e)
    {
        submitButton.Text = "Login";
        _userController = new UserController();
    }

    protected void loginScreen_OnCheckedChanged(object sender, EventArgs e)
    {
        emailInputFormGroup.Visible = !loginScreen.Checked;
        if (loginScreen.Checked)
        {
            ChangeLoginBoxColors(Color.White);
            submitButton.Text = "Login";
        }
    }

    protected void registerScreen_OnCheckedChanged(object sender, EventArgs e)
    {
        emailInputFormGroup.Visible = registerScreen.Checked;
        if (registerScreen.Checked)
        {
            ChangeLoginBoxColors(Color.White);
            submitButton.Text = "Register";
        }
    }

    protected void submitButton_OnClick(object sender, EventArgs e)
    {
        if (loginScreen.Checked)
        {
            SubmitLogin();
        }
        else
        {
            SubmitRegister();
        }
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
            Response.Redirect("../Home/Home.aspx");
        }
        else
        {
            ChangeLoginBoxColors(Color.Red);
            MessageBox("Wrong username or password, please try again.");
        }
    }

    private void SubmitRegister()
    {
        String username = userNameInput.Text;
        String password = passwordInput.Text;
        String email = emailInput.Text;

        if (_userController.IsUserNameUnique(username))
        {
            if (_userController.UserRegister(username, password, email))
            {
                MessageBox("You have successfully registered...");
            }
            else
            {
                MessageBox("Something went wrong");
            }
        }
        else
        {
            ChangeRegisterBoxColors(Color.Red);
            MessageBox("This username has already been used. Please choose a unique username.");
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
    
    private void ChangeRegisterBoxColors(Color color)
    {
        userNameInput.BackColor = color;
    }
}