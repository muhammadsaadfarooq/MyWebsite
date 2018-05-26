using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class AdminAdminLogin : System.Web.UI.Page
{
    SqlCommand _cmd = new SqlCommand();
    SqlConnection _conn = new SqlConnection();
    SqlDataAdapter _sda = new SqlDataAdapter();
    DataSet _dataSet = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        _conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        _conn.Open();
    }

    protected void b1_Click(object sender, EventArgs e)
    {
     
        
        SqlCommand cmd = _conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select *from validation where username='" + t1.Text + "' and password='" + t2.Text + "'";

        cmd.Connection = _conn;
        _sda.SelectCommand = cmd;
        _sda.Fill(_dataSet, "auth");
        if (_dataSet.Tables[0].Rows.Count > 0)
        {
            Response.Redirect("addproduct.aspx");
        }
        else
        {
            Response.Redirect("Admin-Login.aspx");
        }

        _conn.Close();

    }
}

