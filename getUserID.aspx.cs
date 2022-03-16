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

public partial class getUserID : System.Web.UI.Page
{
    //private static readonly ILog log = LogManager.GetLogger(typeof(getUserID));

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Hidden1.Value = ConfigurationManager.AppSettings["redirectURL"];
        }
    }

    protected void btnA_Click(object sender, EventArgs e)
    {
        string s1 = Hidden2.Value.Trim();
        string s_email = Hidden3.Value.Trim();
        //log.Info("user - " + s1 + ", UserEmail - " + s_email);
        string[] split = s_email.Split("@".ToCharArray());    // 去掉 @ 後面 info

        if(false)
        //if (s1 == "")
        {
            Random randObj = new Random();
            s1 = randObj.Next(1, 10).ToString();
            //s1 = "1";
        }
        else
        {
            Session["user_ID"] = s1.Trim();
            //Session["UserEmail"] = split[0].Trim();
            Session["UserEmail"] = s_email;
            //log.Info("user(2) - " + s1 + ", UserEmail(2) - " + s_email);
            Response.Redirect("Default.aspx");
            //Response.Redirect("Default.aspx?uid=" + s1);
            //Server.Transfer("Scan.aspx?uid=571009F02");
        }
    }
}
