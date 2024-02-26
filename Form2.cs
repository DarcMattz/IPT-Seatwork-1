using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPT_Seatwork_1
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 form)
        {
            InitializeComponent();
            this.form1 = form;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
            form1.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\Users\johnv\Documents\itlog.csv"))
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\johnv\Documents\itlog.csv"))
                {
                    sw.WriteLine("Student ID, Name, Course, Year, Section, Subject, Grade");
                }
                var writeForm = new Form3();
                writeForm.ShowDialog();
            }
            else
            {
                var writeForm = new Form3();
                writeForm.ShowDialog();
            }

            
        }
    }
}
