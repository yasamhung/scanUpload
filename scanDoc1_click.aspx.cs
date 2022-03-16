using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Xml;
using System.Diagnostics;
using System.Data;
using Newtonsoft.Json;
using log4net;

public partial class scanDoc1_click : System.Web.UI.Page
{
    private static readonly ILog log = LogManager.GetLogger(typeof(scanDoc1_click));
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string color_mode = (string)Session["color_mode_select_value"];
            string duplex = (string)Session["duplex_select_value"];
            string resolution = (string)Session["resolution_select_value"];
            string size = (string)Session["size_select_value"];
            string ratio = (string)Session["ratio_select_value"];
            string mixed_size = (string)Session["mixed_size_select_value"];
            string imageMode = (string)Session["imageMode_select_value"];
            string darkness = (string)Session["darkness_select_value"];

            //string user_ID = (string)Session["user_ID"];

            Debug.WriteLine("ending...");

            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc = XmlUtil.Parse(Server.MapPath("Swa_WebService_PwC.xml"));

                //=================================================================================//
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
                nsmgr.AddNamespace("jt", LocalNameSpace.JT);
                nsmgr.AddNamespace("soapENV", LocalNameSpace.SOAPENV);
                nsmgr.AddNamespace("SoapENV", LocalNameSpace.SOAPENV);
                nsmgr.AddNamespace("soap", LocalNameSpace.SOAP);
                nsmgr.AddNamespace("otjt", LocalNameSpace.otjt);
                //=================================================================================//

                string selectPath;
                XmlNode selectNode;

                // update color_mode
                selectPath = "//jt:Scanner/jt:ColorMode";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = color_mode;

                // update duplex
                selectPath = "//jt:Scanner/jt:Duplex";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = duplex;

                // update resolution
                selectPath = "//jt:Scanner/jt:Resolution";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = resolution;

                // update ratio
                selectPath = "//jt:Scanner/jt:Magnification/jt:Isotropic";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = ratio;

                if (mixed_size.Equals("true"))    // mixed_size.Equals("true")
                {
                    // update size
                    selectPath = "//jt:Scanner/jt:InputMediumSize/jt:StandardMediumSize";
                    selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                    selectNode.InnerText = "Mixed";
                }
                else
                {
                    // update size
                    selectPath = "//jt:Scanner/jt:InputMediumSize/jt:StandardMediumSize";
                    selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                    selectNode.InnerText = size;
                }

                // update imageMode
                selectPath = "//jt:Scanner/jt:ImageMode";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = imageMode;

                // update darkness
                selectPath = "//jt:Scanner/jt:Darkness";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = darkness;

                // update scanDate
                string strDate = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                selectPath = "//otjt:SaveScanFile/otjt:scanDate";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = strDate;

                //// update CompanyCode
                //string CompanyCode = Level_Select_5;
                //selectPath = "//otjt:SaveScanFile/otjt:CompanyCode";
                //selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                //selectNode.InnerText = CompanyCode;

                //// update DocumentType
                //string DocumentType = Level_Select_6;
                //selectPath = "//otjt:SaveScanFile/otjt:DocumentType";
                //selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                //selectNode.InnerText = DocumentType;

                ////update the "userID"
                //selectPath = "//otjt:UserID/node()";
                //selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                //selectNode.InnerText = user_ID;

                //update the "scanJob"
                //selectPath = "//otjt:scanJob/node()";
                //selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                //selectNode.InnerText = scanJob;

                //=================================================================================//

                //update the SoapBody "Invoke target"
                string wshttpURL = ConfigurationManager.AppSettings["WebServiceURL"];
                string target = wshttpURL;
                selectPath = "//jt:Invoke/jt:Profile/jt:Target";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = target;

                //update the SoapBody "Invoke target Location"
                string loc = wshttpURL + "?WSDL";
                selectPath = "//jt:Invoke/jt:Profile/jt:Schema/jt:Location";
                selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                selectNode.InnerText = loc;

                ////update the SoapBody "smb_Path"
                //string smb_Path = ConfigurationManager.AppSettings["ftp_Path"];
                //selectPath = "//jt:DocumentProcess/jt:Distribute/jt:Destinations/jt:FileTransfer/jt:Repository";
                //selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                //selectNode.InnerText = smb_Path;

                ////update the SoapBody "username"
                //string smb_Username = ConfigurationManager.AppSettings["ftp_Username"];
                //selectPath = "//jt:DocumentProcess/jt:Distribute/jt:Destinations/jt:FileTransfer/jt:AuthInfo/jt:OperatorName";
                //selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                //selectNode.InnerText = smb_Username;

                ////update the SoapBody "username"
                //string smb_Password = ConfigurationManager.AppSettings["ftp_Password"];
                //selectPath = "//jt:DocumentProcess/jt:Distribute/jt:Destinations/jt:FileTransfer/jt:AuthInfo/jt:Password";
                //selectNode = xdoc.SelectSingleNode(selectPath, nsmgr);
                //selectNode.InnerText = smb_Password;
                //log.Debug("wshttpURL - " + wshttpURL);

                //MemoryStream memStream = new MemoryStream();
                //xdoc.Save("d:\\testJFS.xml");
                xdoc.Save(Response.OutputStream);

                //=================================================================================//

                //send the Job flow sheet to the Apeos
                Response.ContentType = "application/vnd.fujixerox.jfi+xml";
                //Response.AppendHeader("Server", "FX-EWB-Compatible/4.0");
                //string BrowserType = (string)Session["BrowserType"];
                //if (BrowserType.Equals("EWBV4"))
                //{
                    Response.AddHeader("Return-Path", TextUtility.GetBaseURL(Request) + "/ScanOK.aspx");
                //}
                //else
                //{
                //    Response.AddHeader("Return-Path", TextUtility.GetBaseURL(Request) + "/ScanOK_V5.aspx");
                //}
                Response.End();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error - " + ex.Message);
            }
        }
    }

    protected string Replace(string oldString)
    {
        string retStr = oldString.Trim();
        retStr = retStr.Replace("|", "");
        retStr = retStr.Replace("/", "");
        retStr = retStr.Replace("\\", "");
        retStr = retStr.Replace(":", "");
        retStr = retStr.Replace("*", "");
        retStr = retStr.Replace("?", "");
        retStr = retStr.Replace("\"", "");
        retStr = retStr.Replace("<", "");
        retStr = retStr.Replace(">", "");
        //retStr = retStr.Replace("-", "");
        return retStr;
    }
}