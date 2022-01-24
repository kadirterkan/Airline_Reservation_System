<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/Components/MasterPage/BookingTemplate.master" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Customer_Pages_Booking_Booking" %>
<%@ Register TagPrefix="uc" TagName="FlightCard" Src="~/Components/FlightCard.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerForPage" Runat="Server">
    <title>Booking</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formInsideContent" Runat="Server">
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">  
    </asp:ScriptManager>
    <div class="container col gy-5">
        <div class="row row-cols-3 align-items-center">
            <div class="col-md-3">
                <asp:LinkButton runat="server" ID="lastDayButton" AutoPostBack="True" OnClick="OnClickDecreaseDay">
                    <span class="material-icons">arrow_back_ios</span>
                </asp:LinkButton>
            </div>
            <div class="col-md-6 row justify-content-center">
                <asp:TextBox ID="dateOfFlight" CssClass="form-control" AutoPostBack="True" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender
                    ID="CalendarExtender1"
                    TargetControlID="dateOfFlight"
                    Format="MMMM dd yyyy"
                    runat="server"/>
                </div>
            <div class="col-md-3 row justify-content-end">
                <asp:LinkButton runat="server" ID="nextDayButton" AutoPostBack="True" OnClick="OnClickAddDay">
                    <span class="material-icons">arrow_forward_ios</span>
                </asp:LinkButton>
            </div>
        </div>
        <br/>
        <asp:PlaceHolder runat="server" ID="FlightsList">
            
        </asp:PlaceHolder>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ModalBody" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ModalBtns" Runat="Server">
</asp:Content>

