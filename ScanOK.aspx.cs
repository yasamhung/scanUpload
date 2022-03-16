using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;


public partial class ScanOK : System.Web.UI.Page
{
    private static readonly ILog log = LogManager.GetLogger(typeof(ScanOK));

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ////log.Debug("scanOK...");
            string UI_width = (string)Session["BrowserType"];
            ////test
            //UI_width = "800";

            log.Debug("UI_Width(2) - " + UI_width);
            if (!string.IsNullOrEmpty(UI_width))
            {
                Session["UI_Width"] = UI_width;
                if (UI_width.Equals("800"))
                {
                    theBody.Style["background-image"] = "url(./images_8/background_2.png)";
                    stylesheet.Attributes["href"] = "./sample_600.css";
                    log.Debug("change background-image - ./images_8/background_2.png");
                }
            }
            else
            {
                Session["UI_Width"] = "1024";
            }
        }        
    }

    protected void next_scan_Click(object sender, ImageClickEventArgs e)
    {
        string scanJob = (string)Session["scanJob"];
        if (scanJob.Equals("Finance"))
        {
            Response.Redirect("Finance_View.aspx");
        }
        else
        {
            Response.Redirect("Nursing_View.aspx");
        }
    }

    protected void home_scan_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
