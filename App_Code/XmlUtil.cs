using System;
using System.Xml;
using System.IO;
using System.Diagnostics;

public class XmlUtil
{
	public XmlUtil()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	public static XmlDocument Parse(string fileName)
	{
		try
		{
			XmlDocument Xdoc = new XmlDocument();
			XmlTextReader reader = new XmlTextReader(fileName);
			reader.Read();
			Xdoc.Load(reader);
			reader.Close();
			return Xdoc;
		}
		catch(Exception ex)
		{
			//ignore error
			Debug.WriteLine("error(XmlUtil) - " + ex.Message);
			return null;
		}

		
	}
	
	/// <summary>
	/// Convert the parsed XmlDocument object into string
	/// </summary>
	/// <param name="Xdoc">parsed XmlDocument object</param>
	/// <returns>XML in string</returns>
	public static string WriteXmlToString(XmlDocument Xdoc)
	{
		try
		{
			StringWriter strWriter = new StringWriter();
			XmlTextWriter xw = new XmlTextWriter(strWriter);
			Xdoc.WriteTo(xw);
			return strWriter.ToString();
		}
		catch(Exception ex)
		{
			//ignore error
			Debug.WriteLine("error(XmlUtil) - " + ex.Message);
			return string.Empty;
		}
	}
}
