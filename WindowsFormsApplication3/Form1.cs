using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripButton1.Click += ToolStripButton1_Click;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox4.ReadOnly = false;
            }
            else
            {
                textBox4.ReadOnly = true;
                textBox4.Clear();
            }
        }

        private bool CheckedText()
        {
            bool flag = true;
            if (Family.Text == "")
            {
                Family.BackColor = Color.MistyRose;
                flag = false;
            }
            else { Family.BackColor = Color.White; }
            if (Imya.Text == "")
            {
                Imya.BackColor = Color.MistyRose;
                flag = false;
            }
            else { Imya.BackColor = Color.White; }
            return flag;
        }

        private bool CheckedListBox1 ()
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                checkedListBox1.BackColor = Color.Beige;
                return true;
            }
            else
            {
                checkedListBox1.BackColor = Color.MistyRose;
                return false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
            else checkBox1.Checked = true;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
            else checkBox2.Checked = true;
        }

        private void Save()
        {
            using (TextWriter writer = new StreamWriter(@"E:\WindowsFormsApplication3\WindowsFormsApplication3\Profile.txt"))
            {
                char ch = 'ж';
                if (checkBox2.Checked) { ch = 'м'; }
                if (comboBox1.Text != "Ваша специальность")
                {
                    writer.Write(Family.Text + ";" + Imya.Text + ";" + Otch.Text + ";" + ch + ";" + numericUpDown1.Value + ";" + comboBox1.Text + ";");
                }
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    writer.Write(item + ";");
                }
                if (checkBox3.Checked)
                {
                    writer.Write(textBox4.Text + ";");
                }
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (CheckedText() && CheckedListBox1())
            {
                Save();
                Form3 f3 = new Form3();
                f3.Show();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
        }
    }
}
