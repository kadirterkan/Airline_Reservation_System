using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Pages_CustomerLogin_CustomerLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        submitButton.Text = "Login";
    }

    protected void loginScreen_OnCheckedChanged(object sender, EventArgs e)
    {
        emailInputFormGroup.Visible = !loginScreen.Checked;
        if (loginScreen.Checked)
        {
            submitButton.Text = "Login";
        }
    }

    protected void registerScreen_OnCheckedChanged(object sender, EventArgs e)
    {
        emailInputFormGroup.Visible = registerScreen.Checked;
        if (registerScreen.Checked)
        {
            submitButton.Text = "Register";
        }
    }
}