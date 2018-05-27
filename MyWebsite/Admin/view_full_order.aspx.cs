using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_view_full_order : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd1 = new SqlCommand();
    private int id;
    private int total_c;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("customer_order.aspx");
        }
        id = Convert.ToInt32(Request.QueryString["id"].ToString());
        conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        conn.Open();
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select *from order_details where id='"+id+"'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            total_c = Convert.ToInt32(dr["product_price"].ToString()) * Convert.ToInt32(dr["product_qty"]);


        }
        
        r1.DataSource = dt;
        r1.DataBind();
       
        conn.Close();

        ac.Text ="Total Price = " + total_c.ToString();

    }
}