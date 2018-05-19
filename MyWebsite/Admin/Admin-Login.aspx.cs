using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_Admin_Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ShoppingDatabase.mdf;Integrated Security=True");
    private int counter;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void b1_Click(object sender, EventArgs e)
    {
        counter = 0;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from valid";
        cmd.CommandText = " where username='" +t1.Text+"'and password='"+t2.Text+"'";
        
        cmd.ExecuteNonQuery();
       
        DataTable datatable = new DataTable();
        SqlDataAdapter dataadptr =new SqlDataAdapter();
        dataadptr.Fill(datatable);
        counter = Convert.ToInt32(datatable.Rows.Count.ToString());

        if (counter == 1)
        {
            Response.Redirect("tester.aspx");
        }
        else
        {
            lb1.Text = "Soryy Wrong UserName or Password ";
        }

        con.Close();

    }
}

