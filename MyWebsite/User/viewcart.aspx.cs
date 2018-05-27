using System;
using System.Data;

namespace User
{
    public partial class UserViewcart : System.Web.UI.Page
    {
        private string[] _dataStore = new string[6];
        private string temp_data;
        private string temp_data2;
        private int total_price;


        protected void Page_Load(object sender, EventArgs e) //a
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("product_name"), new DataColumn("product_desp"), new DataColumn("product_image"), new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("id"), new DataColumn("product_id") });
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
                        _dataStore[3].ToString(), _dataStore[4].ToString(), k.ToString(), _dataStore[5].ToString());
                    total_price = Convert.ToInt32(_dataStore[3].ToString()) * Convert.ToInt32(_dataStore[4].ToString());
                    total.Text = total_price.ToString();

                }

                data_list.DataSource = dt;
                data_list.DataBind();
            }
            else
            {
                Response.Redirect("display_items.aspx");
            }






        }



        protected void viewcart_Click(object sender, EventArgs e)
        {
           


        }

        protected void chck_Click(object sender, EventArgs e)
        {
            Session["checkoutbutton"] = "yes";
            Response.Redirect("checkout.aspx");
        }
    }
}