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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\johnv\Documents\itlog.csv";
            var sw = new StreamWriter(path, true);
            sw.WriteLine($"{write.Text}");
            sw.Close();
            Close();
        }
    }
}
