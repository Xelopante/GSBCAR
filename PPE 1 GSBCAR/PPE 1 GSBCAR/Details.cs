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
    public partial class Details : Form
    {
        
        public Details()
        {
            InitializeComponent();
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton on retourne à l'accueil
            this.Visible = false;
            Accueil a = new Accueil();
            a.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton on va sur la page d'ajout d'indisponibilité pour la voiture selectionnée
            Indispo i = new Indispo();
            i.Show();
            this.Visible = false;
        }

        private void AffInter()
        {
            //Cette procédure affiche les intervention dans la listbox si l'id de la voiture de l'intervention est pareil que l'id de la voiture en question
            foreach (Intervention inter in Accueil.lesInter)
            {
                if (inter.getIdVoit() == Accueil.lesVoitures.ElementAt(Accueil.choix).getId())
                {
                    listBox1.Items.Add(inter.getDate());
                    listBox2.Items.Add(inter.getType());
                    listBox3.Items.Add(inter.getDesc());
                    listBox4.Items.Add(inter.getCout()+" €");
                }
            }
        }

        private void Details_Load(object sender, EventArgs e)
        {
            //Lors du chargement de la page des détails, on récupère toute les informations d'une voiture dans la liste en se référant à son id obtenu par la variable choix
            textBox1.Text = Accueil.lesVoitures.ElementAt(Accueil.choix).getType();
            textBox2.Text = Accueil.lesVoitures.ElementAt(Accueil.choix).getMarque();
            textBox3.Text = Accueil.lesVoitures.ElementAt(Accueil.choix).getModele();
            textBox4.Text = Accueil.lesVoitures.ElementAt(Accueil.choix).getImmatriculation();
            textBox5.Text = Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getPuissance());
            textBox6.Text = Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getKilometrage());
            textBox7.Text = Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getConso());
            textBox8.Text = Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getAutonomie());
            textBox10.Text = Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getCharge());
            textBox13.Text = Accueil.lesVoitures.ElementAt(Accueil.choix).getDateAchat();
            textBox9.Text = Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getPrixAchat());
            textBox11.Text = Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getLoyer());
            textBox12.Text = Accueil.lesVoitures.ElementAt(Accueil.choix).getEtat();
            textBox14.Text = Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getInterv());

            AffInter();
        }

        private void SupprimerVoiture()
        {
            //Cette procédure permet d'envoyer une requête DELETE FROM pour supprimer une voiture. Pas besoin d'actualiser la liste car après son appel on retourne à l'acceuil et on recharge donc celle-ci
            int arch = 0;
            foreach(Intervention interv in Accueil.lesInter)
            {
                if(interv.getIdVoit() == Accueil.lesVoitures.ElementAt(Accueil.choix).getId())
                {
                    arch += 1;
                }
            }

            if (arch == 0)
            {
                try
                {
                    MySqlConnection connect = new MySqlConnection("database=gsbcar; server=127.0.0.1; user id=root; pwd=");
                    connect.Open();

                    string requete = "DELETE FROM vehicule WHERE voit_id =" + Accueil.lesVoitures.ElementAt(Accueil.choix).getId() + ";";
                    MySqlCommand sql = new MySqlCommand(requete, connect);
                    sql.ExecuteNonQuery();

                    connect.Close();

                    this.Visible = false;
                    Accueil a = new Accueil();
                    a.Show();

                }
                catch (MySqlException co)
                {
                    MessageBox.Show(co.ToString());
                }
            }
            else
            {
                MessageBox.Show("La voiture a déjà subit une ou plusieurs interventions, elle sera seulement archivée");
            }
        }

        private void ModifierVoiture()
        {
            //Cette procédure permet d'envoyer une requête UPDATE pour actualiser les informations d'une voiture via un WHERE sur son id. Pas besoin d'actualiser la liste car après son appel on retourne à l'acceuil et on recharge donc celle-ci
            try
            {
                MySqlConnection connect = new MySqlConnection("database=gsbcar; server=127.0.0.1; user id=root; pwd=");
                connect.Open();

                string requete = "UPDATE vehicule SET voit_marque = '" + textBox2.Text + "', voit_modele = '" + textBox3.Text + "', voit_imma = '" + textBox4.Text + "', voit_conso = " + textBox7.Text.Replace(",",".") + ", voit_autono = " + textBox8.Text.Replace(",",".") + ", voit_tpscharg = " + textBox10.Text + ", voit_type = '" + textBox1.Text + "', voit_dateachat = '" + textBox13.Text + "', voit_interrev = " + textBox14.Text + ", voit_prixachat = " + textBox9.Text.Replace(",",".") + ", voit_loyer = " + textBox11.Text.Replace(",",".") + ", voit_etat = '" + textBox12.Text + "', voit_puissance = " + textBox5.Text + ", voit_kilom = " + textBox6.Text + " WHERE voit_id = " + Convert.ToString(Accueil.lesVoitures.ElementAt(Accueil.choix).getId()) + ";";

                MySqlCommand sql = new MySqlCommand(requete, connect);
                sql.ExecuteNonQuery();

                connect.Close();
                MessageBox.Show("Modification(s) effectuée(s)");

                this.Visible = false;
                Accueil a = new Accueil();
                a.Show();
            }
            catch(MySqlException co)
            {
                MessageBox.Show(co.ToString());
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton on supprime une voiture
            SupprimerVoiture();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton on modifie les infos d'une voiture
            ModifierVoiture();
        }


        private void RetourVoiture()
        {
            //Cette procédure permet de déclarer le retour d'une voiture
            try
            {
                MySqlConnection connect = new MySqlConnection("database=gsbcar; server=127.0.0.1; user id=root; pwd=");
                connect.Open();

                string requete = "UPDATE vehicule SET voit_disp=0 WHERE voit_id="+ Accueil.lesVoitures.ElementAt(Accueil.choix).getId() + ";";
                MySqlCommand sql = new MySqlCommand(requete, connect);
                sql.ExecuteNonQuery();

                MessageBox.Show("Voiture remise en service");

                connect.Close();
            }
            catch(MySqlException co)
            {
                MessageBox.Show(co.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //En cliquant sur ce bouton on vérifie si la voiture est en intervention par la valeur de disponibilité et on fait appel ou non à la procédure pour déclarer le retour
            if(Accueil.lesVoitures.ElementAt(Accueil.choix).getDispo() == 0)
            {
                MessageBox.Show("Voiture déjà en service");
            }
            else
            {
                RetourVoiture();

                Accueil a = new Accueil();
                a.Show();
                this.Visible = false;
            }
        }
    }
}
