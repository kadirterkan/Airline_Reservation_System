using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Pages_HomePage_HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (int index in Enumerable.Range(0, 10))
        {
            ListItem listItem = new ListItem(index.ToString(), index.ToString());
            if (index == 0)
            {
                listItem.Selected = true;
            }
            selectCountry.Items.Insert(index, listItem);
            selectAirport.Items.Insert(index, listItem);
            childrenList.Items.Insert(index, listItem);
            adultsList.Items.Insert(index, listItem);
        }
    }
}