using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace FileProject
{
    public partial class Form1 : Form
    {
        string t;
        public static Form1 form;
        pr f = new pr();
        le l = new le();
        us s = new us();
         string stage ;
         string END;
         string lecname;
         string prname;
        DataTable dt = new DataTable();
        Forms.maintane m =new Forms.maintane();
        Forms.lectures le; 
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "")
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            dt = f.get();
            DataRow r = dt.Rows.Find(textBox1.Text);
            if(r!=null)
            {
                prname = r["Name"].ToString();
                dt.Clear();
                dt = l.get();
                r = dt.Rows.Find(textBox1.Text);
                t = l.getime(DateTime.Now.ToLongTimeString());
                if ((String.Compare(t, l.getime(r["Startime"].ToString())) == 1 || String.Compare(t, l.getime(r["Startime"].ToString())) == 0) && (String.Compare(t, l.getime(r["Endtime"].ToString())) == 0 || String.Compare(t, l.getime(r["Endtime"].ToString())) == -1)) 
                {
                    lecname = r["Name"].ToString();
                    stage = r["Stage"].ToString();
                    END = l.getime(r["Endtime"].ToString());
                    le = new Forms.lectures(prname,lecname,stage,END);
                    MessageBox.Show("OPENED", "state");
                    MessageBox.Show("CLOSED", "state");
                    le.ShowDialog();
                }
                else
                {
                    MessageBox.Show("^_^", "not the time", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                dt.Clear();
                dt = s.get();
                 r = dt.Rows.Find(textBox1.Text);
                 if (r != null)
                {
                    m.Show();
                }
                else 
                {
                    MessageBox.Show("not allowed", "^_^", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.cipher c = new Forms.cipher();
            c.ShowDialog();
        }

    }
}
