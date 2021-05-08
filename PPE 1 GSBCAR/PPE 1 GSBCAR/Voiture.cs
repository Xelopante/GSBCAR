using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PPE_1_GSBCAR
{
    public class Voiture
    {
        private int id;
        private string marque;
        private string modele;
        private string immatriculation;
        private double conso;
        private double autonomie;
        private int tpsCharge;
        private string type;
        private string dateAchat;
        private int nbInterv;
        private double prixachat;
        private double loyer;
        private string etat;
        private int puissance;
        private int kilometrage;
        private int dispo;

        public Voiture()
        {

        }

        public Voiture(int i, string mar, string mod, string imm, double con, double aut, int tp, string ty, string ac, int iv, double pr, double lo, string et, int pui, int km, int di)
        {
            this.id = i;
            this.marque = mar;
            this.modele = mod;
            this.immatriculation = imm;
            this.conso = con;
            this.autonomie = aut;
            this.tpsCharge = tp;
            this.type = ty;
            this.dateAchat = ac;
            this.nbInterv = iv;
            this.prixachat = pr;
            this.loyer = lo;
            this.etat = et;
            this.puissance = pui;
            this.kilometrage = km;
            this.dispo = di;
        }

        public int getId()
        {
            return this.id;
        }
        public string getMarque()
        {
            return this.marque;
        }
        public string getModele()
        {
            return this.modele;
        }
        public string getImmatriculation()
        {
            return this.immatriculation;
        }
        public double getConso()
        {
            return this.conso;
        }
        public double getAutonomie()
        {
            return this.autonomie;
        }
        public int getCharge()
        {
            return this.tpsCharge;
        }
        public string getType()
        {
            return this.type;
        }
        public string getDateAchat()
        {
            return this.dateAchat;
        }
        public int getInterv()
        {
            return this.nbInterv;
        }
        public double getPrixAchat()
        {
            return this.prixachat;
        }
        public double getLoyer()
        {
            return this.loyer;
        }
        public string getEtat()
        {
            return this.etat;
        }

        public int getPuissance()
        {
            return this.puissance;
        }

        public int getKilometrage()
        {
            return this.kilometrage;
        }

        public int getDispo()
        {
            return this.dispo;
        }

        public void setId(int i)
        {
            this.id = i;
        }

        public void setMarque(string m)
        {
            this.marque = m;
        }
        public void setModele(string m)
        {
            this.modele = m;
        }
        public void setImmatriculation(string i)
        {
            this.immatriculation = i;
        }
        public void setConso(double c)
        {
            this.conso = c;
        }
        public void setAutonomie(double a)
        {
            this.autonomie = a;
        }
        public void setCharge(int c)
        {
            this.tpsCharge = c;
        }
        public void setType(string t)
        {
            this.type = t;
        }
        public void setDateAchat(string d)
        {
            this.dateAchat = d;
        }
        public void setInterv(int i)
        {
            this.nbInterv = i;
        }
        public void setPrixAchat(double a)
        {
            this.prixachat = a;
        }
        public void setLoyer(double l)
        {
            this.loyer = l;
        }
        public void setEtat(string e)
        {
            this.etat = e;
        }

        public void setPuissance(int p)
        {
            this.puissance = p;
        }

        public void setKilometrage(int k)
        {
            this.kilometrage = k;
        }

        public void setDispo(int d)
        {
            this.dispo = d;
        }
    }
}
