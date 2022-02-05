using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// BookingPageContent için özet açıklama
/// </summary>
public class BookingPageContent
{
    public static String Column1 = "Flight ID";
    public static String Column2 = "Flight Number";
    public static String Column3 = "Flight Date";
    public static String Column4 = "Departure Airport";
    public static String Column5 = "Arrival Airport";
    public static String Column6 = "Join Flight";
    public static List<String> PAGE_CONTENT_HEADER_ROW = new List<string>() { Column1, Column2, Column3, Column4, Column5, Column6 };
    
    public static void SetPageContent(TableHeaderRow tableContentRow)
    {
        foreach (String s in PAGE_CONTENT_HEADER_ROW)
        {
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = s;
            tableContentRow.Cells.Add(cell);
        }
    }
}