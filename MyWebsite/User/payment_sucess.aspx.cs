using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_payment_sucess : System.Web.UI.Page
{
    private string[] _dataStore = new string[6];
    private string temp_data;
    private string temp_data2;
    private int total_price;
    private string order = "";
    private string order_id;
    SqlCommand cmd = new SqlCommand();
    SqlConnection conn = new SqlConnection();
    SqlCommand cmd1 = new SqlCommand();



    protected void Page_Load(object sender, EventArgs e)
    {
       
        conn.ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
        conn.Open();
        order = Request.QueryString["order"].ToString();

        if (order == Session["order_no"].ToString())
        {
            // getting user detais and store on user order details
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from register_user where email='"+Session["log"]+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt =new DataTable();
            SqlDataAdapter da =new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
               
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into orders values('" + dr["firstname"] + "','" + dr["lastname"] + "','" +
                                   dr["email"] + "','" + dr["address"] + "','" + dr["state"] + "','" + dr["city"] +
                                   "','" + dr["pincode"] + "','" + dr["mobile"] + "',)";
                cmd1.ExecuteNonQuery();

            }


            //get order id
            SqlCommand cmd2 = new SqlCommand();
            cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 *from register_user where email='" + Session["log"] + "' order by id desc";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)

            {
                order_id = dr2["id"].ToString();

            }


            //cookies data

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
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3 = conn.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into order_details values ('"+ order_id.ToString()+ "', '" + _dataStore[0].ToString() + "','" + _dataStore[2].ToString() + "','" + _dataStore[3].ToString()+ "','" + _dataStore[4].ToString() + "')";

                    cmd3.ExecuteNonQuery();



                }

                
            }



        }
        else
        {
            Response.Redirect("user_login.aspx");
        }
        conn.Close();
        Session["log"] = "";
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);

        Response.Redirect("display_items.aspx");
    }
}