<%@ page language="C#" masterpagefile="~/Customer/Components/MasterPage/BookingTemplate.master" autoeventwireup="true" inherits="Customer_Pages_Reservation_Reservation, App_Web_ooybncgq" %>
<%@ Register TagPrefix="uc" TagName="passengerTabContainer_1" Src="~/Components/passengerTabContainer.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerForPage" Runat="Server">
    <title>Reservation</title>
    <link href="../../Content/CSS/Reservation/reservation.css" rel="stylesheet" type="text/css"></link>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formInsideContent" Runat="Server">
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">  
    </asp:ScriptManager>
    <form>
        <div class="panel-title">
            <label style="color: white;"><h6>Reservation</h6></label>
        </div>
        <div class="mb-3">
            <label style="color: white;">Phone Number = +1 (xxx) xxx-xx-xx</label>
        </div>
        <div class="mb-3">
            <label style="color: white;">Email address = name@example.com</label>
        </div>
        <div class="mb-3">
            <ajaxToolkit:TabContainer ID="passengersTypeTab" CssClass="MyTable" runat="server">
                <ajaxToolkit:TabPanel runat="server" HeaderText="Adult Passengers">
                    <ContentTemplate>
                        <ajaxToolkit:TabContainer ID="adultPassengersTabContainer" runat="server" CssClass="MyTable">
                            <ajaxToolkit:TabPanel runat="server" HeaderText="Passenger 1">
                                <ContentTemplate>
                                    <uc:passengerTabContainer_1 runat="server"></uc:passengerTabContainer_1>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Children Passengers">
                    <ContentTemplate>
                        <ajaxToolkit:TabContainer ID="childrenPassengersTabContainer" runat="server" Height="300px" CssClass="MyTable">
                            <ajaxToolkit:TabPanel runat="server" HeaderText="Passenger 1">
                                <ContentTemplate>
                                    <uc:passengerTabContainer_1 runat="server"></uc:passengerTabContainer_1>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
        <div class="mb-3">
            <asp:Button runat="server" ID="CheckoutBtn" CssClass="btn btn-primary btn-block" Text="Checkout"/>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ModalBody" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ModalBtns" Runat="Server">
</asp:Content>