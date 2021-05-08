using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_1_GSBCAR
{
    class Reservation
    {
        private int id;
        private string dateDebut;
        private string dateFin;
        private string etatD;
        private string etatF;
        private int kmD;
        private int kmF;
        private string destination;
        private double depenses;
        private string justificatif;

        public Reservation()
        {

        }

        public Reservation(int i, string dd, string df, string ed, string ef, int kd, int kf, string d, double de, string j)
        {
            this.id = i;
            this.dateDebut = dd;
            this.dateFin = df;
            this.etatD = ed;
            this.etatF = ef;
            this.kmD = kd;
            this.kmF = kf;
            this.destination = d;
            this.depenses = de;
            this.justificatif = j;
        }

        public int getId()
        {
            return this.id;
        }

        public string getDateD()
        {
            return this.dateDebut;
        }

        public string getDateF()
        {
            return this.dateFin;
        }

        public string getEtatD()
        {
            return this.etatD;
        }

        public string getEtatF()
        {
            return this.etatF;
        }

        public int getKmD()
        {
            return this.kmD;
        }

        public int getKmF()
        {
            return this.kmF;
        }

        public string getDesti()
        {
            return this.destination;
        }

        public double getDepenses()
        {
            return this.depenses;
        }

        public string getJusti()
        {
            return this.justificatif;
        }

        public void setId(int i)
        {
            this.id = i;
        }

        public void setDateD(string d)
        {
            this.dateDebut = d;
        }

        public void setDateF(string d)
        {
            this.dateFin = d;
        }

        public void setEtatD(string e)
        {
            this.etatD = e;
        }

        public void setEtatF(string e)
        {
            this.etatF = e;
        }

        public void setKmD(int k)
        {
            this.kmD = k;
        }

        public void setKmF(int k)
        {
            this.kmF = k;
        }

        public void setDesti(string d)
        {
            this.destination = d;
        }

        public void setDepenses(double d)
        {
            this.depenses = d;
        }

        public void setJusti(string j)
        {
            this.justificatif = j;
        }
    }
}
