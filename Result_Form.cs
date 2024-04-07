using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public partial class Result_Form : Form
    {
        public Result_Form(double set_I_k, double set_I_b, double set_I_c)
        {
            InitializeComponent();
            I_k = set_I_k;
            I_b = set_I_b;
            I_c = set_I_c;
        } // Konstruktor 3-Faz
        public Result_Form() 
        {
            InitializeComponent();
        } // Konstruktor podstawowy







        // Zmienne

        public double I_k;
        public double I_b;
        public double I_c;


        // Wydarzenia
        private void Result_Form_Shown(object sender, EventArgs e)
        {
            textBox_Result.Text += Var.res + "\n\r";          
        }

        private void button_Save_Result_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.txt|*.txt";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dlg.FileName, textBox_Result.Text);
            }
        } // Zapis do formy tekstowej
    }
}
