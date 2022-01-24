<%@ page title="" language="C#" masterpagefile="~/Terminal/Components/MasterPage/SeeAddEditRemoveTemplate.master" autoeventwireup="true" inherits="Terminal_Pages_TerminalFlightsPage_Flights, App_Web_t5bmvt5r" %>

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
                Dropdown Example<span class="caret"></span>
            </button>
            <asp:ListBox runat="server" CssClass="dropdown-menu"></asp:ListBox>
        </div>
        <asp:TextBox runat="server" ID="airplaneNumberIn" CssClass="form-control" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <div class="dropdown">
            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                Dropdown Example<span class="caret"></span>
            </button>
            <asp:ListBox runat="server" CssClass="dropdown-menu"></asp:ListBox>
        </div>
        <asp:TextBox runat="server" ID="departureAirportNumberIn" CssClass="form-control" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <div class="dropdown">
            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                Dropdown Example<span class="caret"></span>
            </button>
            <asp:ListBox runat="server" CssClass="dropdown-menu"></asp:ListBox>
        </div>
        <asp:TextBox runat="server" ID="arrivalAirportNumberIn" CssClass="form-control" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Departure Date</span>
        <asp:TextBox runat="server" ID="departureDate" CssClass="form-control" type="datetime-local" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Flight Length in Minutes</span>
        <asp:TextBox runat="server" ID="flightLength" CssClass="form-control" type="number" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
</asp:Content>

