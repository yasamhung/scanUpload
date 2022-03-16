using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using log4net;
using System.Web.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Services.Protocols;
using Newtonsoft.Json;
using Rebex.Net;

/// <summary>
/// JFS_WS 的摘要描述
/// </summary>
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
// [System.Web.Script.Services.ScriptService]
public class JFS_WS : System.Web.Services.WebService
{
    private static readonly ILog log = LogManager.GetLogger(typeof(JFS_WS));
    public JFS_WS()
    {

        //如果使用設計的元件，請取消註解下列一行
        //InitializeComponent(); 
    }

    [WebMethod]
    [FujiXerox.SwA.WebServiceExtension]
    public string SaveScanFile(string scanDate, string ImageCount, string Ipv4, string SerialNumber)
    {
        try
        {
            log.Info("scanDate - " + scanDate.Trim() + ", SerialNumber - " + SerialNumber.Trim() + ", Ipv4 - " + Ipv4  + ", ImageCount - " + ImageCount);

            //string Tiff_outPath = ConfigurationManager.AppSettings["Tiff_scanPath"];

            string startupPath = Server.MapPath("~");
            startupPath = startupPath + "\\Tiff_outPath\\";
            //string baseFolder = startupPath;
            string baseFolder = startupPath;

            try
            {
                if (!Directory.Exists(startupPath))
                {
                    Directory.CreateDirectory(startupPath);
                }
                if (!Directory.Exists(startupPath))
                {
                    throw new Exception("Folder is Not Found - " + startupPath);
                }

                if (!Directory.Exists(baseFolder))
                {
                    Directory.CreateDirectory(baseFolder);
                }

                // Get the document file attached by SwA
                FujiXerox.SwA.AttachmentCollection collection = FujiXerox.SwA.SwaContext.Attachments;

                if (!Directory.Exists(baseFolder))
                {
                    throw new Exception("Folder is Not Found - " + baseFolder);
                }

                string fileName = "PwC";
                //string fileName_OK = Server.MapPath(@"chk.OK");
                if (collection != null)
                {
                    // Directory path for saving document                  
                    string targetFolder = baseFolder;

                    for (int x = 0; x < collection.Count; ++x)
                    {
                        bool exist = File.Exists(collection[x].Path);
                        //log.Debug("File.Exists - " + collection[x].Path);
                        if (exist)
                        {
                            // 檔案名稱命名規則為「類型2碼(11,12,13,21,22,23,31,32,33)_受理編號12碼_員編_8碼(YYYYMMDD)+4碼(HHMM).pdf」
                            string fileNameBody = Ipv4  + "_" + scanDate;
                            log.Info("fileNameBody - " + fileNameBody);
                            fileName = fileNameBody;
                            int num = 0;
                            bool notyet = true;
                            while (notyet)
                            {
                                try
                                {
                                    // "Attachment" object can only retrieve files with PDF format
                                    File.Copy(collection[x].Path, Path.Combine(targetFolder, fileName + ".tif"), true);  // false
                                    //File.Copy(fileName_OK, Path.Combine(targetFolder, fileName + ".OK"), true);
                                    log.Info("Copy file successful - " + Path.Combine(targetFolder, fileName + ".tif"));
                                    // When a file with the same name already exists,
                                    // raise an exception instead of overwriting the file
                                    notyet = false;

                                    //string strDateFile = String.Format("{0:yyyyMMdd}", DateTime.Now);
                                    //string strFile = startupPath + strDateFile + ".csv";
                                    //StreamWriter wr = new StreamWriter(strFile, true, System.Text.Encoding.Default);
                                    ////string Line1 = fileName + ".tif" + ","  + ImageCount + "," + scanDate + "," + Ipv4;
                                    //string Line1 = fileName + ".tif" + "," + ImageCount + "," + scanDate + "," + Ipv4 + "," + SerialNumber;
                                    //wr.WriteLine(Line1);
                                    //wr.Close();

                                    string useSFTP = ConfigurationManager.AppSettings["useSFTP"];
                                    string ftp_Server = ConfigurationManager.AppSettings["ftp_Server"];
                                    string ftp_Username = ConfigurationManager.AppSettings["ftp_Username"];
                                    string ftp_Pa = ConfigurationManager.AppSettings["ftp_Pa"];
                                    string ftp_UploadPath = ConfigurationManager.AppSettings["ftp_UploadPath"];
                                    if (useSFTP.ToUpper().Trim().Equals("Y"))
                                    {
                                        bool ret = putFileSFTP_Rebex(ftp_Server, ftp_Username, Decryptor_string(ftp_Pa), ftp_UploadPath, Path.Combine(targetFolder, fileName + ".tif"));
                                        if (ret) File.Delete(Path.Combine(targetFolder, fileName + ".tif"));
                                        log.Info("File delete - " + Path.Combine(targetFolder, fileName + ".tif"));
                                    }
                                    else
                                    {
                                        bool ret = putFileFTP_Rebex(ftp_Server, ftp_Username, Decryptor_string(ftp_Pa), ftp_UploadPath, Path.Combine(targetFolder, fileName + ".tif"));
                                        if (ret) File.Delete(Path.Combine(targetFolder, fileName + ".tif"));
                                        log.Info("File delete - " + Path.Combine(targetFolder, fileName + ".tif"));
                                    }

                                }
                                //catch (IOException ex)
                                //{
                                //    // When a file with the same name already exists, create the file using another name
                                //    fileName = fileNameBody + "-" + num.ToString();
                                //    log.Error("fileName error - " + fileName + ", " + ex.Message);
                                //    num = num + 1;
                                //}
                                catch (Exception err)
                                {
                                    log.Error("err(StoreDocument) - " + err.Message);
                                    throw new Exception(err.Message, err);
                                }
                            }
                        }
                    }                                      
                }
                else
                {
                    log.Error("scan collection(StoreDocument) is null.");
                }
            }
            catch (Exception ex)
            {
                //eventLogStorageService.WriteEntry(ex.Message, EventLogEntryType.Warning);
                log.Error("ex(StoreSaveScanFileDocument) - " + ex.Message);
                throw new SoapException(ex.Message, SoapException.ClientFaultCode);
            }
        }
        catch (Exception ex)
        {
            //eventLogStorageService.WriteEntry(ex.Message, EventLogEntryType.Warning);
            log.Error("Error(SaveScanFile) - " + ex.Message);
            throw new SoapException(ex.Message, SoapException.ClientFaultCode);
        }

        return "OK";
    }

