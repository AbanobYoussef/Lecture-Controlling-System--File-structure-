using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileProject.Forms
{
    public partial class maintane : Form
    {
        DataTable dt = new DataTable();
        string x,z;
        pr f = new pr();
        le l = new le();
        us s = new us();
        st stu = new st();
        public maintane()
        {
            InitializeComponent();
            button3.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                x = "pr";
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                label6.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox3.ReadOnly = false;
                label3.Text = "Id";
                dt.Clear();
                dt = f.get();
                dataGridView1.DataSource = dt;
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                x = "le";
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                label6.Visible = true;
                textBox3.ReadOnly = false;
                textBox3.Text = "";
                label3.Text = "ProId";
                label4.Visible = true;
                label4.Text = "stage";
                label5.Visible = true;
                dt.Clear();
                dt = l.get();
                dataGridView1.DataSource = dt;
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
            }
        }

       

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                x = "us";
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox3.ReadOnly = false;
                textBox3.Text = "";
                textBox5.Visible = false;
                label6.Visible = false;
                label4.Visible = true;
                label5.Visible = false;
                label4.Text = "position";
                label3.Text = "Id";
                dt.Clear();
                dt = s.get();
                dataGridView1.DataSource = dt;
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";

            }
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                x = "stu";
                z = comboBox1.Text;
                textBox3.Visible = true;
                textBox3.ReadOnly = true;
                textBox3.Text = z;
                textBox4.Visible = false;
                textBox5.Visible = false;
                label6.Visible = false;
                label4.Visible = true;
                label5.Visible = false;
                label4.Text = "Stage";
                label3.Text = "Id";
                dt.Clear();
                if (z != null)
                {
                    dt = stu.get(z);
                }
                dataGridView1.DataSource = dt;
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(x)
            {
                case "pr":
                    try
                    {
                        dt.Rows.Add(textBox1.Text, textBox2.Text);
                        f.add(dt);
                    }
                    catch {
                        MessageBox.Show("you can't add it twice", "WARNNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "le":
                    try
                    {
                        dt.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                        l.add(dt);
                    }
                    catch {
                        MessageBox.Show("you can't add it twice", "WARNNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "us":
                    try
                    {
                        dt.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
                        s.add(dt);
                    }
                    catch
                    {
                        MessageBox.Show("you can't add it twice", "WARNNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "stu":
                    try
                    {
                        dt.Rows.Add(textBox1.Text, textBox2.Text, z);
                        stu.add(dt, z);
                    }
                    catch
                    {
                        MessageBox.Show("you can't add it twice", "WARNNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow r = dt.Rows.Find(textBox2.Text);
            switch (x)
            {
                case "pr":
                    try
                    {
                        r["Name"] = textBox1.Text;
                        r["Id"] = textBox2.Text;
                        dataGridView1.DataSource = dt;
                        f.add(dt);
                    }
                    catch { }
                    break;
                case "le":
                    try
                    {
                        r["Name"] = textBox1.Text;
                        r["DOCid"] = textBox2.Text;
                        r["Stage"] = textBox3.Text;
                        r["Startime"] = textBox4.Text;
                        r["Endtime"] = textBox5.Text;
                        dataGridView1.DataSource = dt;
                        l.add(dt);
                    }
                    catch { }
                    break;
                case "us":
                    try
                    {
                        r["Name"] = textBox1.Text;
                        r["Id"] = textBox2.Text;
                        r["Position"] = textBox3.Text;
                        dataGridView1.DataSource = dt;
                        s.add(dt);
                    }
                    catch
                    {

                    }
                    break;
                case "stu":
                    try
                    {
                        r["Name"] = textBox1.Text;
                        r["Id"] = textBox2.Text;
                        r["Stage"] = z;
                        dataGridView1.DataSource = dt;
                        stu.add(dt, z);
                    }
                    catch { }
                    break;
            }
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.ReadOnly = true;
            button3.Enabled = true;
            textBox3.ReadOnly = true;
            switch (x)
            {
                case "pr":
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    break;
                case "le":
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox3.ReadOnly = false;
                    break;
                case "us":
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    break;
                case "stu":
                    textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = z;
                    break;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow r = dt.Rows.Find(textBox2.Text);
            
            switch (x)
            {
                case "pr":
                    try
                    {
                        r.Delete();
                    }
                    catch
                    {

                    }
                    dataGridView1.DataSource = dt;
                    f.add(dt);
                    break;
                case "le":
                    try
                    {
                        r.Delete();
                    }
                    catch
                    {

                    }
                    dataGridView1.DataSource = dt;
                    l.add(dt);
                    break;
                case "us":
                    try
                    {
                        r.Delete();
                    }
                    catch
                    {

                    }
                    dataGridView1.DataSource = dt;
                    s.add(dt);
                    break;
                case "stu":
                    try
                    {
                        r.Delete();
                    }
                    catch
                    {

                    }
                    dataGridView1.DataSource = dt;
                    stu.add(dt,z);
                    break;
            }
            button3.Enabled = false;
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
        }

        private void maintane_FormClosing(object sender, FormClosingEventArgs e)
        {

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
        }

        


        

        
    }
}
