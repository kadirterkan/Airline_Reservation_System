﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control.Flights.Flight.Entities;

public partial class Terminal_Pages_AirportPage_Airport : System.Web.UI.Page
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
    
    private AirportController _airportController = new AirportController();
    private CountryController _countryController = new CountryController();

    private List<Airport> _airports;

    private Airport NewAirport = new Airport();

    protected void Page_Load(object sender, EventArgs e)
    {
        ReadyTheControls();
        AirportPageContent.SetPageContent(PageTitle, PageParagraph, GetBtn, AddBtn, TableContentRow);

        GetBtn.Click += new EventHandler(OnClickGetAirports);
        AddBtn.Click += new EventHandler(OnClickOpenAddAirportModal);
        BtnModalCloseHeader.Click += new EventHandler(OnClickCloseAirportModal);
        BtnModalCloseFooter.Click += new EventHandler(OnClickCloseAirportModal);

        BtnModalSubmitFooter.Click += new EventHandler(AddAirport);
        
        GetAirports();
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

    private void OnClickGetAirports(object sender, EventArgs e)
    {
        GetAirports();
    }
    
    private void OnClickOpenAddAirportModal(object sender, EventArgs e)
    {
        GetCountries();
        ModalTitleLabel.Text = "Add Airport";
        GenericAddEditModal.Visible = true;
    }

    private void OnClickCloseAirportModal(object sender, EventArgs e)
    {
        GenericAddEditModal.Visible = false;
    }

    private void OnClickOpenEditAirportModal(object sender, EventArgs e)
    {
        ModalTitleLabel.Text = "Edit Airport";
        GenericAddEditModal.Visible = true;

        using (TableRow tableRow = sender as TableRow)
        {
            airportNameIn.Text = tableRow.Cells[1].Text;
            airportCityIn.Text = tableRow.Cells[2].Text;
            airportCityIn.Text = tableRow.Cells[3].Text;
        }
    }
    
    private void OnClickDeleteAirportModal(object sender, EventArgs e)
    {
        
    }

    private void AddAirport(object sender, EventArgs e)
    {
        NewAirport.AirportName = airportNameIn.Text;
        NewAirport.AirportCity = airportCityIn.Text;
        NewAirport.IATACode = airportIATAIn.Text;
        if (_airportController.AddAirport(NewAirport))
        {
            MessageBox("Airport successfully added");
        }
        else
        {
            MessageBox("Some problem happened, check your values");
        }
    }

    private void GetCountries()
    {
        CountryList.Items.Clear();

        foreach (Country country in _countryController.GetCountries())
        {
            ListItem listItem = _countryController.CountryToListItem(country);
            CountryList.Items.Add(listItem);
        }
    }

    private void GetAirports()
    {
        ClearList();
        
        foreach (Airport airport in _airportController.GetAirports())
        {
            TableRow tableRow = _airportController.ToTableRow(airport);
            
            TableCell editButtonCell = new TableCell();
            TableCell removeButtonCell = new TableCell();
            Button editButton = new Button();
            Button removeButton = new Button();
            editButton.Text = "Edit";
            removeButton.Text = "Remove";
            editButton.Click += new EventHandler(OnClickOpenEditAirportModal);
            removeButton.Click += new EventHandler(OnClickDeleteAirportModal);
            
            editButtonCell.Controls.Add(editButton);
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

    protected void OnCountrySelected(object sender, EventArgs e)
    {
        using (ListBox listBox = sender as ListBox)
        {
            Country country = new Country();

            if (listBox.SelectedValue.Length != 0)
            {
                country.ID = Convert.ToInt64(listBox.SelectedValue);
                airportCountryIn.Text = listBox.SelectedItem.Text;
                NewAirport.Country = country;
            }
        }
    }
    
    private void MessageBox(String message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }
}