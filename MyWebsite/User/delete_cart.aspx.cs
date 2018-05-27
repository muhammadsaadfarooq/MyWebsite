using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_delete_cart : System.Web.UI.Page
{
    SqlCommand _cmd = new SqlCommand();
    SqlConnection _conn = new SqlConnection();
    private string temp_data;
    private string temp_data2;
    string[] _dataStore = new string [6];
    private int id;
    private string _productName, _productDesp, _productPrice, _productQty, _productImage;
    private int Count = 0;
    private int product_id, qty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("display_items.aspx");
        }
        else
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7]
            {
                new DataColumn("product_name"), new DataColumn("product_desp"), new DataColumn("product_image"),
                new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("id"),new DataColumn("product_id")
            });
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

                    dt.Rows.Add(_dataStore[0].ToString(), _dataStore[1].ToString(), _dataStore[2].ToString(),
                        _dataStore[3].ToString(), _dataStore[4].ToString(), k.ToString(),_dataStore[5].ToString());

                }


            }

            
            _conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";
            Count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (Count == id)
                {
                    product_id = Convert.ToInt32(dr["product_id"].ToString());
                    qty = Convert.ToInt32(dr["product_qty"].ToString());

                }

                Count = Count + 1;

            }

            Count = 0;
            _conn.Open();

            _cmd = _conn.CreateCommand();
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "update add_product set pro_qua=pro_qua+" + qty + "where id=" + product_id;
            _cmd.ExecuteNonQuery();
            _conn.Close();

            dt.Rows.RemoveAt(id);

            Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
            foreach (DataRow dtr in dt.Rows)
            {
                _productName = dtr["pro_name"].ToString();
                _productDesp = dtr["pro_desp"].ToString();
                _productPrice = dtr["pro_price"].ToString();
                _productQty = dtr["pro_qua"].ToString();
                _productImage = dtr["pro_image"].ToString();
                product_id = Convert.ToInt32(dtr["product_id"].ToString());

                Count = Count + 1;


                if (Request.QueryString["aa"] == null)
                {

                    Response.Cookies["aa"].Value = _productName.ToString() + "," + _productDesp.ToString() + "," +
                                                   _productImage.ToString() + "," + _productPrice.ToString() + "," +
                                                   _productQty.ToString()+","+product_id.ToString();

                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);




                }
                else if (Request.QueryString["aa"] != null)
                {
                    Response.Cookies["aa"].Value =
                        Request.Cookies["aa"].Value + "|" + _productName.ToString() + "," + _productDesp.ToString() +
                        "," +
                        _productImage.ToString() + "," + _productPrice.ToString() + "," +
                        _productQty.ToString() + product_id.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }
            }

            Response.Redirect("viewcart.aspx");

        }
    }
}