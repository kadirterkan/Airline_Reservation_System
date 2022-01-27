using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// AirportPageContent için özet açıklama
/// </summary>
public class AirportPageContent
{
    public static String PAGE_TITLE = "Airport";
    public static String PAGE_PARAGRAPH = "In this page you will be able to see, add, edit and delete airport";
    public static String PAGE_BUTTON_TEXT = "Airport";

    public static String Column1 = "Airport ID";
    public static String Column2 = "Airport Name";
    public static String Column3 = "Airport Country";
    public static String Column4 = "Airport City";
    public static String Column5 = "Airport IATA Code";
    public static String Column6 = "Remove Airport";
    public static List<String> PAGE_CONTENT_HEADER_ROW = new List<string>() {Column1, Column2, Column3, Column4, Column5, Column6};

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