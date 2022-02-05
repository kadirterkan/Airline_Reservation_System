<%@ page title="" language="C#" masterpagefile="~/Terminal/Components/MasterPage/SeeAddEditRemoveTemplate.master" autoeventwireup="true" inherits="Terminal_Pages_AirportPage_Airport, App_Web_2tvi45gf" %>

<asp:Content ID="head" ContentPlaceHolderID="headForPages" runat="server">
    <title>Airports</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ModalContent" Runat="Server">
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Airport Name</span>
        <asp:TextBox runat="server" ID="airportNameIn" CausesValidation="True" ValidationGroup="AddItem" CssClass="form-control" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Airport City</span>
        <asp:TextBox runat="server" ID="airportCityIn" CausesValidation="True" ValidationGroup="AddItem" CssClass="form-control" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Airport IATA Code</span>
        <asp:TextBox runat="server" ID="airportIATAIn" CausesValidation="True" ValidationGroup="AddItem" CssClass="form-control" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <div class="dropdown">
            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                Airport Country<span class="caret"></span>
            </button>
            <asp:ListBox runat="server" AutoPostBack="True" ID="CountryList" OnSelectedIndexChanged="OnCountrySelected" CausesValidation="True" ValidationGroup="AddItem" CssClass="dropdown-menu"></asp:ListBox>
        </div>
        <asp:TextBox runat="server" ID="airportCountryIn" CausesValidation="True" ValidationGroup="AddItem" CssClass="form-control" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
</asp:Content>

