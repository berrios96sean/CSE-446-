using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secNumGUI
{
    public partial class Form1 : Form
    {
        public int number;
        public int attempts; 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client mySvc = new ServiceReference1.Service1Client();
            this.attempts++;
            label5.Text = attempts.ToString();
            int userNum = Int32.Parse(textBox3.Text);
            string num = mySvc.checkNumber(userNum,this.number);
            label6.Text = num; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client mySvc = new ServiceReference1.Service1Client();
            this.attempts = 0; 
            int lower = Int32.Parse(textBox1.Text);
            int upper = Int32.Parse(textBox2.Text);
            this.number = mySvc.SecretNumber(lower,upper);
            label5.Text = attempts.ToString(); 
        }


    }
}
