using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace FileProject
{
    class le
    {
        public string name;
        public string proid;
        public string stag;
        public string startime;
        public string endtime;
        public DataTable get()
        {
            string l;
            int z = 0;
            StreamReader p = new StreamReader("files\\lec.txt");
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("DOCid", typeof(string));
            dt.Columns.Add("Stage", typeof(string));
            dt.Columns.Add("Startime", typeof(string));
            dt.Columns.Add("Endtime", typeof(string));
            dt.Constraints.Add("Pirmary", dt.Columns["DOCid"], true);
            l = p.ReadToEnd();
            foreach (char c in l)
            {

                if (c != '|' && z == 0)
                    name += c;
                else if (c != '|' && z == 1)
                    proid += c;
                else if (c != '|' && z == 2)
                    stag += c;
                else if (c != '|' && z == 3)
                    startime += c;
                else if (c != ';' && z == 4)
                    endtime += c;
                else
                    z++;
                if (c == ';')
                {
                    dt.Rows.Add(name, proid, stag, startime, endtime);
                    z = 0;
                    name = "";
                    proid = "";
                    stag = "";
                    startime = "";
                    endtime = "";
                }

            }

            p.Dispose();
            return dt;
        }
        public void add(DataTable dt)
        {
            StreamWriter p = new StreamWriter("files\\lec.txt");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                p.WriteLine(dt.Rows[i][0] + "|" + dt.Rows[i][1] + "|" + dt.Rows[i][2] + "|" + dt.Rows[i][3] + "|" + dt.Rows[i][4] + ";");
            }
            p.Dispose();
        }
        public string getime(string x)
        {
            string t = "";
            foreach (char c in x)
            {
                if (c != 'P' && c != 'A' && c != 'M' && c != ':')
                {
                    t += c;
                }
            }
            return t;
        } 
    }
}
