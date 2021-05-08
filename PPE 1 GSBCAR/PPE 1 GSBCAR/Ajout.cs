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
    public partial class Ajout : Form
    {
        public Ajout()
        {
            InitializeComponent();
        }

        private void AjouterVoiture()
        {
            //Cette procédure permet d'ajouter une voiture en récupérant les infos des différentes textbox
            try
            {
                MySqlConnection connect = new MySqlConnection("database=gsbcar; server=127.0.0.1; user id=root; pwd=");
                connect.Open();

                string ajout = "INSERT INTO vehicule (voit_marque, voit_modele, voit_imma, voit_conso, voit_autono, voit_tpscharg, voit_type, voit_dateachat, voit_interrev, voit_prixachat, voit_loyer, voit_etat, voit_puissance, voit_kilom) VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', " + textBox7.Text.Replace(',', '.') + ", " + textBox8.Text.Replace(',', '.') + ", " + textBox10.Text + ", '" + textBox1.Text + "', '" + textBox11.Text.Replace('/', '-') + "', " + textBox14.Text + ", " + textBox9.Text.Replace(',', '.') + ", " + textBox12.Text.Replace(',', '.') + ", '" + textBox13.Text + "', " + textBox5.Text + ", " + textBox6.Text + ");";
                MySqlCommand sql = new MySqlCommand(ajout, connect);
                sql.ExecuteNonQuery();

                MessageBox.Show("Voiture ajoutée avec succès");

                connect.Close();
            }
            catch(MySqlException co)
            {
                MessageBox.Show(co.ToString());
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton on ajoute la voiture. Pas besoin d'actualiser la liste car après son appel on retourne à l'acceuil et on recharge donc celle-ci
            AjouterVoiture();

            Accueil a = new Accueil();
            a.Show();
            this.Visible = false;
        }

        private void Ajout_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton on revient à la page précédente
            Accueil a = new Accueil();
            a.Show();
            this.Visible = false;
        }
    }
}
