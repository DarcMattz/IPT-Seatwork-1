using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace IPT_Seatwork_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
            Form2 options = new Form2(this);
            options.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Only text files| *.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(textBox1.Text))
                    {
                        string handle;
                        int it = 0;
                        int math = 0;
                        int ce = 0;
                        int ee = 0;
                        double grades = 0;
                        int count = 0;
                        richTextBox1.Clear();
                        while ((handle = sr.ReadLine()) != null)
                        {
                            string[] data = handle.Split(',');
                            string id = data[0];
                            string name = data[1];
                            string course = data[2];
                            string year = data[3];
                            string section = data[4];
                            string subject = data[5];
                            string grade = data[6];

                            try
                            {
                                grades += double.Parse(grade);
                                count++;
                            }
                            catch (Exception ex)
                            {

                            }

                            if (data[2] == "IT")
                            {
                                it += 1;
                            }
                            if (data[2] == "MATH")
                            {
                                math += 1;
                            }
                            if (data[2] == "CE")
                            {
                                ce += 1;
                            }
                            if (data[2] == "EE")
                            {
                                ee += 1;
                            }
                            richTextBox1.AppendText(id + "\t\t" + name + "\t\t" + course + "\t\t" + year + "\t\t" + section + "\t\t" + subject + "\t\t" + grade + "\n");
                        }

                        richTextBox1.AppendText("\nAnalytics\n\n");
                        richTextBox1.AppendText("No. of Course: 4\n");
                        richTextBox1.AppendText("IT: " + it + "\n");
                        richTextBox1.AppendText("MATH: " + math + "\n");
                        richTextBox1.AppendText("CE: " + ce + "\n");
                        richTextBox1.AppendText("EE: " + ee + "\n");
                        richTextBox1.AppendText("Average Grade: " + (grades / count) + "\n\n\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Text = string.Empty;
            Hide();
            Form2 options = new Form2(this);
            options.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Browse First!");
                return;
            }

            richTextBox1.Clear();
            bool isfound = false;
            int it = 0;
            int math = 0;
            int ce = 0;
            int ee = 0;
            double grades = 0;
            int count = 0;
            using (StreamReader sr = new StreamReader(textBox1.Text))
            {
                string handle;
                //while(!sr.EndOfStream)
                while ((handle = sr.ReadLine()) != null)
                {
                    string[] datas = handle.Split(',');
                    string id = datas[0];
                    string name = datas[1];
                    string course = datas[2];
                    string year = datas[3];
                    string section = datas[4];
                    string subject = datas[5];
                    string grade = datas[6];

                    try
                    {
                        grades += double.Parse(grade);
                        count++;
                    }
                    catch (Exception ex)
                    {

                    }

                    if (datas[2] == "IT")
                    {
                        it += 1;
                    }
                    if (datas[2] == "MATH")
                    {
                        math += 1;
                    }
                    if (datas[2] == "CE")
                    {
                        ce += 1;
                    }
                    if (datas[2] == "EE")
                    {
                        ee += 1;
                    }

                    richTextBox1.AppendText(id + "\t\t" + name + "\t\t" + course + "\t\t" + year + "\t\t" + section + "\t\t" + subject + "\t\t" + grade + "\n");

                }

                richTextBox1.AppendText("\nAnalytics\n\n");
                richTextBox1.AppendText("No. of Course: 4\n");
                richTextBox1.AppendText("IT: " + it + "\n");
                richTextBox1.AppendText("MATH: " + math + "\n");
                richTextBox1.AppendText("CE: " + ce + "\n");
                richTextBox1.AppendText("EE: " + ee + "\n");
                richTextBox1.AppendText("Average Grade: " + (grades / count) + "\n\n\n");
            }

            using (StreamReader sr = new StreamReader(textBox1.Text))
            {
                string handle;
                while ((handle = sr.ReadLine()) != null)
                {
                    string[] data = handle.Split(',');
                    if (data[1] == textBox2.Text)
                    {
                        isfound = true;
                        string id = data[0];
                        string name = data[1];
                        string course = data[2];
                        string year = data[3];
                        string section = data[4];
                        string subject = data[5];
                        string grade = data[6];

                        richTextBox1.AppendText("Name: " + name + "\nCourse: " + course + "\nYear: " + year + "\nSection: " + section + "\nGrade: " + grade + "\n");
                    }
                }
            }
            if (!isfound)
            {
                MessageBox.Show("No student with that name!");
            }
        }
    }
}
