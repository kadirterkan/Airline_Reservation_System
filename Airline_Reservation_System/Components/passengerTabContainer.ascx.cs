using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Components_passengerTabContainer : System.Web.UI.UserControl
{
    public int ID { get; set; }
    public TextBox NameSurnameInHolder { get; set; }
    public TextBox PassaportNoInHolder { get; set; }
    public RadioButtonList GenderInHolder { get; set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        nameSurnameIn.ID = nameSurnameIn.ID + ID.ToString();
        passaportNoIn.ID = passaportNoIn.ID + ID.ToString();
        genderIn.ID = genderIn.ID + ID.ToString();

        NameSurnameInHolder = nameSurnameIn;
        PassaportNoInHolder = passaportNoIn;
        GenderInHolder = genderIn;
    }
}