<%@ control language="C#" autoeventwireup="true" inherits="Components_passengerTabContainer, App_Web_2wvqjfkj" %>
<%@ Import Namespace="System.Drawing" %>
<ContentTemplate>
    <form> 
        <div class="mb-3">
            <label for="nameSurnameIn" class="form-label">Name Surname</label>
            <asp:TextBox class="form-control" id="nameSurnameIn" runat="server"/>
        </div>
        <div class="mb-3">
            <label for="passaportNoIn" class="form-label">Passport Number</label>
            <asp:TextBox class="form-control" id="passaportNoIn" runat="server"/>
        </div>
        <div class="mb-3">
            <label for="genderIn" class="form-label">Gender</label>
            <asp:RadioButtonList runat="server" ID="genderIn" RepeatDirection="Horizontal" CellPadding="12" ForeColor="White">
                <asp:ListItem runat="server" Text="Male" Value="MALE"></asp:ListItem>
                <asp:ListItem runat="server" Text="Female" Value="FEMALE"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </form>
</ContentTemplate>