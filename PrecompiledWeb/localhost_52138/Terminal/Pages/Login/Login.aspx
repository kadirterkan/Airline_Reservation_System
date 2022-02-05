<%@ page title="" language="C#" masterpagefile="~/BaseMasterPage.master" autoeventwireup="true" inherits="Terminal_Pages_TerminalLogin_Transporting, App_Web_m40laru3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Terminal Login</title>
    <link href="../../Content/CSS/TerminalHomePage/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div id="adminLogin" class="section">
            <div class="section-center">
                <div class="text-center" style="color: black;">
                    <h1>Terminal Login</h1>
                </div>
                <div class="container">
                    <div class="">
                        <div class="login-form">
                            <form>
                                <div class="form-group" style="color: white;">
                                    <br/>
                                    <div class="form-group">
                                        <label for="userNameInput">User Name</label>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="userNameInput" placeholder="User Name"/>
                                    </div>
                                    <div class="form-group">
                                        <label for="passwordInput">Password</label>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="passwordInput" placeholder="Password" type="Password"/>
                                    </div>
                                    <br/>
                                    <asp:Button runat="server" CssClass="btn btn-primary btn-block" ID="submitButton" Text="Login" OnClick="submitButton_OnClick"/>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

