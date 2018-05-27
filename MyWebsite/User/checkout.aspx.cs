using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["log"]==null)
        {
            Response.Redirect("user_login.aspx");
        }
        else
        {
            Response.Redirect("update_order_details.aspx");

        }
        
    }
}