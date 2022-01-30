using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;

public partial class Terminal_Pages_TerminalRoutesPage_Routes : System.Web.UI.Page
{
    private Label PageTitle;
    private Label PageParagraph;
    private Button GetBtn;
    private Button AddBtn;
    private Table ContentTable;
    private TableHeaderRow TableContentRow;
    private PlaceHolder GenericAddEditModal;
    private Label ModalTitleLabel;
    private LinkButton BtnModalCloseHeader;
    private LinkButton BtnModalSubmitFooter;
    private LinkButton BtnModalCloseFooter;

    private RoutesController _routesController = new RoutesController();
    private AirportController _airportController = new AirportController();

    protected void Page_Load(object sender, EventArgs e)
    {
        ReadyTheControls();
        RoutesPageContent.SetPageContent(PageTitle, PageParagraph, GetBtn, AddBtn, TableContentRow);

        GetBtn.Click += new EventHandler(OnClickGetRoutes);
        AddBtn.Click += new EventHandler(OnClickOpenAddRouteModal);
        BtnModalCloseHeader.Click += new EventHandler(OnClickCloseRouteModal);
        BtnModalCloseFooter.Click += new EventHandler(OnClickCloseRouteModal);

        BtnModalSubmitFooter.Click += new EventHandler(AddRoute);

        GetRoutes();
    }
    
    private void ReadyTheControls()
    {
        ContentPlaceHolder contentPlaceHolder = Master.Master.Master.FindControl("ContentPlaceHolder1").FindControl("contents") as ContentPlaceHolder;

        PageTitle = (Label) contentPlaceHolder.FindControl("PageTitle");
        PageParagraph = (Label) contentPlaceHolder.FindControl("PageParagraph");
        GetBtn = contentPlaceHolder.FindControl("GetBtn") as Button;
        AddBtn = contentPlaceHolder.FindControl("AddBtn") as Button;
        ContentTable = contentPlaceHolder.FindControl("ContentTable") as Table;
        TableContentRow = contentPlaceHolder.FindControl("TableContentRow") as TableHeaderRow;
        GenericAddEditModal = contentPlaceHolder.FindControl("GenericAddEditModal") as PlaceHolder;
        ModalTitleLabel = contentPlaceHolder.FindControl("ModalTitleLabel") as Label;
        BtnModalCloseHeader = contentPlaceHolder.FindControl("btnModalCloseHeader") as LinkButton;
        BtnModalSubmitFooter = contentPlaceHolder.FindControl("btnModalSubmitFooter") as LinkButton;
        BtnModalCloseFooter = contentPlaceHolder.FindControl("btnModalCloseFooter") as LinkButton;
        
        GetRoutes();
    }

    private void OnClickGetRoutes(object sender, EventArgs e)
    {
        GetRoutes();
    }

    private void GetAirports()
    {
        airportList1In.Items.Clear();
        airportList2In.Items.Clear();

        foreach (Airport airport in _airportController.GetAirports())
        {
            ListItem listItem = _airportController.AirportToListItem(airport);
            
            airportList1In.Items.Add(listItem);
            airportList2In.Items.Add(listItem);
        }
    }
    
    private void GetRoutes()
    {
        ClearList();
        
        foreach (Routes routes in _routesController.GetRoutes())
        {
            routes.ArrivalAirport = _airportController.GetAirportById(routes.ArrivalAirport.ID);
            routes.DepartureAirport = _airportController.GetAirportById(routes.DepartureAirport.ID);
            
            TableRow tableRow = _routesController.ToTableRow(routes);
            
            TableCell removeButtonCell = new TableCell();
            Button removeButton = new Button();
            removeButton.Text = "Remove";
            removeButton.Click += new EventHandler(OnClickDeleteRoute);
            removeButtonCell.Controls.Add(removeButton);

            tableRow.Cells.Add(removeButtonCell);
            ContentTable.Rows.Add(tableRow);
        }
    }

    private void OnClickDeleteRoute(object sender, EventArgs e)
    {
        using (Button button = sender as Button)
        {
            using (TableRow tableRow = button.Parent.Parent as TableRow)
            {
                if (_routesController.DeleteRoute(Convert.ToInt64(tableRow.Cells[0].Text)))
                {
                    MessageBox("Route successfully deleted");
                }
                else
                {
                    MessageBox("Route deletion is declined");
                }
            }
        }
    }
    
    private void OnClickOpenAddRouteModal(object sender, EventArgs e)
    {
        GetAirports();
        ModalTitleLabel.Text = "Add Route";
        GenericAddEditModal.Visible = true;
    }

    private void OnClickCloseRouteModal(object sender, EventArgs e)
    {
        GenericAddEditModal.Visible = false;
    }
    
    private void ClearList()
    {
        ContentTable.Rows.Clear();

        ContentTable.Rows.Add(TableContentRow);
    }

    private void MessageBox(String message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }

    private void AddRoute(object sender, EventArgs e)
    {
        Routes routes = new Routes();
        routes.ArrivalAirport = new Airport();
        routes.DepartureAirport = new Airport();
        routes.DepartureAirport.ID = Convert.ToInt64(airportList1In.SelectedValue);
        routes.ArrivalAirport.ID = Convert.ToInt64(airportList2In.SelectedValue);

        if (_routesController.AddRoute(routes))
        {
            MessageBox("Route successfully added");
            GenericAddEditModal.Visible = false;
        }
        else
        {
            MessageBox("Something went wrong");
        }
    }

    protected void airportList1In_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        using (ListBox listBox = sender as ListBox)
        {
            fromAirportNumberIn.Text = listBox.SelectedItem.Text;
        }
    }

    protected void airportList2In_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        using (ListBox listBox = sender as ListBox)
        {
            toAirportNumberIn.Text = listBox.SelectedItem.Text;
        }
    }
}