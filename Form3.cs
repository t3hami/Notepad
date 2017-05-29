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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           // this.FormClosing += form_Closing;
            this.Text = "Wordpad";
            this.BackColor = Color.Gray;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.richTextBox1.Dock = DockStyle.Fill;
            this.WordWrapToolStripMenuItem.Checked = false;
            this.richTextBox1.WordWrap = false;
            this.copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            this.cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            this.pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            this.selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            this.findReplaceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            this.saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            this.openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            this.menuStrip1.BackColor = Color.DeepSkyBlue;
            this.fileToolStripMenuItem.BackColor = Color.LightBlue;
            this.editToolStripMenuItem.BackColor = Color.LightBlue;
            this.formatToolStripMenuItem.BackColor = Color.LightBlue;
            this.viewToolStripMenuItem.BackColor = Color.LightBlue;
            this.helpToolStripMenuItem1.BackColor = Color.LightBlue;
            //this.fileToolStripMenuItem.Margin = 4;
            this.richTextBox1.BackColor = Color.Silver;
            //this.Icon = new Icon("wordpad.ico");
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.checkCancel(-1);
            if (Program.check == 0)
            {
                Program.f1.Show();
                Program.check = 1;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.checkCancel(1);
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files(*.txt)|*.txt";
            openFileDialog1.Title = "Open Text Files";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Text = (saveFileDialog1.FileName).ToString();
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                this.Text = openFileDialog1.SafeFileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectAll();
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectedText = (System.DateTime.Now).ToString();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectedText.Length > 0)
            {
                this.richTextBox1.SelectedText = "";
                richTextBox1.Focus();
            }
            else
            {
                int x = richTextBox1.SelectionStart;
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart - 1, 1);
                richTextBox1.Select(x - 1, 0);
                richTextBox1.Focus();
            }
        }

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WordWrapToolStripMenuItem.Checked == false)
            {
                this.richTextBox1.WordWrap = true;
                this.WordWrapToolStripMenuItem.Checked = true;
                //this.richTextBox1.ScrollBars = ScrollBars.Vertical;
            }

            else
            {
                this.richTextBox1.WordWrap = false;
                this.WordWrapToolStripMenuItem.Checked = false;
                //this.richTextBox1.ScrollBars = ScrollBars.Both;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowColor = true;
            DialogResult ddr = this.fontDialog1.ShowDialog();
            if (ddr == DialogResult.OK)
            {
                this.richTextBox1.SelectionFont = this.fontDialog1.Font;
                this.fontDialog1.ShowApply = true;
                this.richTextBox1.SelectionColor = this.fontDialog1.Color;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ddr = this.colorDialog1.ShowDialog();
            if (ddr == DialogResult.OK)
                this.richTextBox1.SelectionColor = this.colorDialog1.Color;
        }

      
    }
}
