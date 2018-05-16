using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileProject.Forms
{
    public partial class cipher : Form
    {
        bool c;
        public cipher()
        {
            InitializeComponent();
            c = true;
            button1.Text = "cipher";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                try
                {
                    textBox1.Text = ceaser.Cipher(textBox1.Text, Int32.Parse(textBox2.Text));
                }
                catch { }
                button1.Text = "Decipher";
                c = false;
            }
            else
            {
                try
                {
                    textBox1.Text = ceaser.Decipher(textBox1.Text, Int32.Parse(textBox2.Text));
                }
                catch { }
                button1.Text = "cipher";
                c = true;
            }

        }

        
    }
}
