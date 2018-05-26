using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminAddproduct : System.Web.UI.Page
{
    SqlCommand _cmd =new SqlCommand();
    SqlConnection _conn =new SqlConnection();
    SqlDataAdapter _sda =new SqlDataAdapter();
    DataSet _dataSet =new DataSet();
    private string _imagepath;

    protected void Page_Load(object sender, EventArgs e)
    {
        _conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        _conn.Open();
    }

    protected void add_button_Click(object sender, EventArgs e)
    {
        image_upload.SaveAs(Request.PhysicalApplicationPath+ "./images/" + image_upload.FileName.ToString());
        _imagepath = "./images/" + image_upload.FileName.ToString();
        _cmd = _conn.CreateCommand();
        _cmd.CommandType = CommandType.Text;
        _cmd.CommandText="insert into add_product values('"+name.Text+"','"+desp.Text+"',"+price.Text+","+quantity.Text+",'"+_imagepath.ToString()+"')";
        _cmd.ExecuteNonQuery();
        _conn.Close();
    }
}