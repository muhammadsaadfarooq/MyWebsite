using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_product_desp : System.Web.UI.Page
{
    SqlCommand cmd =new SqlCommand();
    SqlConnection conn=new SqlConnection();
    private int id;
    private string product_name, product_desp, product_price, product_qty, product_image;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";

        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("display_items.aspx");
        }
        else
        {
            
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from add_product where id='"+id+"'";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dta);
            rpt.DataSource = dta;
            rpt.DataBind();
            conn.Close();
        }

       



    }

    protected void cart_Click(object sender, EventArgs e)
    {
        conn.Open();
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select *from add_product where id='" + id + "'";
        cmd.ExecuteNonQuery();
        DataTable dta = new DataTable();
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        adpt.Fill(dta);
        foreach (DataRow dtr in dta.Rows)
        {
            product_name = dtr["pro_name"].ToString();
            product_desp = dtr["pro_desp"].ToString();
            product_price = dtr["pro_price"].ToString();
            product_qty = dtr["pro_qua"].ToString();
            product_image = dtr["pro_image"].ToString();
        }

        conn.Close();
        if (Response.Cookies["cart"] == null)
        {
            Response.Cookies["cart"].Value = product_name.ToString() + "," + product_desp.ToString() + "," +
                                             product_image.ToString() + "," + product_price.ToString() + "," +
                                             product_qty.ToString();
            Response.Cookies["cart"].Expires=DateTime.Now.AddDays(1);

        }
        else
        {
            Response.Cookies["cart"].Value = Response.Cookies["cart"].Value +"|"+ product_name.ToString() + "," + product_desp.ToString() + "," +
                                             product_image.ToString() + "," + product_price.ToString() + "," +
                                             product_qty.ToString();
            Response.Cookies["cart"].Expires = DateTime.Now.AddDays(1);
        }
    }
}
}