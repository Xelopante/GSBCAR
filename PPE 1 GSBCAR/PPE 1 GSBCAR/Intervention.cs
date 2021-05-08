using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_1_GSBCAR
{
    public class Intervention
    {
        private int id;
        private string type;
        private string date;
        private string desc;
        private double cout;
        private int idvoit;

        public Intervention()
        {

        }

        public Intervention(int i, string t, string da, string de, double c, int v)
        {
            this.id = i;
            this.type = t;
            this.date = da;
            this.desc = de;
            this.cout = c;
            this.idvoit = v;
        }

        public int getId()
        {
            return this.id;
        }

        public string getType()
        {
            return this.type;
        }

        public string getDate()
        {
            return this.date;
        }

        public string getDesc()
        {
            return this.desc;
        }

        public double getCout()
        {
            return this.cout;
        }

        public int getIdVoit()
        {
            return this.idvoit;
        }

        public void setId(int i)
        {
            this.id = i;
        }

        public void setType(string t)
        {
            this.type = t;
        }

        public void setDate(string da)
        {
            this.date = da;
        }

        public void setDesc(string de)
        {
            this.desc = de;
        }

        public void setCout(double c)
        {
            this.cout = c;
        }

        public void setIdVoit(int v)
        {
            this.idvoit = v;
        }
    }
}
