using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;

public partial class Terminal_Pages_Aircraft_Aircraft : System.Web.UI.Page
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
    
    private AircraftController _aircraftController = new AircraftController();
    private Aircraft newAircraft = new Aircraft();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ReadyTheControls();
        AircraftPageContent.SetPageContent(PageTitle, PageParagraph, GetBtn, AddBtn, TableContentRow);

        GetBtn.Click += new EventHandler(OnClickGetAircrafts);
        AddBtn.Click += new EventHandler(OnClickOpenAddAircraftModal);
        BtnModalCloseHeader.Click += new EventHandler(OnClickCloseAircraftModal);
        BtnModalCloseFooter.Click += new EventHandler(OnClickCloseAircraftModal);

        BtnModalSubmitFooter.Click += new EventHandler(AddAircraft);
        
        GetAircrafts();
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
    }

    private void OnClickGetAircrafts(object sender, EventArgs e)
    {
        ClearList();

        GetAircrafts();
    }

    private void GetAircrafts()
    {
        foreach (Aircraft aircraft in _aircraftController.GetAircrafts())
        {
            TableRow tableRow = _aircraftController.ToTableRow(aircraft);
            
            Button editButton = new Button();
            editButton.Text = "Edit Aircraft";
            editButton.Click += new EventHandler(EditAircraft);
            TableCell editButtonCell = new TableCell();
            editButtonCell.Controls.Add(editButton);

            Button removeButton = new Button();
            removeButton.Text = "Remove Aircraft";
            removeButton.Click += new EventHandler(DeleteAircraft);
            TableCell removeButtonCell = new TableCell();
            removeButtonCell.Controls.Add(removeButton);

            tableRow.Cells.Add(editButtonCell);
            tableRow.Cells.Add(removeButtonCell);

            ContentTable.Rows.Add(tableRow);
        }
    }
    
    private void ClearList()
    {
        ContentTable.Rows.Clear();

        ContentTable.Rows.Add(TableContentRow);
    }
    
    private void OnClickOpenAddAircraftModal(object sender, EventArgs e)
    {
        ModalTitleLabel.Text = "Add Aircraft";
        Application["mode"] = "ADD";
        GenericAddEditModal.Visible = true;
    }

    private void AddAircraft(object sender, EventArgs e)
    {
        newAircraft.TailNumber = tailNumberIn.Text;
        newAircraft.AircraftManufacturer = aircraftManufacturerIn.Text;
        newAircraft.AircraftModel = aircraftModelIn.Text;
        newAircraft.DateOfManufacture = Convert.ToDateTime(dateOfManufactureIn.Text);
        newAircraft.PlaneEconomyCapacity = Convert.ToInt32(economyClassCapacityIn.Text);
        newAircraft.PlaneBusinessCapacity = Convert.ToInt32(businessClassCapacityIn.Text);

        if (Application["mode"].Equals("ADD"))
        {
            if (_aircraftController.AddAircraft(newAircraft))
            {
                MessageBox("You have successfully added aircraft");
                GenericAddEditModal.Visible = false;
            }
            else
            {
                MessageBox("Something went wrong");
            }
        }else if (Application["mode"].Equals("EDIT"))
        {
            if (_aircraftController.EditAircraft(newAircraft, Application["editAircraftId"].ToString()))
            {
                MessageBox("You have successfully edited aircraft");
                GenericAddEditModal.Visible = false;
            }
            else
            {
                MessageBox("Something went wrong");
            }
        }
    }

    private void DeleteAircraft(object sender, EventArgs e)
    {
        using (Button button = sender as Button)
        {
            using (TableRow tableRow = button.Parent.Parent as TableRow)
            {
                if (_aircraftController.DeleteAircraft(Convert.ToInt64(tableRow.Cells[0].Text)))
                {
                    MessageBox("Aircraft successfully deleted");
                }
                else
                {
                    MessageBox("Aircraft deletion has been declined");
                }
            }
        }
    }

    private void EditAircraft(object sender, EventArgs e)
    {
        ModalTitleLabel.Text = "Edit Aircraft";
        Application["mode"] = "EDIT";
        GenericAddEditModal.Visible = true;

        using (Button button = sender as Button)
        {
            using (TableRow tableRow = button.Parent.Parent as TableRow)
            {
                tailNumberIn.Text = tableRow.Cells[1].Text;
                aircraftManufacturerIn.Text = tableRow.Cells[2].Text;
                aircraftModelIn.Text = tableRow.Cells[3].Text;
                dateOfManufactureIn.Text = Convert.ToDateTime(tableRow.Cells[4].Text).ToString();
                businessClassCapacityIn.Text = tableRow.Cells[5].Text;
                economyClassCapacityIn.Text = tableRow.Cells[6].Text;
                Application["editAircraftId"] = tableRow.Cells[0].Text;
            }
        }
    }

    private void OnClickCloseAircraftModal(object sender, EventArgs e)
    {
        GenericAddEditModal.Visible = false;
    }

    private void OnClickOpenEditAircraftModal(object sender, EventArgs e)
    {
        ModalTitleLabel.Text = "Edit Aircraft";
        GenericAddEditModal.Visible = true;
    }

    private void MessageBox(String message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }
}