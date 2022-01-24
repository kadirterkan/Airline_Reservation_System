using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Terminal_Pages_TerminalRoutesPage_Routes : System.Web.UI.Page
{
    private Label PageTitle;
    private Label PageParagraph;
    private Button GetBtn;
    private Button AddBtn;
    private TableHeaderRow TableContentRow;
    private PlaceHolder GenericAddEditModal;
    private Label ModalTitleLabel;
    private LinkButton BtnModalCloseHeader;
    private LinkButton BtnModalSubmitFooter;
    private LinkButton BtnModalCloseFooter;

    protected void Page_Load(object sender, EventArgs e)
    {
        ReadyTheControls();
        RoutesPageContent.SetPageContent(PageTitle, PageParagraph, GetBtn, AddBtn, TableContentRow);

        GetBtn.Click += new EventHandler(OnClickGetRoutes);
        AddBtn.Click += new EventHandler(OnClickOpenAddRouteModal);
        BtnModalCloseHeader.Click += new EventHandler(OnClickCloseRouteModal);
        BtnModalCloseFooter.Click += new EventHandler(OnClickCloseRouteModal);

    }
    
    private void ReadyTheControls()
    {
        ContentPlaceHolder contentPlaceHolder = Master.Master.Master.FindControl("ContentPlaceHolder1").FindControl("contents") as ContentPlaceHolder;

        PageTitle = (Label) contentPlaceHolder.FindControl("PageTitle");
        PageParagraph = (Label) contentPlaceHolder.FindControl("PageParagraph");
        GetBtn = contentPlaceHolder.FindControl("GetBtn") as Button;
        AddBtn = contentPlaceHolder.FindControl("AddBtn") as Button;
        TableContentRow = contentPlaceHolder.FindControl("TableContentRow") as TableHeaderRow;
        GenericAddEditModal = contentPlaceHolder.FindControl("GenericAddEditModal") as PlaceHolder;
        ModalTitleLabel = contentPlaceHolder.FindControl("ModalTitleLabel") as Label;
        BtnModalCloseHeader = contentPlaceHolder.FindControl("btnModalCloseHeader") as LinkButton;
        BtnModalSubmitFooter = contentPlaceHolder.FindControl("btnModalSubmitFooter") as LinkButton;
        BtnModalCloseFooter = contentPlaceHolder.FindControl("btnModalCloseFooter") as LinkButton;
    }

    private void OnClickGetRoutes(object sender, EventArgs e)
    {
        
    }
    
    private void OnClickOpenAddRouteModal(object sender, EventArgs e)
    {
        ModalTitleLabel.Text = "Add Route";
        GenericAddEditModal.Visible = true;
    }

    private void OnClickCloseRouteModal(object sender, EventArgs e)
    {
        GenericAddEditModal.Visible = false;
    }

    private void OnClickOpenEditRouteModal(object sender, EventArgs e)
    {
        ModalTitleLabel.Text = "Edit Route";
        GenericAddEditModal.Visible = true;
    }

}