using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDialogContainer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Halo");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new();
            form1.Show();
        }

        private void menu11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu111ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Haloo!");
        }

        private void menu2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Isi Pesan", "Judul", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Pilih OK");
            }
            else
            {
                MessageBox.Show("Pilih Cancel");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            label1.ForeColor = colorDialog1.Color;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog(this);
            label1.Font = fontDialog1.Font;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // direktori asal
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";

            // memfilter ekstensi file
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            //openFileDialog1.ShowDialog(this);
            //label1.Text = openFileDialog1.SafeFileName;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string content = File.ReadAllText(openFileDialog1.FileName);
                textBox1.Text = content;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string content = textBox1.Text;
                File.WriteAllText(saveFileDialog1.FileName, content);
            }
        }
    }
}
