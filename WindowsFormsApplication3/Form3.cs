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

namespace WindowsFormsApplication3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Read_Profile();
        }

        private void Read_Profile()
        {
            if (File.Exists(@"E:\WindowsFormsApplication3\WindowsFormsApplication3\Profile.txt"))
            {
                using (TextReader reader = new StreamReader(@"E:\WindowsFormsApplication3\WindowsFormsApplication3\Profile.txt"))
                {
                    while (true)
                    {
                        string Line = reader.ReadLine();
                        if (string.IsNullOrEmpty(Line)) break;
                        string[] line = Line.Split(';');
                        richTextBox1.Text = "Фамилия: " + line[0] + "\n" +
                            "Имя: " + line[1] + "\n" +
                            "Отчество: " + line[2] + "\n" +
                            "Пол: " + line[3] + "\n" +
                            "Возраст: " + line[4] + "\n" +
                            "Специальность: " + line[5] + "\n" +
                            "Выбор: ";
                        for (int i = 6; i < line.Length - 1; i++)
                        {
                            richTextBox1.Text += line[i] + " ";
                        }
                    }
                }
            }
            else
            {
                richTextBox1.Text = "Файл не существует";
            }
        }

        
    }
}
