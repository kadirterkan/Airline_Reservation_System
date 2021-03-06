<%@ page title="" language="C#" masterpagefile="~/Terminal/Components/MasterPage/SeeAddEditRemoveTemplate.master" autoeventwireup="true" inherits="Terminal_Pages_TerminalRoutesPage_Routes, App_Web_tjwj432v" %>

<asp:Content ID="head" ContentPlaceHolderID="headForPages" runat="server">
    <title>Routes</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ModalContent" Runat="Server">
    <div class="mb-3 input-group flex-nowrap">
        <div class="dropdown">
            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                From Airport<span class="caret"></span>
            </button>
            <asp:ListBox runat="server" ID="airportList1In" AutoPostBack="True" OnSelectedIndexChanged="airportList1In_OnSelectedIndexChanged" CssClass="dropdown-menu"></asp:ListBox>
        </div>
        <asp:TextBox runat="server" ID="fromAirportNumberIn" CssClass="form-control" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <div class="dropdown">
            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                To Airport<span class="caret"></span>
            </button>
            <asp:ListBox runat="server" ID="airportList2In" AutoPostBack="True" OnSelectedIndexChanged="airportList2In_OnSelectedIndexChanged" CssClass="dropdown-menu"></asp:ListBox>
        </div>
        <asp:TextBox runat="server" ID="toAirportNumberIn" CssClass="form-control" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
</asp:Content>

