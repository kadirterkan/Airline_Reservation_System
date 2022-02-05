using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Flights.Customer.Ticket;

public partial class Customer_Pages_Tickets_Tickets : System.Web.UI.Page
{
    private Label PageTitle;
    private Label PageParagraph;
    private Button GetBtn;
    private Table ContentTable;
    private TableHeaderRow TableContentRow;
    private PlaceHolder GenericAddEditModal;
    private Label ModalTitleLabel;
    private LinkButton BtnModalCloseHeader;
    private LinkButton BtnModalSubmitFooter;
    private LinkButton BtnModalCloseFooter;

    private static TicketController _ticketController = new TicketController();

    protected void Page_Load(object sender, EventArgs e)
    {
        ReadyTheControls();
        TicketsPageContent.SetPageContent(PageTitle, PageParagraph, GetBtn, TableContentRow);
        
        GetBtn.Click += new EventHandler(OnClickGetTickets);

        ClearList();
        GetTickets();
    }

    private void OnClickGetTickets(object sender, EventArgs e)
    {
        ClearList();
        GetTickets();
    }
    
    private void ReadyTheControls()
    {
        ContentPlaceHolder contentPlaceHolder = Master.Master.Master.FindControl("ContentPlaceHolder1").FindControl("contents") as ContentPlaceHolder;

        PageTitle = (Label) contentPlaceHolder.FindControl("PageTitle");
        PageParagraph = (Label) contentPlaceHolder.FindControl("PageParagraph");
        GetBtn = contentPlaceHolder.FindControl("GetBtn") as Button;
        ContentTable = contentPlaceHolder.FindControl("ContentTable") as Table;
        TableContentRow = contentPlaceHolder.FindControl("TableContentRow") as TableHeaderRow;
        GenericAddEditModal = contentPlaceHolder.FindControl("GenericAddEditModal") as PlaceHolder;
        ModalTitleLabel = contentPlaceHolder.FindControl("ModalTitleLabel") as Label;
        BtnModalCloseHeader = contentPlaceHolder.FindControl("btnModalCloseHeader") as LinkButton;
        BtnModalSubmitFooter = contentPlaceHolder.FindControl("btnModalSubmitFooter") as LinkButton;
        BtnModalCloseFooter = contentPlaceHolder.FindControl("btnModalCloseFooter") as LinkButton;
    }

    private void GetTickets()
    {
        // Int64 userId = Convert.ToInt64(Application["userId"]);
        List<Ticket> tickets = _ticketController.GetTicketsByUserId(2);
        
        foreach (Ticket flight in tickets)
        {
            TableRow tableRow = _ticketController.ToTableRow(flight);

            Button removeButton = new Button();
            removeButton.Text = "Remove Flight";
            // removeButton.Click += new EventHandler(DeleteFlight);
            TableCell removeButtonCell = new TableCell();
            removeButtonCell.Controls.Add(removeButton);

            tableRow.Cells.Add(removeButtonCell);

            ContentTable.Rows.Add(tableRow);
        }
    }
    
    private void ClearList()
    {
        ContentTable.Rows.Clear();

        ContentTable.Rows.Add(TableContentRow);
    }
}