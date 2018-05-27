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
        if (Request.QueryString["cat"] == null)
        {
            _cmd.CommandText = "select *from add_product";
        }
        else
        {
            _cmd.CommandText = "select *from add_product where pro_cat= '" + Request.QueryString["cat"].ToString() +
                               "'";

        }

        if (Request.QueryString["cat"] == null && Request.QueryString["search"] != null)
        {
            _cmd.CommandText = "select *from add_product where pro_name like ('%"+ Request.QueryString["search"] + "%')";
        }


            _cmd.ExecuteNonQuery();
            DataTable datTble = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(_cmd);
            sda.Fill(datTble);
            rept.DataSource = datTble;
            rept.DataBind();


            _conn.Close();

        }
    }
