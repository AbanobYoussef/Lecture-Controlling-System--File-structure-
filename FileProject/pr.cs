using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace FileProject
{
    class pr
    {
        private string name="";
        private string id="";
        public DataTable get()
        {
            string l,n,i;
            int z=0;
            StreamReader p = new StreamReader("files\\pro.txt");
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Id", typeof(string));
            dt.Constraints.Add("Pirmary", dt.Columns["Id"], true);
            l=p.ReadToEnd();
                foreach (char c in l)
                {

                    if (c != '|' && z == 0)
                        name += c;
                    else if (c != ';' && z == 1)
                        id += c;
                    else
                        z++;
                    if (c == ';')
                    {
                        dt.Rows.Add(name, id);
                        z = 0;
                        name = "";
                        id = "";
                    }

                }
            p.Dispose();
            return dt;
        }
        public void add(DataTable dt)
        {
            StreamWriter p = new StreamWriter("files\\pro.txt");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                p.WriteLine(dt.Rows[i][0] + "|" + dt.Rows[i][1] + ";");
            }
            p.Dispose();
        }
    }
}
