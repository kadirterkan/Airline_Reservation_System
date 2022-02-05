<%@ page title="" language="C#" masterpagefile="~/Customer/Components/MasterPage/BookingTemplate.master" autoeventwireup="true" inherits="Customer_Pages_UserInformation_UserInformation, App_Web_as30hb0n" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headerForPage" Runat="Server">
    <title>User Information</title>
    <link href="../../Content/CSS/Reservation/reservation.css" rel="stylesheet" type="text/css"></link>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formInsideContent" Runat="Server">
    <form>
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">  
        </asp:ScriptManager>
        <div class="mb-3">
            <h1 style="color: white;">Look and change your user information. </h1>
        </div>
        <div class="mb-3">
            <ajaxToolkit:TabContainer runat="server" CssClass="MyTable" ID="userInfoTab">
                <ajaxToolkit:TabPanel runat="server" HeaderText="User Informations">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="emailAdressIn" class="form-label">E-Mail Address</label>
                            <asp:TextBox type="email" class="form-control" id="emailAdressIn" runat="server"/>
                        </div>
                        <div class="mb-3">
                            <label for="phoneNumberIn" class="form-label">Phone Number</label>
                            <asp:TextBox type="text" class="form-control" id="phoneNumberIn" runat="server"/>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Password">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="passwordIn" class="form-label">Password</label>
                            <asp:TextBox type="password" class="form-control" id="passwordIn" runat="server"/>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
        <div class="mb-3">
            <asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Save Changes"/>
        </div>
    </form>
</asp:Content>