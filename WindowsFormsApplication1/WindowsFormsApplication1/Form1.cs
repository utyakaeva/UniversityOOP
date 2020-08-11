using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0.9;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)//нажатие любой клавиши мыши
        {
            button2.ForeColor = System.Drawing.Color.Green;
            MessageBox.Show(textBox1.Text);
        }

        private void Form1_MouseLeave(object sender, EventArgs e)//покидание мыши объекта
        {
            label1.ForeColor = System.Drawing.Color.Red;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.ForeColor = System.Drawing.Color.Red;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            button1.Enabled = false; 
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Black;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                MessageBox.Show("Нажали <ENTER>");
        }
    }
}
