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
    public partial class Accueil : Form
    {

        //Ici je créé 2 listes une fois que la personne s'est authentifiée : une liste de voiture et une liste d'intervention avec comme type la classe de chacune
        public static List<Intervention> lesInter;
        public static List<Voiture> lesVoitures;
        public Accueil()
        {
            //Ici j'instancie les 2 listes
            InitializeComponent();
            lesVoitures = new List<Voiture>();
            lesInter = new List<Intervention>();
        }

        //La variable choix correspondra à l'indice de selection dans la listbox pour afficher les infos de la voiture correspondante
        public static int choix;
        
        private void affdetail(object sender, EventArgs e)
        {
            //"affdetail" correspond au double clic sur une voiture de la listbox, qui au passage prend la valeur de la position dans choix et affiche les détails de la voiture
            choix = listBox1.SelectedIndex;

            Details d = new Details();
            d.Show();
            this.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Ce bouton permet de retourner à la page de connexion en se déconnectant
            this.Visible = false;
            Connexion c = new Connexion();
            c.Show();
        }

        private void ChargerVoiture()
        {
            //Dans cette procédure on fait un SELECT pour avoir toutes les infos des voitures et on les range dans la liste de voiture
            try
            {
                MySqlConnection connect = new MySqlConnection("database=gsbcar; server=127.0.0.1; user id=root; pwd=");
                connect.Open();

                string requete = "SELECT * FROM vehicule;";
                MySqlCommand sql = new MySqlCommand(requete, connect);
                MySqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Voiture v = new Voiture();

                    v.setId(Convert.ToInt32(reader[0].ToString()));
                    v.setMarque(Convert.ToString(reader[1].ToString()));
                    v.setModele(Convert.ToString(reader[2].ToString()));
                    v.setImmatriculation(Convert.ToString(reader[3].ToString()));
                    v.setConso(Convert.ToDouble(reader[4].ToString()));
                    v.setAutonomie(Convert.ToDouble(reader[5].ToString()));
                    v.setCharge(Convert.ToInt32(reader[6].ToString()));
                    v.setType(Convert.ToString(reader[7].ToString()));
                    string onlydate = reader[8].ToString();
                    //onlydate est une variable avec laquelle je joue pour prendre seulement la date ainsi que la mettre en format ANNEE-MOIS-JOUR pour la rendre compatible avec MySql
                    onlydate = onlydate.Split(' ')[0];
                    string j = onlydate.Split('/')[0];
                    string m = onlydate.Split('/')[1];
                    string a = onlydate.Split('/')[2];
                    string ladate = a + "-" + m + "-" + j;
                    v.setDateAchat(ladate);
                    v.setInterv(Convert.ToInt32(reader[9].ToString()));
                    v.setPrixAchat(Convert.ToDouble(reader[10].ToString()));
                    v.setLoyer(Convert.ToDouble(reader[11].ToString()));
                    v.setEtat(Convert.ToString(reader[12].ToString()));
                    v.setPuissance(Convert.ToInt32(reader[13].ToString()));
                    v.setKilometrage(Convert.ToInt32(reader[14].ToString()));
                    v.setDispo(Convert.ToInt32(reader[15].ToString()));

                    lesVoitures.Add(v);
                }

                connect.Close();
                reader.Close();
            }
            catch (MySqlException co)
            {
                MessageBox.Show(co.ToString());
            }

            //pour chaque voiture dans la liste, je l'affiche dans la listbox
            foreach (Voiture v in lesVoitures)
            {
                listBox1.Items.Add(v.getId() + " | " + v.getMarque() + " | " + v.getModele());
            }
        }

        private void ChargerIndispo()
        {
            //Dans cette procédure, je charge toute les indisponibilité d'une voiture avec un SELECT * et les range dans la liste d'indisponibilités
            try
            {
                MySqlConnection connect = new MySqlConnection("database=gsbcar; server=127.0.0.1; user id=root; pwd=");
                connect.Open();

                string aff = "SELECT * FROM intervention;";
                MySqlCommand sql = new MySqlCommand(aff, connect);
                MySqlDataReader reader = sql.ExecuteReader();

               
                    while (reader.Read())
                    {
                        Intervention i = new Intervention();

                        i.setId(Convert.ToInt32(reader[0].ToString()));
                        i.setType(Convert.ToString(reader[1].ToString()));
                        string onlydate = reader[2].ToString();
                        onlydate = onlydate.Split(' ')[0];
                        string j = onlydate.Split('/')[0];
                        string m = onlydate.Split('/')[1];
                        string a = onlydate.Split('/')[2];
                        string ladate = a + "-" + m + "-" + j;
                        i.setDate(ladate);
                        i.setCout(Convert.ToDouble(reader[3].ToString()));
                        i.setIdVoit(Convert.ToInt32(reader[4].ToString()));
                        i.setDesc(Convert.ToString(reader[5].ToString()));

                        lesInter.Add(i);
                    }

                reader.Close();
                connect.Close();
            }
            catch (MySqlException co)
            {
                MessageBox.Show(co.ToString());
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //Lors du chargement de la page, je range donc les voitures et les indisponibilités directement
            ChargerVoiture();
            ChargerIndispo();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton je charge la page d'ajout de voiture
            Ajout a = new Ajout();
            a.Show();
            this.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void disp(object sender, EventArgs e)
        {
            //Cette procédure permet de savoir si une voiture est disponible ou non
            if (lesVoitures.ElementAt(Accueil.choix).getDispo() == 0)
            {
                label3.Text = "Disponible";
            }
            else
            {
                label3.Text = "En intervention";
            }
        }
    }
}
