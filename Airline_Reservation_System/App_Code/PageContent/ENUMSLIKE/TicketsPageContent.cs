using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// TicketsPageContent için özet açıklama
/// </summary>
public class TicketsPageContent
{
    public static String PAGE_TITLE = "Tickets";
    public static String PAGE_PARAGRAPH = "In this page you will be able to see or delete your tickets";
    public static String PAGE_BUTTON_TEXT = "Tickets";

    public static String Column1 = "Tickets ID";
    public static String Column2 = "Passenger Name";
    public static String Column3 = "Passenger Passport No";
    public static String Column4 = "Flight Class";
    public static String Column5 = "Flight No";
    public static String Column6 = "Flight Departure Airport";
    public static String Column7 = "Flight Departure Time";
    public static String Column8 = "Flight Arrival Airport";
    public static String Column10 = "Remove Ticket";
    public static List<String> PAGE_CONTENT_HEADER_ROW = new List<string>() { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column10 };

    public static void SetPageContent(Label PageTitle, Label PageParagraph, Button GetBtn, TableHeaderRow TableContentRow)
    {
        PageTitle.Text = PAGE_TITLE;
        PageParagraph.Text = PAGE_PARAGRAPH;
        GetBtn.Text = "Get " + PAGE_BUTTON_TEXT;

        foreach (String s in PAGE_CONTENT_HEADER_ROW)
        {
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = s;
            TableContentRow.Cells.Add(cell);
        }
    }
}