<%@ page language="C#" masterpagefile="~/Customer/Components/MasterPage/BookingTemplate.master" autoeventwireup="true" inherits="Customer_Pages_Home_Transporting, App_Web_qv2llc3p" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerForPage" Runat="Server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formInsideContent" Runat="Server">
    <form novalidate="true">
    	<div class="form-group" style="color:white;">
    		<div class="form-check form-check-inline">
    			<asp:RadioButton CssClas="btn-check" runat="server" AutoPostBack="True" GroupName="flightType" Text="Roundtrip" Enabled="False" ID="roundtrip" OnCheckedChanged="OnRoundTripChecked"/>
    		</div>
    		<div class="form-check form-check-inline">
    			<asp:RadioButton CssClas="btn-check" runat="server" AutoPostBack="True" GroupName="flightType" Text="One way" Checked ID="oneway" OnCheckedChanged="OnOneWayChecked"/>
    		</div>
    	</div>
    	<div class="row">
    		<div class="col-md-6">
    			<div class="form-group">
    				<span class="form-label">Flying from</span>
    				<asp:Button runat="server" CssClass="btn btn-light form-control" Text="Departure Airport" ID="departureAirportButton" OnClick="OnClickSelectDepartureAirport"/>
    			</div>
    		</div>
    		<div class="col-md-6">
    			<div class="form-group">
    				<span class="form-label">Flying to</span>
    				<asp:Button runat="server" CssClass="btn btn-light form-control" Enabled="False" Text="Arrival Airport" ID="arrivalAirportButton" OnClick="OnClickSelectArrivalAirport"/>
    			</div>
    		</div>
    	</div>
    	<div class="row">
    		<div class="col-md-6">
    			<div class="form-group">
    				<span class="form-label">Departing</span>
    				<asp:TextBox runat="server" type="date" CssClass="form-control" ID="departingDateIn"/>
    			</div>
    		</div>
    		<asp:PlaceHolder ID="ReturningForm" Visible="False" runat="server">
	            <div class="col-md-6">
                    <div class="form-group">
                    	<span class="form-label">Returning</span>
                    	<asp:TextBox runat="server" type="date" CssClass="form-control" ID="returningDateIn"/>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
    	<div class="row">
    		<div class="col-md-4">
    			<div class="form-group">
    				<span class="form-label">Adults (18+)</span>
    				<asp:TextBox runat="server" type="number" value="0" CssClass="form-control" min="0" max="9" ID="adultCount"/>
    			</div>
    		</div>
    		<div class="col-md-4">
    			<div class="form-group">
    				<span class="form-label">Children (0-17)</span>
    				<asp:TextBox runat="server" type="number" value="0" CssClass="form-control" min="0" max="9" ID="childrenCount"/>												
    			</div>
    		</div>
    		<div class="col-md-4">
    			<div class="form-group">
    				<span class="form-label">Travel class</span>
    				<asp:DropDownList runat="server" CssClass="form-control" ID="travelClassList">
    					<asp:ListItem Text="Economy Class" Value="ECONOMY"/>
    					<asp:ListItem Text="Business class" Value="BUSINESS"/>
	                    <%-- TODO : ADD FIRST CLASS IN THE FUTURE --%>
    					<%-- <asp:ListItem Text="First class" Value="First Class"/> --%>
    				</asp:DropDownList>
    				<span class="select-arrow"></span>
    			</div>
    		</div>
    	</div>
    	<div class="form-btn">
    		<asp:Button runat="server" CssClass="submit-btn" Text="Show flights" ID="showFlights" OnClick="showFlights_OnClick"/>
    	</div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ModalBody" Runat="Server">
	<div class="mb-3 input-group flex-nowrap">
	    <div class="dropdown">
	        <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
	            <asp:Label runat="server" ID="CountryLabel"></asp:Label> Country<span class="caret"></span>
	        </button>
	        <asp:ListBox runat="server" CssClass="dropdown-menu" AutoPostBack="True" OnSelectedIndexChanged="countryList_OnSelectedIndexChanged" ID="countryList"></asp:ListBox>
	    </div>
	    <asp:Label runat="server" ID="countryIn" AutoPostBack="True" CssClass="form-control" Enabled="False" type="text" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:Label>
	</div>
	<asp:PlaceHolder ID="AirportInputHolder" Visible="False" runat="server">
	    <div class="mb-3 input-group flex-nowrap">
	        <div class="dropdown">
	            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
	                <asp:Label runat="server" ID="AirportLabel"></asp:Label> Airport<span class="caret"></span>
	            </button>
	            <asp:ListBox runat="server" AutoPostBack="True" CssClass="dropdown-menu" ID="airportList" OnSelectedIndexChanged="airportList_OnSelectedIndexChanged"></asp:ListBox>
	        </div>
	        <asp:Label runat="server" ID="airportIn" AutoPostBack="True" CssClass="form-control" Enabled="False" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default"></asp:Label>
	    </div>
	</asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ModalBtns" Runat="Server">
    <asp:LinkButton ID="BtnModalSubmitFooter" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="BtnModalSubmitFooter_OnClick"></asp:LinkButton>
    <asp:LinkButton ID="BtnModalCloseFooter" runat="server" CssClass="btn btn-primary" Text="Close" OnClick="OnClickClosePopUpModal"></asp:LinkButton>
</asp:Content>

