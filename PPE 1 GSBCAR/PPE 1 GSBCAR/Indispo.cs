using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PPE_1_GSBCAR
{
    public partial class Indispo : Form
    {
        public Indispo()
        {
            InitializeComponent();
        }

        private void Indisponibilité_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Accident");
            comboBox1.Items.Add("Vidange");
        }

        private void NouvelleIndispo()
        {
            //Cette procédure permet d'ajouter une indisponibilté pour la voiture selectionnée
            try
            {
                MySqlConnection connect = new MySqlConnection("database=gsbcar; server=127.0.0.1; user id=root; pwd=");
                connect.Open();

                string indi = "INSERT INTO intervention (inter_type, inter_date, inter_cout, inter_desc, voit_id) VALUES ('" + Convert.ToString(comboBox1.SelectedItem) + "', '" + textBox3.Text.Replace('/', '-') + "', " + textBox1.Text.Replace(',', '.') + ", '" + textBox2.Text.Replace("'", " ") + "', " + Accueil.lesVoitures.ElementAt(Accueil.choix).getId() + ")";
                MySqlCommand sql = new MySqlCommand(indi, connect);
                sql.ExecuteNonQuery();

                MessageBox.Show("Indisponibilité rentrée avec succès");
                connect.Close();
            }
            catch(MySqlException co)
            {
                MessageBox.Show(co.ToString());
            }
        }

        private void EtatIndispo()
        {
            //Cette procédure permet de signaler que la voiture est indisponible et augment le compteur de nombre d'interventions de 1
            try
            {
                MySqlConnection connect = new MySqlConnection("database=gsbcar; server=127.0.0.1; user id=root; pwd=");
                connect.Open();

                string requete = "UPDATE vehicule SET voit_disp=1, voit_interrev = (voit_interrev + 1) WHERE voit_id=" + Accueil.lesVoitures.ElementAt(Accueil.choix).getId() + ";";
                MySqlCommand sql = new MySqlCommand(requete, connect);
                sql.ExecuteNonQuery();

                MessageBox.Show("Voiture mise hors-service");

                connect.Close();
            }
            catch (MySqlException co)
            {
                MessageBox.Show(co.ToString());
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton, on ajoute l'indisponibilité et on signale que la voiture est hors service
            NouvelleIndispo();
            EtatIndispo();

            Accueil a = new Accueil();
            a.Show();
            this.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton on revient sur la page précédente
            Details d = new Details();
            d.Show();
            this.Visible = false;
        }
    }
}
