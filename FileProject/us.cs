using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace FileProject
{
    class us
    {

        public string name;
        public string id;
        public string position;
        public DataTable get()
        {
            string l, n, i;
            int z = 0;
            StreamReader p = new StreamReader("files\\us.txt");
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Position", typeof(string));
            dt.Constraints.Add("Pirmary", dt.Columns["Id"], true);
            l = p.ReadToEnd();
            foreach (char c in l)
            {

                if (c != '|' && z == 0)
                    name += c;
                else if (c != '|' && z == 1)
                    id += c;
                else if (c != ';' && z == 2)
                    position += c;
                else
                    z++;
                if (c == ';')
                {
                    dt.Rows.Add(name, id,position);
                    z = 0;
                    name = "";
                    id = "";
                    position = "";
                }

            }
            p.Dispose();
            return dt;
        }
        public void add(DataTable dt)
        {
            StreamWriter p = new StreamWriter("files\\us.txt");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                p.WriteLine(dt.Rows[i][0] + "|" + dt.Rows[i][1] + "|" + dt.Rows[i][2] + ";");
            }
            p.Dispose();
        }
    }
}
