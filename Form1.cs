using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        string[] login = new string[6];
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackColor=Color.DarkSlateGray;
            this.BackColor = Color.Teal;
            this.AcceptButton = button2;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Text = "Login Window";
            this.label1.Text = "Username";
            this.label2.Text = "Password";
            this.textBox2.PasswordChar = '*';
            this.button1.Text = "Cancel";
            this.button2.Text = "Login";
            this.label3.Text = "";
            this.radioButton1.Text = "Notepad";
            this.radioButton2.Text = "Wordpad";
            this.button3.Text = "Next";
            this.button4.Text = "Logout";
            this.radioButton1.Enabled = false;
            this.radioButton2.Enabled=true;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            string l = File.ReadAllText("passwordFile.txt");
            login = l.Split(',');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isLogin=false;
            for (int i = 0; i < login.Length;i++ )
            {
                if (this.textBox1.Text == login[i].Split(' ')[0] && this.textBox2.Text == login[i].Split(' ')[1])
                {
                    this.AcceptButton = button3;
                    this.textBox1.Enabled = false;
                    this.textBox2.Enabled = false;
                    this.label1.Enabled = false;
                    this.label2.Enabled = false;
                    this.button1.Enabled = false;
                    this.button2.Enabled = false;
                    this.radioButton1.Enabled = true;
                    this.radioButton2.Enabled = true;
                    this.button4.Enabled = true;
                    this.label3.Text = "Access granted";
                    this.label3.ForeColor = Color.Blue;
                    isLogin = true;
                }
            }
                if(!isLogin)
                {
                    this.label3.Text = "Access denied";
                    this.label3.ForeColor = Color.Red;
                    count++;
                }
            if (count == 3)
            {
                MessageBox.Show("Sorry you are banned!");
                Application.Exit();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.button3.Enabled = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.label3.Text = "";
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.radioButton1.Enabled = false;
            this.radioButton2.Enabled = false;
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.label1.Enabled = true;
            this.label2.Enabled = true;
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.TabStop == true)
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.Show();
            }
            else if (this.radioButton2.TabStop == true)
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
        }


    }
}
