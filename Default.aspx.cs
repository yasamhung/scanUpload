using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Encrypt_Utility_Class;
using System.Xml.Serialization;
using System.Configuration;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
public partial class _Default : System.Web.UI.Page
{
    private static readonly ILog log = LogManager.GetLogger(typeof(_Default));
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Encrypt_Utility EU = new Encrypt_Utility();
            string path_2 = Server.MapPath("~/bin");
            EU.setLicenseAndLogFilePath(path_2, path_2);
            bool ret = EU.IsLicenseValid();

            if (!ret)
            {
                Session["errorMsg"] = "SW License Key error!";
                Response.Redirect("ErrorMsg.aspx");
            }
            else
            {
                Response.Redirect("selectScanParameter.aspx");

                // Test
                //Session["user_ID"] = "chunhsiung.lee";

                //if (Session["user_ID"] == null)
                //{
                //    Server.Transfer("getUserID.aspx");
                //}
                //string UserEmail = "";
                string uid = (string)Session["user_ID"];
                uid = uid.Trim();
                //log.Info("user - " + uid);
                if (!string.IsNullOrEmpty(uid))
                {
                    //UserEmail = (string)Session["UserEmail"];
                    //UserEmail = UserEmail.Trim();
                    //log.Info("user - " + uid);
                    //log.Info("user - " + uid + ", UserEmail - " + UserEmail);

                    Session["selectUID"] = uid;
                    //Session["selectUIDname"] = uid;

                    // 版本管理
                    log.Info("*****  edition(v107), user - " + uid);
                    Response.Redirect("selectScanParameter.aspx");
                }
                else
                {
                    Session["errorMsg"] = "未取得使用者 ID ?";
                    Response.Redirect("ErrorMsg.aspx");
                }
            }           
        }
    }

    protected void back_button_1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void start_scan_button_1_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}