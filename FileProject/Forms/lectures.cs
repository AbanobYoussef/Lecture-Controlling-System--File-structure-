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


namespace FileProject.Forms
{
    public partial class lectures : Form
    {
        SaveFileDialog svf = new SaveFileDialog();
        bool open = false, system = true;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataRow r;
        st s = new st();
        le l = new le();
        string stage;
        string END;
        string lecname;
        string prname;
        public lectures(string prf,string lec , string Stage ,string end)
        {
            prname = prf;
            lecname = lec;
            stage = Stage;
            END = end;
            InitializeComponent();
           timer2.Start();
            closeToolStripMenuItem.Enabled = false;
            activateToolStripMenuItem.Enabled = false;
            allStudentsToolStripMenuItem.Enabled = false;
           // axAcroPDF1.Visible = false;
            dt.Clear();
            if (stage != null)
            {
                dt = s.get(stage);
                dataGridView1.DataSource = dt;
            }
            dt2.Clear();
            dt2.Columns.Add("Name", typeof(string));
            dt2.Columns.Add("Id", typeof(string));
            dt2.Columns.Add("Stage", typeof(string));
        }
        private void endit()
        {
            timer2.Stop();
            MessageBox.Show("OPENED", "state");
            MessageBox.Show("WE finshed our LECTURE\nplease save your file", "LECTURE ENDED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            svf.Filter = "text file|*.text";
            svf.Title = "SAVE YOUR FILE PLEASE";
            if(svf.ShowDialog()==DialogResult.OK)
            {
                s.creat(dt2, svf.FileName,lecname,prname);
            }
            MessageBox.Show("CLOSED", "state");
            this.Close();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = true;
            openToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = true;
            MessageBox.Show("OPENED", "state");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open = false;
            closeToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = true;
            MessageBox.Show("CLOSED","state" );
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            system = true;
            activateToolStripMenuItem.Enabled = false;
            deactivateToolStripMenuItem.Enabled = true;
        }

        private void deactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            system = false;
            activateToolStripMenuItem.Enabled = true;
            deactivateToolStripMenuItem.Enabled = false;
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            endit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                timer1.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            toolStripTextBox1.Text = DateTime.Now.ToLongTimeString();
            if (String.Compare(l.getime(toolStripTextBox1.Text),END) == 0||String.Compare(l.getime(toolStripTextBox1.Text),END) == 1)
            {
                endit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            DataRow r = dt.Rows.Find(textBox1.Text);
            if (system == true)
            {
                if (r!=null)
                {
                    if (String.Compare(stage, r["Stage"].ToString()) == 0)
                    {
                        dt2.Rows.Add(r["Name"], r["Id"], r["Stage"]);
                        if (open == false)
                        {
                            MessageBox.Show("OPENED", "state");
                            MessageBox.Show("CLOSED", "state");
                        }
                    }
                    else 
                        MessageBox.Show("not your stage");
                }
                else 
                {
                    MessageBox.Show("no access now");
                }
            }
            textBox1.Text = "";
        }

        private void inClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inClassToolStripMenuItem.Enabled = false;
            allStudentsToolStripMenuItem.Enabled = true;
            dataGridView1.DataSource = dt2;
        }

        private void allStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inClassToolStripMenuItem.Enabled = true;
            allStudentsToolStripMenuItem.Enabled = false;
            dataGridView1.DataSource = dt;
        }

       


    }
}
