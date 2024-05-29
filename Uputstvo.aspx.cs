using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak_B10
{
    public partial class Uputstvo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Recnik.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dodavanje.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Uputstvo.aspx");

        }
    }
}