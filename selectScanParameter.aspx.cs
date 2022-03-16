using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

public partial class selectScanParameter : System.Web.UI.Page
{
    private static readonly ILog log = LogManager.GetLogger(typeof(selectScanParameter));

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string uid = Convert.ToString(Session["user_ID"]);
            uid = uid.Trim();
            //log.Info(uid);
            user_text1.Text = uid;

            if (Session["BrowserType"] == null)
            {
                Response.Redirect("checkBrowserType/checkBrowserType.aspx");
            }
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

            if (Session["color_mode_select_index"] != null)
            {
                color_mode_select.SelectedIndex = (int)Session["color_mode_select_index"];
                duplex_select.SelectedIndex = (int)Session["duplex_select_index"];
                resolution_select.SelectedIndex = (int)Session["resolution_select_index"];
                size_select.SelectedIndex = (int)Session["size_select_index"];
                ratio_select.SelectedIndex = (int)Session["ratio_select_index"];
                mixed_size_select.SelectedIndex = (int)Session["mixed_size_select_index"];

                imageMode_select.SelectedIndex = (int)Session["imageMode_select_index"];
                darkness_select.SelectedIndex = (int)Session["darkness_select_index"];
            }
        }
    }
    protected void start_scan_button_1_Click(object sender, ImageClickEventArgs e)
    {
        Session["color_mode_select_index"] = color_mode_select.SelectedIndex;
        Session["color_mode_select_value"] = color_mode_select.Value;

        Session["duplex_select_index"] = duplex_select.SelectedIndex;
        Session["duplex_select_value"] = duplex_select.Value;

        Session["imageMode_select_index"] = imageMode_select.SelectedIndex;
        Session["imageMode_select_value"] = imageMode_select.Value;

        Session["darkness_select_index"] = darkness_select.SelectedIndex;
        Session["darkness_select_value"] = darkness_select.Value;

        Session["resolution_select_index"] = resolution_select.SelectedIndex;
        Session["resolution_select_value"] = resolution_select.Value;

        Session["size_select_index"] = size_select.SelectedIndex;
        Session["size_select_value"] = size_select.Value;

        Session["ratio_select_index"] = ratio_select.SelectedIndex;
        Session["ratio_select_value"] = ratio_select.Value;

        Session["mixed_size_select_index"] = mixed_size_select.SelectedIndex;
        Session["mixed_size_select_value"] = mixed_size_select.Value;

        Response.Redirect("scanDoc1_click.aspx");
    }
    protected void back_button_1_Click(object sender, ImageClickEventArgs e)
    {
        //string scanJob = (string)Session["scanJob"];
        //if (scanJob.Equals("Finance"))
        //{
        //    Response.Redirect("Finance_View.aspx");
        //}
        //else
        //{
        //    Response.Redirect("Nursing_View.aspx");
        //}

        Response.Redirect("Default.aspx");
    }
}