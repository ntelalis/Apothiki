using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apothiki
{
    public partial class Dialog : Form
    {
        public Dialog(String label1s)
        {
            InitializeComponent();
            this.Text = "Νέο Προϊόν";
            label1.Text = label1s;
            this.ActiveControl = textBox1;
        }
        
        public Dialog(String label1s,String label2s)
        {
            InitializeComponent();
            this.Text = "Νέο Κουτί";
            label2.Visible = true;
            textBox2.Visible = true;
            label1.Text = label1s;
            label2.Text = label2s;
            this.ActiveControl = textBox1;
        }

        public String getTextBox1()
        {
            return textBox1.Text;
        }

        public String getTextBox2()
        {
            return textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
