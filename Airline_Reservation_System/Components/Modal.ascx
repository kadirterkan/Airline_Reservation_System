<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Modal.ascx.cs" Inherits="Components_Modal" %>
<div class="modal-static-backdrop"></div>
<div class="modal modal-static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title"><asp:Label ID="ModalControlTitleLabel" runat="server"></asp:Label></h4>
                <asp:LinkButton ID="BtnModalControlCloseHeader" CausesValidation="False" runat="server" CssClass="close" >
                    <span class="material-icons">
                    close
                    </span>
                </asp:LinkButton>
            </div>
            <div class="modal-body">

            </div>
            <div class="modal-footer" style="gap: 1rem;">

            </div>
        </div>
    </div>
</div>
