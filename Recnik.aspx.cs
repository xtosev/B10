using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Zadatak_B10
{
    public partial class Recnik : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Recnik.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxOpis.Enabled = false;

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Recnik.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dodavanje.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if(DropDownList.Text == "Iz Srpskog")
            {
               
                SqlCommand cmd = new SqlCommand("Select Engleski, Opis from recnik where Srpski=@parSr", conn);
                cmd.Parameters.AddWithValue("@parSr", TextBoxSrp.Text);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                TextBoxEngl.Text = sdr["Engleski"].ToString();
                TextBoxOpis.Text = sdr["Opis"].ToString();
                conn.Close();
            }
            else
            {
                TextBoxSrp.Enabled = false;
                TextBoxOpis.Enabled = false;
                SqlCommand cmd = new SqlCommand("Select Srpski, Opis from recnik where Engleski=@parEn", conn);
                cmd.Parameters.AddWithValue("@parEn", TextBoxEngl.Text);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    TextBoxSrp.Text = sdr["Srpski"].ToString();
                    TextBoxOpis.Text = sdr["Opis"].ToString();
                }
                conn.Close();
            }
        }
        public void Ocisti()
        {
            TextBoxEngl.Text = "";
            TextBoxSrp.Text = "";
            TextBoxOpis.Text = "";
        }
        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList.SelectedIndex == 0)
            {
                TextBoxSrp.Enabled = true;
                TextBoxEngl.Enabled = false;
                Ocisti();
            }
            else
            {
                TextBoxSrp.Enabled = false;
                TextBoxEngl.Enabled = true;
                Ocisti();

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Uputstvo.aspx");

        }
    }
}