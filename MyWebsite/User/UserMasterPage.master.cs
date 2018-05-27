using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UserUserMasterPage : System.Web.UI.MasterPage
{
    private string temp_data;
    private string temp_data2;
    private int total_price1 = 0;
    private string[] _dataStore = new string[6];
    private int count_qty = 0;
    SqlCommand cmd = new SqlCommand();
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd1 = new SqlCommand();



    protected void Page_Load(object sender, EventArgs e)
    {


        conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        conn.Open();
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select *from product_catagory";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        cat.DataSource = dt;
        cat.DataBind();









        if (Request.Cookies["aa"] != null)
        {
            temp_data = Convert.ToString(Request.Cookies["aa"].Value);
            string[] split_data = temp_data.Split('|');
            for (int k = 0; k < split_data.Length; k++)
            {
                temp_data2 = Convert.ToString(split_data[k]);
                string[] split_data2 = temp_data2.Split(',');
                for (int j = 0; j < split_data2.Length; j++)
                {
                    _dataStore[j] = split_data2[j];


                }

                total_price1 = total_price1 + Convert.ToInt32(_dataStore[3].ToString()) *
                               Convert.ToInt32(_dataStore[4].ToString());
                count_qty = count_qty + 1;

                total_price.Text = total_price1.ToString();
                total_items.Text = count_qty.ToString();

            }

        }
    }
}
