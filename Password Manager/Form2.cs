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


namespace PasswordManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void update()
        {
            listBox1.Items.Clear();
            FileStream file = new FileStream("details.yos", FileMode.Open);
            BinaryReader br = new BinaryReader(file);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                listBox1.Items.Add(br.ReadString());
                br.ReadString();
                br.ReadString();
            }
            br.Close();
            file.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            update();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileStream file = new FileStream("details.yos", FileMode.Open);
            BinaryReader br = new BinaryReader(file);
            for(int i=0;i<=listBox1.SelectedIndex;i++)
            {
                br.ReadString();
                textBox1.Text= br.ReadString();
                textBox2.Text = br.ReadString();
            }
            br.Close();
            file.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            FileStream file = new FileStream("password.txt", FileMode.Open);
            StreamReader sr = new StreamReader(file);
            DialogResult d = MessageBox.Show("Decrypting...", "", MessageBoxButtons.OK);
            if(d == DialogResult.OK)
            {
                while ((str = sr.ReadLine()) != null)
                {
                    Sha s = new Sha(str);
                    if (s.GetPassword() == textBox2.Text.ToLower())
                        break;
                }
                MessageBox.Show(str);
            }
            file.Close();
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text;
            int[] flag = { 0, 0, 0, 0 };
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9') flag[0] = 1;
                else if (str[i] >= 'a' && str[i] <= 'z') flag[1] = 1;
                else if (str[i] >= 'A' && str[i] <= 'Z') flag[2] = 1;
                else if ((str[i] >= 33 && str[i] <= 47) || (str[i] >= 58 && str[i] <= 96) || (str[i] >= 123 && str[i] <= 126)) flag[3] = 1;
            }
            if (flag[0] == flag[1] && flag[1] == flag[2] && flag[2] == flag[3] && flag[0] == 1 && str.Length >= 8)
            {
                FileStream file = new FileStream("details.yos", FileMode.Append);
                FileStream file1 = new FileStream("password.txt", FileMode.Append);
                BinaryWriter bw = new BinaryWriter(file);
                StreamWriter sw = new StreamWriter(file1);
                Sha s = new Sha(textBox4.Text);
                bw.Write(textBox5.Text);
                bw.Write(textBox3.Text);
                bw.Write(s.GetPassword());
                file.Close();
                bw.Close();
                sw.WriteLine(textBox4.Text);
                sw.Close();
                file1.Close();
                update();
            }
            else
            {
                MessageBox.Show("Password is not strong!");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            Random rnd = new Random();
            for(int i=0;i<8;i++)
            {
                if (i % 4 == 0) textBox4.Text+= (char)rnd.Next(65, 90);
                else if(i%4==1) textBox4.Text += (char)rnd.Next(33, 126);
                else if (i % 4 == 2) textBox4.Text += (char)rnd.Next(48, 57);
                else if (i % 4 == 3) textBox4.Text += (char)rnd.Next(97, 122);
            }
            label6.Text = textBox4.Text;
        }
    }
}
