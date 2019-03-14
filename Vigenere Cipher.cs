using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plaintext = textBox1.Text, cipher = "";
            char[] key = textBox2.Text.ToCharArray();
            int i = 0,j=0;
            while(i<plaintext.Length)
            {
                if (j == key.Length) j = 0;
                cipher += (char)((plaintext[i++]-97 + key[j++]-97) % 26 + 97);
            }
            textBox3.Text = cipher;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ciphertext = textBox1.Text, plaintext = "";
            char[] key = textBox2.Text.ToCharArray();
            int i = 0, j = 0;
            while (i < ciphertext.Length)
            {
                if (j == key.Length) j = 0;
                plaintext += (char)(((ciphertext[i++] - 97) - (key[j++] - 97)) % 26 + 97);
            }
            textBox3.Text = plaintext;
        }
    }
}
