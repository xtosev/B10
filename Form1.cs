using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A10Blok
{
    public partial class Form1 : Form
    {
        SqlConnection konekcija = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\A10.mdf;Integrated Security=True");
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void UcitajListBox()
        {
            try
            {
                konekcija.Open();
                string sqlUpit = "SELECT PecarosID, Ime, Prezime, Adresa, Grad, Telefon " +
                    "FROM Pecaros, Grad " +
                    "WHERE Pecaros.GradID = Grad.GradID";
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                SqlDataAdapter da = new SqlDataAdapter(komanda);
                dt.Clear();
                da.Fill(dt);
                konekcija.Close();
                listBox1.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    listBox1.Items.Add(String.Format("{0,-7} {1,-15} {2,-15} {3, -25} {4, -15} {5, -10}",
                        row["PecarosID"], row["Ime"], row["Prezime"], row["Adresa"], row["Grad"], row["Telefon"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbPodaci()
        {
            try
            {
                konekcija.Open();
                string sqlUpit = "SELECT PecarosID, Ime, Prezime, Adresa, Grad, Telefon " +
                    "FROM Pecaros, Grad " +
                    "WHERE Pecaros.GradID = Grad.GradID " +
                    "ORDER BY PecarosID ASC";
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                SqlDataAdapter da = new SqlDataAdapter(komanda);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);
                konekcija.Close();
                tbSifra.Text = dt2.Rows[0]["PecarosID"].ToString();
                tbIme.Text = dt2.Rows[0]["Ime"].ToString();
                tbPrezime.Text = dt2.Rows[0]["Prezime"].ToString();
                tbAdresa.Text = dt2.Rows[0]["Adresa"].ToString();
                cbGrad.Text = dt2.Rows[0]["Grad"].ToString();
                tbTelefon.Text = dt2.Rows[0]["Telefon"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbPodaci()
        {
            try
            {
                DataTable dt2 = new DataTable();
                konekcija.Open();
                string sqlUpit2 = "SELECT DISTINCT GradID, Grad " +
                    "FROM Grad " +
                    "ORDER BY Grad ASC";
                SqlCommand komanda2 = new SqlCommand(sqlUpit2, konekcija);
                SqlDataAdapter da2 = new SqlDataAdapter(komanda2);
                da2.Fill(dt2);
                konekcija.Close();
                cbGrad.DataSource = dt2;
                cbGrad.DisplayMember = "Grad";
                cbGrad.ValueMember = "GradID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UcitajListBox();
            cbPodaci();
            tbPodaci();
        }

        private void tstripIzmeni_Click(object sender, EventArgs e)
        {
            if (tbIme.Text == "" || tbPrezime.Text == "" || tbAdresa.Text == "" || tbTelefon.Text == "")
            {
                MessageBox.Show("Morate uneti sve podatke!");
                return;
            }
            if (tbSifra.Text == "")
            {
                MessageBox.Show("Morate izabrati red koji zelite da izmenite!");
                return;
            }
            try
            {
                konekcija.Open();
                string sqlIzmena = "UPDATE Pecaros " +
                    "SET Ime = @Ime, Prezime = @Prezime, Adresa = @Adresa, GradID = @Grad, Telefon = @Telefon " +
                    "WHERE PecarosID = @PecarosID";
                SqlCommand komandaIzmena = new SqlCommand(sqlIzmena, konekcija);
                komandaIzmena.Parameters.AddWithValue("@PecarosID", Convert.ToInt32(tbSifra.Text));
                komandaIzmena.Parameters.AddWithValue("@Ime", tbIme.Text);
                komandaIzmena.Parameters.AddWithValue("@Prezime", tbPrezime.Text);
                komandaIzmena.Parameters.AddWithValue("@Adresa", tbAdresa.Text);
                komandaIzmena.Parameters.AddWithValue("@Grad", cbGrad.SelectedValue);
                komandaIzmena.Parameters.AddWithValue("@Telefon", tbTelefon.Text);
                komandaIzmena.ExecuteNonQuery();
                konekcija.Close();
                int sel = listBox1.SelectedIndex;
                UcitajListBox();
                listBox1.SelectedIndex = sel;
                MessageBox.Show("Podaci su uspesno izmenjeni!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                tbSifra.Text = dt.Rows[listBox1.SelectedIndex]["PecarosID"].ToString();
                tbIme.Text = dt.Rows[listBox1.SelectedIndex]["Ime"].ToString();
                tbPrezime.Text = dt.Rows[listBox1.SelectedIndex]["Prezime"].ToString();
                tbAdresa.Text = dt.Rows[listBox1.SelectedIndex]["Adresa"].ToString();
                cbGrad.Text = dt.Rows[listBox1.SelectedIndex]["Grad"].ToString();
                tbTelefon.Text = dt.Rows[listBox1.SelectedIndex]["Telefon"].ToString();
            }
        }

        private void tstripAnaliza_Click(object sender, EventArgs e)
        {
            Analiza a1 = new Analiza();
            a1.Show();
        }

        private void tstripIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tstripOAplikaciji_Click(object sender, EventArgs e)
        {
            Uputstvo u1 = new Uputstvo();
            u1.Show();
        }
    }
}
