<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Customer/Components/MasterPage/User.master" CodeFile="HomePage.aspx.vb" Inherits="Customer_Pages_HomePage_HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="HomePage">
            <div class="HomePageContent">
                <div class="WelcomeMessage">
                    <span class="Message">
                    Hello
                    </span>
                    <span class="Message">
                    Where do you want to explore?
                    </span>
                </div>
                <div class="ReservationScreen">
                    <div class="ReservationInputs">
                        <div class="FlightType">
                            <asp:RadioButtonList runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Value="RoundTrip" ID="RoundTripBtn" Selected Text="Round Trip" class="FlightTypeRadioButton"></asp:ListItem>
                                <asp:ListItem Value="OneWayBtn" ID="OneWayBtn" Text="One Way Trip" class="FlightTypeRadioButton"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="FlightInfos">
                            <div class="DepartureAirport">
                                <asp:DropDownList runat="server" DataTextField="From" CssClass="AirportInput">
                                    <asp:ListItem Text="Amsterdam"></asp:ListItem>
                                    <asp:ListItem Text="New York"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="LandingAirport">
                                <asp:DropDownList runat="server" DataTextField="From" CssClass="AirportInput">
                                    <asp:ListItem Text="Amsterdam"></asp:ListItem>
                                    <asp:ListItem Text="New York"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="FlightDate">
                                <asp:Calendar ID="TestThis" runat="server"/>
                            </div>
                            <div class="ChoosePeople">

                            </div>
                            <div class="FlightCheckout">
                            
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </form>
</asp:Content>