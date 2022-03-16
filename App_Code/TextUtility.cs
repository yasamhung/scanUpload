using System;
using System.Web;


public class TextUtility
{
	public TextUtility()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	/// <summary>
	/// Converts the short date format of the input date
	/// </summary>
	/// <param name="datetime">the input datetime</param>
	/// <returns>the datetime in short date format</returns>
	public static string GetDate(DateTime datetime)
	{
		return datetime.Date.ToShortDateString();
	}
	
	/// <summary>
	/// Formats the size from bytes to other unit
	/// </summary>
	/// <param name="size">size in bytes</param>
	/// <returns>Size in other unit</returns>
	public static string FormatSizeUnit(double size)
	{
		string finalValue="";
		double calSize = size;
		if ((size >= 1024) && (size < 1024 * 1024))
		{
			calSize= Math.Round(size /1024, 2); 
			finalValue = calSize.ToString() + "KB";						 
		}
		else
		{
			calSize = Math.Round(size /(1024*1024), 2);
			finalValue = calSize.ToString() + "MB";
		}
		return finalValue;
												 
	}

	/// <summary>
	/// Gets the current application URL
	/// </summary>
	/// <param name="Request">HttpRequest Object</param>
	/// <returns>URL of the current web application</returns>
	public static string GetBaseURL(HttpRequest Request)
	{
		string Port = Request.ServerVariables["SERVER_PORT"];
		if (Port == null || Port == "80" || Port == "443")
			Port = "";
		else
			Port = ":" + Port;

		string Protocol = Request.ServerVariables["SERVER_PORT_SECURE"];

		if (Protocol == null || Protocol == "0")
			Protocol = "http://";
		else
			Protocol = "https://";

		// *** Figure out the base Url which points at the application's root
		string BasePath =  Protocol + Request.ServerVariables["SERVER_NAME"] + Port + Request.ApplicationPath;
		return BasePath;

	}
	
	/// <summary>
	/// Checks the input string parameter is null or emtpy
	/// </summary>
	/// <param name="para">input string for checking</param>
	/// <returns>true if null or emtpy, false otherwise</returns>
	public static bool isEmpty(string para)
	{
		if(para==null)
		{
			return true;
		}
		else if("".Equals(para))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	/// <summary>
	/// Checks the input folder name with "/" as suffix, if no "/" then 
	/// append a "/"
	/// </summary>
	/// <param name="folderName">folder path</param>
	/// <returns>folder path with "/" appeneded</returns>
	public static string AddFolderSlash(string folderName)
	{
		string rtnFolderName = folderName;

		if(folderName.LastIndexOf("\\")!=folderName.Length-1)
		{
			rtnFolderName = folderName + "\\";
		}
		return rtnFolderName;
	}
	
	/// <summary>
	/// Generates the random unique no.
	/// </summary>
	/// <param name="length">the length of the unique no.</param>
	/// <returns>random unique no.</returns>
	public static string GetRandomUniqueNo(int length)
	{
	
		// Get the GUID
		string guidResult = System.Guid.NewGuid().ToString();

		// Remove the hyphens
		guidResult = guidResult.Replace("-", string.Empty);

		// Make sure length is valid
		if (length <= 0 || length > guidResult.Length)
			throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

		// Return the first length bytes
		return guidResult.Substring(0, length);
		

	}
	
	/// <summary>
	/// Checks the input string contains invalid chars
	/// </summary>
	/// <param name="inputString">the input string for checking</param>
	/// <returns>true if contains invalid char, false otherwise</returns>
	public static bool containsInvalidChar(string inputString )
	{
		string invalidChars = "\\/:*?\"<>|";
		for(int i=0 ;i<invalidChars.Length;i++)
		{
			string a= invalidChars.Substring(i,1);
			if(inputString.IndexOf(invalidChars.Substring(i,1))>=0)
			{
				return true;
			}
		}
		
		return false;

	}
}

