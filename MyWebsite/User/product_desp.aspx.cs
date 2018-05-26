using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace User
{
    public partial class UserProductDesp : System.Web.UI.Page
    {
        private int qty_counter;
        SqlCommand _cmd = new SqlCommand();
        SqlConnection _conn = new SqlConnection();
        private int _id;
        private string _productName, _productDesp, _productPrice, _productQty, _productImage;
        private string _store;

        protected void Page_Load(object sender, EventArgs e)
        {
            _conn.ConnectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\muham\source\repos\MyWebsite\MyWebsite\App_Data\ecommerce_data.mdf;Integrated Security=True";

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("display_items.aspx");
            }
            else
            {

                _id = Convert.ToInt32(Request.QueryString["id"].ToString());
                _conn.Open();
                _cmd = _conn.CreateCommand();
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select *from add_product where id='" + _id + "'";
                _cmd.ExecuteNonQuery();
                DataTable dta = new DataTable();
                SqlDataAdapter adpt = new SqlDataAdapter(_cmd);
                adpt.Fill(dta);
                rpt.DataSource = dta;
                rpt.DataBind();
                _conn.Close();
            }

            if (get_qty(_id) <= 0)
            {
                txt.Visible = false;
                cart.Visible = false;
                l1.Text = "Sorry Product is Out of Stock";
            }




        }




        protected void cart_Click(object sender, EventArgs e)
        {
           
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();

            }
            _conn.Open();
            _cmd = _conn.CreateCommand();
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "select *from add_product where id='" + _id + "'";
            _cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(_cmd);
            adpt.Fill(dta);


            foreach (DataRow dtr in dta.Rows)
            {
                _productName = dtr["pro_name"].ToString();
                _productDesp = dtr["pro_desp"].ToString();
                _productPrice = dtr["pro_price"].ToString();
                _productQty = dtr["pro_qua"].ToString();
                _productImage = dtr["pro_image"].ToString();
               
            }

           
                if (Convert.ToInt32(txt.Text) > Convert.ToInt32(_productQty))
                {
                    l1.Text = "Sorry Select the Valid Quantity";
                    Response.Redirect("product_desp.aspx");
                }
                else
                {
                    if (Request.QueryString["aa"] == null)
                    {

                        Response.Cookies["aa"].Value = _productName.ToString() + "," + _productDesp.ToString() + "," +
                                                       _productImage.ToString() + "," + _productPrice.ToString() + "," +
                                                       _productQty.ToString() + "," + _id.ToString();

                        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);




                    }
                    else 
                    {
                        Response.Cookies["aa"].Value =
                            Request.Cookies["aa"].Value + "|" + _productName.ToString() + "," +
                            _productDesp.ToString() + "," +
                            _productImage.ToString() + "," + _productPrice.ToString() + "," +
                            _productQty.ToString();
                        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                    }


                    SqlCommand cmd = _conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update add_product set pro_qua = pro_qua -" + txt.Text+ "where id="+_id;
                    cmd.ExecuteNonQuery();
                    Response.Redirect("product_desp.aspx?id="+ _id.ToString());
                }

           


        }

        public int get_qty(int id)
        {
            _conn.Open();
            _cmd = _conn.CreateCommand();
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandText = "select *from add_product where id='" + id + "'";
            _cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(_cmd);
            adpt.Fill(dta);
            foreach (DataRow dtr in dta.Rows)
            {
             
                qty_counter =Convert.ToInt32(dtr["pro_qua"].ToString());
                

            }

            return qty_counter;
        }
    }
}
