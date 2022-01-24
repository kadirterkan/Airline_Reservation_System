using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// AircraftPageContent için özet açıklama
/// </summary>
public class AircraftPageContent
{
    public static String PAGE_TITLE = "Aircraft";
    public static String PAGE_PARAGRAPH = "In this page you will be able to see, add, edit and delete aircafts";
    public static String PAGE_BUTTON_TEXT = "Aircraft";

    public static String Column1 = "Aircraft ID";
    public static String Column2 = "Aircraft Tail Number";
    public static String Column3 = "Aircraft Manufacturer";
    public static String Column4 = "Aircraft Model";
    public static String Column5 = "Date Of Manufacture";
    public static String Column6 = "Economic Class Capacity";
    public static String Column7 = "Business Class Capacity";
    public static String Column8 = "Edit Aircraft";
    public static String Column9 = "Remove Aircraft";
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