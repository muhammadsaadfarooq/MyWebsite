using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class User_update_order_details : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd =new SqlCommand();
    SqlDataAdapter _sda = new SqlDataAdapter();
    DataSet _dataSet = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        conn.ConnectionString =    
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        conn.Open();

        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select *from register_user where email='" + Session["log"].ToString() + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da=new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow drow in dt.Rows)
        {
            name.Text = drow["firstname"].ToString();
            TextBox1.Text = drow["lastname"].ToString();
            TextBox4.Text = drow["Address"].ToString();
            TextBox5.Text = drow["city"].ToString();
            TextBox6.Text = drow["state"].ToString();
            TextBox8.Text = drow["mobile"].ToString();
        }
        conn.Close();
    }

    protected void update_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection();
        conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        conn.Open();
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update register_user set firstname='" + name.Text + "', lastname='" + TextBox1.Text + "',Address='" + TextBox4.Text + "',city='" + TextBox5.Text + "',state='" + TextBox6.Text + "',mobile='" + TextBox8.Text + "'";
        cmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect("payment.aspx");


    }
}