<%@ page language="C#" autoeventwireup="true" inherits="Customer_Pages_CustomerLogin_CustomerLogin, App_Web_foduz014" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Customer Login Screen</title>
    <link href="https://fonts.googleapis.com/css?family=Lato:400,700" rel="stylesheet"/>
    <link href="../../Content/CSS/HomePage/style.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/HomePage/bootstrap.min.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="booking" class="section">
            <div class="section-center">
                <div class="text-center">
                    <h1>Customer Login</h1>
                </div>
                <div class="container">
                    <div class="col-md-4 col-md-offset-4">
                        <div class="booking-form">
                            <form>
                                <div class="form-group" style="color:white;">
                    	            <div class="form-check form-check-inline">
                    			        <asp:RadioButton runat="server" GroupName="LoginScreenRadioButtons" Checked="True" ID="loginScreen" Text="Login" AutoPostBack="True" OnCheckedChanged="loginScreen_OnCheckedChanged"/>
                    			        <asp:RadioButton runat="server" GroupName="LoginScreenRadioButtons" ID="registerScreen" Text="Register" AutoPostBack="True" OnCheckedChanged="registerScreen_OnCheckedChanged"/>
                    	            </div>
                                    <div runat="server" Visible="True">
                                        <br/>
                                        <div class="form-group">
                                            <label for="userNameInput">User Name</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="userNameInput"  placeholder="User Name"/>
                                        </div>
                                        <div class="form-group" runat="server" Visible="False" ID="emailInputFormGroup">
                                            <label for="emailInput">E-Mail</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="emailInput" type="email" placeholder="Email"/>
                                        </div>
                                        <div class="form-group">
                                            <label for="passwordInput">Password</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="passwordInput" type="Password" placeholder="Password"/>
                                        </div>
                                        <br/>
                                        <asp:Button runat="server" CssClass="btn btn-default btn-block" ID="submitButton" OnClick="submitButton_OnClick"/>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
