<%@ Page Title="" Language="C#" MasterPageFile="~/BaseMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Customer_Pages_CustomerLogin_Transporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../Content/CSS/HomePage/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div id="booking" class="section">
            <div class="section-center">
                <div class="text-center">
                    <h1>Customer Login</h1>
                </div>
                <div class="container">
                    <div>
                        <div class="booking-form">
                            <form>
                                <div class="form-group" style="color:white;">
                                    <div class="form-check form-check-inline">
                                        <asp:RadioButton CssClas="btn-check" Text="Login" name="options" Checked ID="loginScreen" GroupName="LoginScreenRadioButtons" runat="server" AutoPostBack="True" OnCheckedChanged="loginScreen_OnCheckedChanged"/>
                                    </div>
                                    <div class="form-check form-check-inline">
                                        <asp:RadioButton CssClas="btn-check" Text="Register" name="options" ID="registerScreen" GroupName="LoginScreenRadioButtons" runat="server" AutoPostBack="True" OnCheckedChanged="registerScreen_OnCheckedChanged"/>
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
                                        <asp:Button runat="server" CssClass="btn btn-primary btn-block" ID="submitButton" OnClick="submitButton_OnClick"/>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