    private bool putFileFTP_Rebex(string FTPServer, string ftpUsername, string ftpPa, string filepath, string file)
    {
        try
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            string fileName_2 = Path.GetFileName(file);
            //string[] split = fileName.Split("-".ToCharArray());

            // create client and connect
            Ftp client = new Ftp();
            client.Connect(FTPServer);
            // authenticate
            client.Login(ftpUsername, ftpPa);
            client.ChangeDirectory(filepath);

            log.Info("ftp.GetCurrentDirectory - " + client.GetCurrentDirectory());
            client.PutFile(file, client.GetCurrentDirectory() + "/" + fileName_2);        // get filename from remote to local folder
            log.Info("[FTP] - FTP put file Completed for scan image - " + fileName_2);
            // disconnect
            client.Disconnect();
            Debug.WriteLine("FTP get Files Completed!");
            return true;
        }
        catch (Exception ex)
        {
            log.Error("[FTP] - FTP put error - " + ex.Message);
            Debug.WriteLine("error - " + ex.Message);
            return false;
        }
    }

    private bool putFileSFTP_Rebex(string FTPServer, string ftpUsername, string ftpPa, string filepath, string file)
    {
        try
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            string fileName_2 = Path.GetFileName(file);
            //string[] split = fileName.Split("-".ToCharArray());

            // create client and connect
            using (var sftp = new Rebex.Net.Sftp())
            {
                sftp.Connect(FTPServer);
                // authenticate
                sftp.Login(ftpUsername, ftpPa);
                sftp.ChangeDirectory(filepath);

                log.Info("ftp.GetCurrentDirectory - " + sftp.GetCurrentDirectory());
                sftp.PutFile(file, sftp.GetCurrentDirectory() + "/" + fileName_2);        // get filename from remote to local folder
                log.Info("[SFTP] - SFTP put file Completed for scan image - " + fileName_2);
                // disconnect
                sftp.Disconnect();
                Debug.WriteLine("SFTP get Files Completed!");
            }
            return true;
        }
        catch (Exception ex)
        {
            log.Error("[SFTP] - SFTP put error - " + ex.Message);
            Debug.WriteLine("error - " + ex.Message);
            return false;
        }
    }

    private string Decryptor_string(string hexString)
    {
        return StringEncrypt_AES256.StringEncrypt.aesDecryptBase64(hexString, "FADS中信金");
    }
}
