using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_payment : System.Web.UI.Page
{
    private string[] _dataStore = new string[6];
    private string temp_data;
    private string temp_data2;
    private int total_price;
    private string order_no;
    protected void Page_Load(object sender, EventArgs e)
    {
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
               
                total_price = Convert.ToInt32(_dataStore[3].ToString()) * Convert.ToInt32(_dataStore[4].ToString());
               

            }

            Session["tot"] = total_price.ToString();
        }
        Random_order_no random_order =new Random_order_no();

        order_no = random_order.GetRandomString();

        Session["order_no"] = order_no.ToString();

        Response.Write(
            "< form  action = 'https://www.sandbox.paypal.com/cgi-bin/webscr' method='post' name='buyCredits' id='buyCredits' >");

        Response.Write("  < input type = 'hidden' name = 'cmd' value = '_xclick' >");
        Response.Write("  < input type = 'hidden' name = 'business' value = 'saadfarooq881@gmail.com' >");
        Response.Write("  < input type = 'hidden' name = 'currency_code' value = 'USD' >");
        Response.Write("  < input type = 'hidden' name = 'item_name' value = 'payment' >");
        Response.Write("  < input type = 'hidden' name = 'item_number' value = '0' >");
        Response.Write("  < input type = 'hidden' name = 'no_shipping value = '1' >");
        Response.Write("  < input type = 'hidden' name ='amount' value = '"+Session["tot"].ToString() +"' >");
        Response.Write("< input type = 'hidden' name = 'return' value='https://localhost:63775/User/payment_sucess.aspx?order="+order_no.ToString()+"' >");
        Response.Write("   </ form >");
        Response.Write("<script type='text/javascript'>");
        Response.Write("document.getElementById('buyCredits').submit();");
        Response.Write("</script>");

    }
    

    
}