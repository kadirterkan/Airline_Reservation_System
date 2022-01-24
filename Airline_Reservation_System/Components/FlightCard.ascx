<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlightCard.ascx.cs"  Inherits="Components_FlightCard" %>
<asp:LinkButton ID="linkButton" runat="server" class="card">
    <div class="card-body row align-items-center">
        <div class="col">
            <div class="row justify-content-center">
                <h1><asp:Label runat="server" ID="departureTime"></asp:Label></h1>
            </div>
            <div class="row justify-content-center">
                <asp:Label runat="server" ID="departureAirport"></asp:Label>
            </div>
        </div>
        <div class="col border-bottom justify-content-center">
            <div class="row justify-content-center">
                <span class="material-icons">
                flight_takeoff
                </span>
            </div>
            <div class="row justify-content-center">
                <h6>Duration <asp:Label runat="server" ID="flightDuration"></asp:Label></h6>
            </div>
        </div>
        <div class="col">
            <div class="row justify-content-center">
                <h1><asp:Label runat="server" ID="arrivalTime"></asp:Label></h1>
            </div>
            <div class="row justify-content-center">
                <asp:Label runat="server" ID="arrivalAirport"></asp:Label>
            </div>
        </div>
        <div class="col">
            <div class="row justify-content-center">
                <h2>Flight no.</h2>
            </div>
            <div class="row justify-content-center">
                <asp:Label runat="server" ID="flightNumber"></asp:Label>
            </div>
        </div>
        <div class="col">
            <div class="row justify-content-center">
                <h2>Type</h2>
            </div>
            <div class="row justify-content-center">
                <asp:Label runat="server" ID="flightType"></asp:Label>
            </div>
        </div>
        <div class="col row gx-5 border-start border-4 justify-content-end">
            <h1><asp:Label runat="server" ID="flightPrice"></asp:Label></h1>
        </div>
        <div class="col">
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Select"/>
        </div>
    </div>
</asp:LinkButton>