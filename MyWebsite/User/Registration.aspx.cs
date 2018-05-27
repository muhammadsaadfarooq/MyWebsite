using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void register_Click(object sender, EventArgs e)
    {
        SqlCommand cmd =new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        conn.Open();
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into register_user values ('" + name + "','" + TextBox1+ "','" + TextBox2 + "','" + TextBox3 + "','" + TextBox4 + "','" + TextBox5 + "','" + TextBox6 + "','" + TextBox7 + "','" + TextBox8 + "') ";
        cmd.ExecuteNonQuery();
        conn.Close();
        ll.Text = "Congratulation, Registered Sucessfully";
    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
}