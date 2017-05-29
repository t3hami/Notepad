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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += form_Closing;
            this.Text="Notepad";
            this.BackColor = Color.Gray;
            this.FormBorderStyle=FormBorderStyle.Fixed3D;
            this.textBox1.Dock = DockStyle.Fill;
            this.WordWrapToolStripMenuItem.Checked = false;
            this.textBox1.ScrollBars = ScrollBars.Both;
            this.textBox1.WordWrap = false;
            this.copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            this.cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            this.pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            this.selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            this.findReplaceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            this.saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            this.openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            this.button1.Text = "Find Next";
            this.button2.Text = "Replace";
            this.button3.Text= "Replace All";
            this.button4.Text = "Cancel";
            this.label1.Text = "Find What:";
            this.label2.Text = "Replace With:";
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            this.menuStrip1.BackColor = Color.DeepSkyBlue;
            this.fileToolStripMenuItem.BackColor = Color.LightBlue;
            this.editToolStripMenuItem.BackColor = Color.LightBlue;
            this.formatToolStripMenuItem.BackColor = Color.LightBlue;
            this.helpToolStripMenuItem1.BackColor = Color.LightBlue;
            //this.fileToolStripMenuItem.Margin = 4;
            this.textBox1.BackColor = Color.Silver;
            this.Icon = new Icon("notepad.ico");
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.f1.Show();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.fontDialog1.Font = new Font("new times roman",9f);
            this.fontDialog1.ShowColor = true;
            DialogResult ddr = this.fontDialog1.ShowDialog();
            if (ddr == DialogResult.OK)
            {
                this.textBox1.Font = this.fontDialog1.Font;
                this.fontDialog1.ShowApply = true;
                this.textBox1.ForeColor = this.fontDialog1.Color;


            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ddr = this.colorDialog1.ShowDialog();
            if (ddr == DialogResult.OK)
                this.textBox1.ForeColor = this.colorDialog1.Color;
        }

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WordWrapToolStripMenuItem.Checked == false)
            {
                this.textBox1.WordWrap = true;
                this.WordWrapToolStripMenuItem.Checked = true;
                this.textBox1.ScrollBars = ScrollBars.Vertical;
            }

            else
            {
                this.textBox1.WordWrap = false;
                this.WordWrapToolStripMenuItem.Checked = false;
                this.textBox1.ScrollBars = ScrollBars.Both;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button1.Visible = true;
            this.button2.Visible = true;
            this.button3.Visible = true;
            this.button4.Visible = true;
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.textBox2.Visible = true;
            this.textBox3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string[] st = this.textBox1.Text.Split(' ');
            foreach (string s in st)
            {
                if (s == this.textBox2.Text)
                {
                    textBox1.Focus();
                    textBox1.Select(textBox1.Text.IndexOf(textBox2.Text),textBox2.Text.Length);
                }
            }*/
            string search = "";
            int count = 0;
            for (int i=0; i < this.textBox1.Text.Length-this.textBox2.Text.Length+1; )
            {
                count++;
                for (int j = 0; j < this.textBox2.Text.Length; j++,i++)
                {
                    search += this.textBox1.Text[i];
                }
                if (textBox2.Text == search)
                {
                    textBox1.Focus();
                    textBox1.Select(textBox1.Text.IndexOf(textBox2.Text), textBox2.Text.Length);
                    search = "";
                    break;
                }
                else
                    search = "";
                i = count;
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName,textBox1.Text);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files(*.txt)|*.txt";
            openFileDialog1.Title = "Open Text Files";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Text = (saveFileDialog1.FileName).ToString();
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                this.Text = openFileDialog1.SafeFileName;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.textBox1.SelectedText.Length > 0)
            {
                this.textBox1.SelectedText = "";
                textBox1.Focus();
            }
            else
            {
                int x = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart - 1, 1);
                textBox1.Select(x - 1, 0);
                textBox1.Focus();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.checkCancel(1);
            Form2 f2 = new Form2();            
            f2.Show();

        }

        private void form_Closing(Object sender, FormClosingEventArgs e)
        {
            Program.checkCancel(-1);
            if (Program.check == 0)
            {
                Program.f1.Show();
                Program.check = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.textBox1.SelectedText.Length>0)
            this.textBox1.SelectedText = this.textBox3.Text;
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectedText = (System.DateTime.Now).ToString();
        }

        

        
    }

}
