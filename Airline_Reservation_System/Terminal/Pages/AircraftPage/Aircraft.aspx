<%@ Page Title="" Language="C#" MasterPageFile="~/Terminal/Components/MasterPage/SeeAddEditRemoveTemplate.master" AutoEventWireup="true" CodeFile="Aircraft.aspx.cs" Inherits="Terminal_Pages_Aircraft_Aircraft" %>

<asp:Content ID="head" ContentPlaceHolderID="headForPages" runat="server">
    <title>Aircrafts</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ModalContent" Runat="Server">
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Aircraft Tail Number</span>
        <asp:TextBox runat="server" ID="tailNumberIn" CssClass="form-control" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Aircraft Manufacturer</span>
        <asp:TextBox runat="server" ID="aircraftManufacturerIn" CssClass="form-control" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Aircraft Model</span>
        <asp:TextBox runat="server" ID="aircraftModelIn" CssClass="form-control" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Date Of Manufacture</span>
        <asp:TextBox runat="server" ID="dateOfManufactureIn" CssClass="form-control" type="date" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Economic Class Capacity</span>
        <asp:TextBox runat="server" ID="economicClassCapacity" CssClass="form-control" type="number" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
    <div class="mb-3 input-group flex-nowrap">
        <span class="input-group-text" id="inputGroup-sizing-default">Business Class Capacity</span>
        <asp:TextBox runat="server" ID="BusinessClassCapacity" CssClass="form-control" type="number" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:TextBox>
    </div>
</asp:Content>

