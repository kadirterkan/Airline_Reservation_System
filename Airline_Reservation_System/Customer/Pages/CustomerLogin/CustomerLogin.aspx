<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerLogin.aspx.cs" Inherits="Customer_Pages_CustomerLogin_CustomerLogin" %>

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
            <div class="booking-form">
                <form novalidate="novalidate">
                    <div class="form-group">
                    	<div class="form-checkbox">
                    		<label for="roundtrip">
                    			<asp:RadioButton runat="server" GroupName="LoginScreen" Checked ID="loginScreen" />
                    			<span></span>Login
                    		</label>
                    		<label for="oneway">
                    			<asp:RadioButton runat="server" GroupName="LoginScreen" ID="registerScreen" />
                    			<span></span>Register
                    		</label>
                    	</div>
                    </div>
                </form>
            </div>
        </div>
    </form>
</body>
</html>
