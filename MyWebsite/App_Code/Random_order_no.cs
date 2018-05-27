using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.IO;

/// <summary>
/// Summary description for Random_order_no
/// </summary>
public class Random_order_no
{
    public Random_order_no()
    {
        
    }
    public string GetRandomString()
    {
        string path = Path.GetRandomFileName();
        path = path.Replace(".", ""); // Remove period.
        return path;
    }
}