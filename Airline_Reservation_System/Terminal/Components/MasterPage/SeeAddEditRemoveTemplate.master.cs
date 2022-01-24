using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Terminal_Components_MasterPage_SeeAddEditRemoveTemplate : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    public void ReadyTheContent(String pageTitle, String pageParagraph, String buttonText, String getFunctionName, String addFunctionName, List<String> tableHeaders)
    {
        PageTitle.Text = pageTitle;
        PageParagraph.Text = pageParagraph;
        GetBtn.Text = "Get " + buttonText;
        GetBtn.OnClientClick = getFunctionName;
        AddBtn.Text = "Add " + buttonText;
        AddBtn.OnClientClick = addFunctionName;

        foreach (String s in tableHeaders)
        {
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = s;
            TableContentRow.Cells.Add(cell);
        }
    }
}
