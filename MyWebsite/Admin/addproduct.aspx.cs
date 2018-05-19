using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Admin_addproduct : System.Web.UI.Page
{
    SqlCommand cmd =new SqlCommand();
    SqlConnection conn =new SqlConnection();
    SqlDataAdapter sda =new SqlDataAdapter();
    DataSet data_set =new DataSet();
    private string imagepath;

    protected void Page_Load(object sender, EventArgs e)
    {
        conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        conn.Open();
    }

    protected void add_button_Click(object sender, EventArgs e)
    {
        image_upload.SaveAs(Request.PhysicalApplicationPath+ "./images/" + image_upload.FileName.ToString());
        imagepath = "./images/" + image_upload.FileName.ToString();
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText="insert into add_product values('"+name.Text+"','"+desp.Text+"',"+price.Text+","+quantity.Text+",'"+imagepath.ToString()+"')";
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}