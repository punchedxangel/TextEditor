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

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateLineCount()
        {
            if (lineNumbersToolStripMenuItem.Checked && richTextBox1.Lines.Length >= LineNumberTextBox.Lines.Length)
            {
                for (int i = LineNumberTextBox.Lines.Length; i <= richTextBox1.Lines.Length; i++)
                {
                    LineNumberTextBox.Text += i + 1 + "\n";
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Select();
            UpdateLineCount();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog().Equals(DialogResult.Cancel))
            {
                openFileDialog.Dispose();
            }
            else
            {
                string hello = File.ReadAllText(Path.GetFullPath(openFileDialog.FileName));
                richTextBox1.SelectAll();
                richTextBox1.Text += hello;
            }
        }

        private void lineNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!lineNumbersToolStripMenuItem.Checked)
            {
                LineNumberTextBox.ResetText();
            }
        }

        private void LineNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateLineCount();
        }

        private void richTextBox1_Resize(object sender, EventArgs e)
        {
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                OverwritePrompt = true,
            };

            if (saveFileDialog.ShowDialog().Equals(DialogResult.Cancel))
            {
                saveFileDialog.Dispose();
            }
            else
            {
                saveFileDialog.ShowDialog();
                MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(richTextBox1.Text));
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                memoryStream.CopyTo(fileStream);
                fileStream.Dispose();
                memoryStream.Dispose();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.Clear();
        }

        private void defaultSaveLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string topaste = Clipboard.GetText();
        }

        private void backGroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextBox1.BackColor = colorDialog.Color;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lettersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextBox1.ForeColor = colorDialog.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            if (fontDialog.ShowDialog().Equals(DialogResult.Cancel))
            {
                fontDialog.Dispose();
            }
            else
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }
    }
}

