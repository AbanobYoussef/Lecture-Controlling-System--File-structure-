using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace FileProject
{
    class st
    {
        private string name;
        private string id;
        private string stage;
        public DataTable get(string x)
        {
            string l, n, i;
            int z = 0;
            StreamReader p = new StreamReader("students\\stu" + x + ".txt");
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Stage", typeof(string));
            dt.Constraints.Add("Pirmary", dt.Columns["Id"], true);
            l = p.ReadToEnd();
            foreach (char c in l)
            {

                if (c != '|' && z == 0)
                    name += c;
                else if (c != '|' && z == 1)
                    id += c;
                else if (c != ';' && z == 2)
                    stage += c;
                else
                    z++;
                if (c == ';')
                {
                    dt.Rows.Add(name, id,x);
                    z = 0;
                    name = "";
                    id = "";
                    stage = "";
                }

            }
            p.Dispose();
            return dt;
        }
        public void add(DataTable dt,string x)
        {
            StreamWriter p = new StreamWriter("students\\stu"+x+".txt");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                p.WriteLine(dt.Rows[i][0] + "|" + dt.Rows[i][1] + "|" + dt.Rows[i][2] + ";");
            }
            p.Dispose();
        }
        public void creat(DataTable dt, string path,string lec , string prfname)
        {
            StreamWriter p = new StreamWriter(path);
            p.WriteLine("professor : " + prfname );
             p.WriteLine("lecture : "+ lec ); 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                p.WriteLine("=>"+dt.Rows[i][0]);
            }
            p.Dispose();
        }
    }
}
