using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// FlightsPageContent için özet açıklama
/// </summary>
public class FlightsPageContent
{
    public static String PAGE_TITLE = "Flights";
    public static String PAGE_PARAGRAPH = "In this page you will be able to see, add, edit and delete flights";
    public static String PAGE_BUTTON_TEXT = "Flights";

    public static String Column1 = "Flight ID";
    public static String Column2 = "Flight Number";
    public static String Column3 = "Flight Date";
    public static String Column4 = "Departure Airport";
    public static String Column5 = "Arrival Airport";
    public static String Column6 = "Economic Class Attenders";
    public static String Column7 = "Bussiness Class Attenders";
    public static String Column8 = "Edit Flight";
    public static String Column9 = "Remove Flight";
    public static List<String> PAGE_CONTENT_HEADER_ROW = new List<string>() {Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9};
    
    public static void SetPageContent(Label PageTitle, Label PageParagraph, Button GetBtn, Button AddBtn, TableHeaderRow TableContentRow)
    {
        PageTitle.Text = PAGE_TITLE;
        PageParagraph.Text = PAGE_PARAGRAPH;
        GetBtn.Text = "Get " + PAGE_BUTTON_TEXT;
        AddBtn.Text = "Add " + PAGE_BUTTON_TEXT;

        foreach (String s in PAGE_CONTENT_HEADER_ROW)
        {
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = s;
            TableContentRow.Cells.Add(cell);
        }
    }
}