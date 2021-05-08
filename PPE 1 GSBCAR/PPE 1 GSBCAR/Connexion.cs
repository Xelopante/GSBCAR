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
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        public void Connect()
        {
            //La procédure Connect permet de retourner un count si le login et le mdp sont dans la même ligne, si le count est valide alors la personne peut se connecter
            try
            {
                MySqlConnection connexion = new MySqlConnection("database=gsbcar; server=localhost; user id=root; pwd=");
                connexion.Open();
                string login = textBox1.Text;
                string mdp = textBox2.Text;

                string sql = "SELECT COUNT(*) FROM salarie WHERE sal_login = '" + login + "' AND sal_mdp = '" + mdp + "';";
                MySqlCommand requete = new MySqlCommand(sql, connexion);
                MySqlDataReader reader = requete.ExecuteReader();
                reader.Read();

                if (Convert.ToInt32(reader[0].ToString()) > 0)
                {
                    Accueil m = new Accueil();
                    m.Show();
                    this.Visible = false;
                    connexion.Close();
                }
                else
                {
                    MessageBox.Show("Login ou Mdp incorrect");
                }
            }
            catch (MySqlException co)
            {
                MessageBox.Show(co.ToString());
                MessageBox.Show("Non connecté");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Ce bouton lorsqu'il est activé permet de fermer l'application et d'en sortir
            Application.Exit();
        }

        private void Connexion_Load(object sender, EventArgs e)
        {

        }
    }
}
