<%@ page title="" language="C#" masterpagefile="~/Terminal/Components/MasterPage/SeeAddEditRemoveTemplate.master" autoeventwireup="true" inherits="Terminal_Pages_TerminalFlightsPage_Flights, App_Web_o2tui452" %>

<asp:Content ID="head" ContentPlaceHolderID="headForPages" runat="server">
    <title>Flights</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ModalContent" Runat="Server">
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Flight Number || FN</span>
        <asp:TextBox runat="server" ID="flightNumberIn" CssClass="form-control" type="text" MaxLength="4" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <div class="dropdown">
            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                Choose Aircraft<span class="caret"></span>
            </button>
            <asp:ListBox runat="server" ID="airplaneList" CssClass="dropdown-menu" AutoPostBack="True" OnSelectedIndexChanged="airplaneList_OnSelectedIndexChanged"></asp:ListBox>
        </div>
        <asp:TextBox runat="server" ID="airplaneNumberIn" CssClass="form-control" AutoPostBack="True" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <div class="dropdown">
            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                Choose Route<span class="caret"></span>
            </button>
            <asp:ListBox runat="server" ID="routeList" AutoPostBack="True" CssClass="dropdown-menu" OnSelectedIndexChanged="routeList_OnSelectedIndexChanged"></asp:ListBox>
        </div>
        <asp:TextBox runat="server" ID="routeIn" CssClass="form-control" AutoPostBack="True" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Departure Date</span>
        <asp:TextBox runat="server" ID="departureDate" CssClass="form-control" type="datetime-local" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Flight Length in Minutes</span>
        <asp:TextBox runat="server" ID="flightLength" CssClass="form-control" type="number" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Economy Capacity</span>
        <asp:TextBox runat="server" ID="economyCapacity" CssClass="form-control" type="number" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Business Capacity</span>
        <asp:TextBox runat="server" ID="businessCapacity" CssClass="form-control" type="number" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Gate Number</span>
        <asp:TextBox runat="server" ID="gateNo" CssClass="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
</asp:Content>

