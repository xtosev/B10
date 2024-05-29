using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak_B10
{
    public partial class Dodavanje : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Recnik.mdf;Integrated Security=True");
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
        public void Ocisti()
        {
            TextBoxEngl.Text = "";
            TextBoxSrp.Text = "";
            TextBoxOpis.Text = "";
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into recnik values(@parE,@parS,@parOpis)",conn);
            cmd.Parameters.AddWithValue("@parE", TextBoxEngl.Text);
            cmd.Parameters.AddWithValue("@parS", TextBoxSrp.Text);
            cmd.Parameters.AddWithValue("@parOpis", TextBoxOpis.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write($"<script> alert('Uspesno ste uneli rec {TextBoxSrp.Text}') </script>");
            Ocisti();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Uputstvo.aspx");

        }
    }
}