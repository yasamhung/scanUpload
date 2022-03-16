using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkBrowserType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    protected void btnA_Click(object sender, EventArgs e)
    {
        if (browserType.Value == "Qt")
        {
            Label1.Text = "EWBV5";
            Session["BrowserType"] = "EWBV5";
        }
        else if (browserType.Value == "Ant")
        {
            Label1.Text = "EWBV4";
            Session["BrowserType"] = "EWBV4";
        }
        else
        {
            Label1.Text = "Error";
            Session["BrowserType"] = browserType.Value;
        }
        Response.Redirect("~/Default.aspx");
    }
}