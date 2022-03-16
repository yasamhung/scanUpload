using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorMsg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        errorMessage.Text = (string)Session["errorMsg"];
    }
    protected void errorPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}