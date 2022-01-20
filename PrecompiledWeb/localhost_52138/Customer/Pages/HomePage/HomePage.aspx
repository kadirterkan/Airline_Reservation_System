<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Customer/Components/MasterPage/User.master" inherits="Customer_Pages_HomePage_HomePage, App_Web_mmcpxjyo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form runat="server">
        <div id="booking" class="section">
		<div class="section-center">
			<div class="container">
				<div class="row">
					<div class="col-md-4">
						<div runat="server" class="booking-cta" ID="welcomeMessage" Visible="False">
							<h1>Book your flight today</h1>
							<p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Cupiditate laboriosam numquam at</p>
						</div>
						<div runat="server" class="booking-form" ID="selectCountryAndAirport">
							<asp:Label runat="server" ID="departureOrArrival"></asp:Label>
							<div style="display:flex;gap: 3rem;">
								<asp:RadioButtonList runat="server" Height="300px" RepeatColumns="5" CellSpacing="15" ForeColor="white" CssClass="select-country" ID="selectCountry"></asp:RadioButtonList>
								<div  style="max-height: 200px;">
									<asp:RadioButtonList runat="server" Height="300px" CellPadding="100" BorderStyle="Ridge" CssClass="select-airport" ForeColor="black" BackColor="white" ID="selectAirport"></asp:RadioButtonList>
								</div>
							</div>
						</div>
					</div>
					<div class="col-md-7 col-md-offset-1">
						<div class="booking-form">
							<form novalidate="true">
								<div class="form-group">
									<div class="form-checkbox">
										<label for="roundtrip">
											<asp:RadioButton runat="server" GroupName="flightType" Checked ID="roundtrip" />
											<span></span>Roundtrip
										</label>
										<label for="oneway">
											<asp:RadioButton runat="server" GroupName="flightType" ID="oneway" />
											<span></span>One way
										</label>
										<label for="multicity">
											<asp:RadioButton runat="server" GroupName="flightType" ID="multicity" />
											<span></span>Multi-City
										</label>
									</div>
								</div>
								<div class="row">
									<div class="col-md-6">
										<div class="form-group">
											<span class="form-label">Flying from</span>
											<asp:Button runat="server" type="text" CssClass="form-control" placeholder="City or airport" ID="departureAirportButton"/>
										</div>
									</div>
									<div class="col-md-6">
										<div class="form-group">
											<span class="form-label">Flying to</span>
											<asp:Button runat="server" type="text" CssClass="form-control" placeholder="City or airport" ID="arrivalAirportButton"/>
										</div>
									</div>
								</div>
								<div class="row">
									<div class="col-md-6">
										<div class="form-group">
											<span class="form-label">Departing</span>
											<asp:TextBox runat="server" type="date" CssClass="form-control" required="True" ID="departingDate"/>
										</div>
									</div>
									<div class="col-md-6">
										<div class="form-group">
											<span class="form-label">Returning</span>
											<asp:TextBox runat="server" type="date" CssClass="form-control" required="True" ID="returningDate"/>
										</div>
									</div>
								</div>
								<div class="row">
									<div class="col-md-4">
										<div class="form-group">
											<span class="form-label">Adults (18+)</span>
											<asp:DropDownList runat="server" CssClass="form-control" ID="adultsList"/>
											<span class="select-arrow"></span>
										</div>
									</div>
									<div class="col-md-4">
										<div class="form-group">
											<span class="form-label">Children (0-17)</span>
											<asp:DropDownList runat="server" CssClass="form-control" ID="childrenList"/>												
											<span class="select-arrow"></span>
										</div>
									</div>
									<div class="col-md-4">
										<div class="form-group">
											<span class="form-label">Travel class</span>
											<asp:DropDownList runat="server" CssClass="form-control" ID="travelClassList">
												<asp:ListItem Text="Economy Class" Value="Economy Class"/>
												<asp:ListItem Text="Business class" Value="Economy Class"/>
												<asp:ListItem Text="First class" Value="Economy Class"/>
											</asp:DropDownList>
											<span class="select-arrow"></span>
										</div>
									</div>
								</div>
								<div class="form-btn">
									<asp:Button runat="server" CssClass="submit-btn" Text="Show flights"/>
								</div>
							</form>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
        </form>
</asp:Content>