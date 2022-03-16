using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// JSON_Class 的摘要描述
/// </summary>
public class JSON_Class
{
    private static readonly ILog log = LogManager.GetLogger(typeof(JSON_Class));
    public JSON_Class()
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
    }

    public DataTable getFinance_L1()
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da;
            string commandStr;
            string connectString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            log.Debug("ConnectionString - " + connectString);
            cn.ConnectionString = connectString;
            commandStr = "select * from [Finance_L1] order by [L2_link]";
            try
            {
                cn.Open();
                da = new SqlDataAdapter(commandStr, cn);
                da.Fill(dt);
                log.Debug("dt.count - " + dt.Rows.Count.ToString());
                //log.Debug("dt.value - " + dt.Rows[0][4]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error - " + ex.Message);
                log.Error("DB connect error!!");
            }
            finally
            {
                da = null;
                cn.Close();
                cn = null;
            }
        }
        catch (Exception ex)
        {
            log.Error("call WS(Finance_L1) error - " + ex.Message);
        }
        return dt;
    }

    public DataTable getFinance_L2(string L2_link)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da;
            string commandStr;
            string connectString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            log.Debug("ConnectionString - " + connectString);
            cn.ConnectionString = connectString;
            commandStr = "select * from [Finance_L2]  where  [L2_link] = '" + L2_link + "' order by [L3_link]";
            try
            {
                cn.Open();
                da = new SqlDataAdapter(commandStr, cn);
                da.Fill(dt);
                log.Debug("dt.count - " + dt.Rows.Count.ToString());
                //log.Debug("dt.value - " + dt.Rows[0][4]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error - " + ex.Message);
                log.Error("DB connect error!!");
            }
            finally
            {
                da = null;
                cn.Close();
                cn = null;
            }
        }
        catch (Exception ex)
        {
            log.Error("call WS(Finance_L2) error - " + ex.Message);
        }
        return dt;
    }

    public DataTable getFinance_L3(string L3_link)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da;
            string commandStr;
            string connectString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            log.Debug("ConnectionString - " + connectString);
            cn.ConnectionString = connectString;
            commandStr = "select * from [Finance_L3]  where  [L3_link] = '" + L3_link + "' order by [L3_link]";
            try
            {
                cn.Open();
                da = new SqlDataAdapter(commandStr, cn);
                da.Fill(dt);
                log.Debug("dt.count - " + dt.Rows.Count.ToString());
                //log.Debug("dt.value - " + dt.Rows[0][4]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error - " + ex.Message);
                log.Error("DB connect error!!");
            }
            finally
            {
                da = null;
                cn.Close();
                cn = null;
            }
        }
        catch (Exception ex)
        {
            log.Error("call WS(Finance_L3) error - " + ex.Message);
        }
        return dt;
    }

    public DataTable getMedical_record_L2()
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da;
            string commandStr;
            string connectString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            log.Debug("ConnectionString - " + connectString);
            cn.ConnectionString = connectString;
            commandStr = "select * from [Medical_record_L2] order by [L3_link]";
            try
            {
                cn.Open();
                da = new SqlDataAdapter(commandStr, cn);
                da.Fill(dt);
                log.Debug("dt.count - " + dt.Rows.Count.ToString());
                //log.Debug("dt.value - " + dt.Rows[0][4]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error - " + ex.Message);
                log.Error("DB connect error!!");
            }
            finally
            {
                da = null;
                cn.Close();
                cn = null;
            }
        }
        catch (Exception ex)
        {
            log.Error("call WS(getMedical_record_L2) error - " + ex.Message);
        }
        return dt;
    }

    public DataTable getMedical_record_L3(string L3_link)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da;
            string commandStr;
            string connectString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //log.Debug("ConnectionString - " + connectString);
            cn.ConnectionString = connectString;
            commandStr = "select * from [Medical_record_L3] where  [L3_link] = '" + L3_link + "' order by [L3_link], [L4_link]";
            try
            {
                cn.Open();
                da = new SqlDataAdapter(commandStr, cn);
                da.Fill(dt);
                log.Debug("dt.count - " + dt.Rows.Count.ToString());
                //log.Debug("dt.value - " + dt.Rows[0][4]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error - " + ex.Message);
                log.Error("DB connect error!!");
            }
            finally
            {
                da = null;
                cn.Close();
                cn = null;
            }
        }
        catch (Exception ex)
        {
            log.Error("call WS(getMedical_record_L3) error - " + ex.Message);
        }
        return dt;
    }

    public DataTable getMedical_record_L4(string L4_link)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da;
            string commandStr;
            string connectString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //log.Debug("ConnectionString - " + connectString);
            cn.ConnectionString = connectString;
            commandStr = "select * from [Medical_record_L4] where  [L4_link] = '" + L4_link + "' order by [L4_link]";
            try
            {
                cn.Open();
                da = new SqlDataAdapter(commandStr, cn);
                da.Fill(dt);
                log.Debug("dt.count - " + dt.Rows.Count.ToString());
                //log.Debug("dt.value - " + dt.Rows[0][4]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error - " + ex.Message);
                log.Error("DB connect error!!");
            }
            finally
            {
                da = null;
                cn.Close();
                cn = null;
            }
        }
        catch (Exception ex)
        {
            log.Error("call WS(getMedical_record_L4) error - " + ex.Message);
        }
        return dt;
    }
}