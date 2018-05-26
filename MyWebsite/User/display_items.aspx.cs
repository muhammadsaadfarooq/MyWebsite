using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class UserDisplayItems : System.Web.UI.Page
{
    SqlCommand _cmd = new SqlCommand();
    SqlConnection _conn = new SqlConnection();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        _conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        _conn.Open();
        _cmd = _conn.CreateCommand();
        _cmd.CommandType = CommandType.Text;
        _cmd.CommandText = "select *from add_product ";
        _cmd.ExecuteNonQuery();
        DataTable datTble =new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(_cmd);
        sda.Fill(datTble);
        rept.DataSource = datTble;
        rept.DataBind();
      

        _conn.Close();

    }
}