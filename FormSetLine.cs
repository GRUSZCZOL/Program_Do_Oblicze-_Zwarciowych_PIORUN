using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public partial class FormSetLine : Form
    {
        public FormSetLine()
        {
            InitializeComponent();
        }

        

        private void button_Hide_Click(object sender, EventArgs e)
        {
            Hide();
        }

       

        private void button_Accept_Click(object sender, EventArgs e)
        {
            if(checkBox_Impedance_Static.Checked == true) 
            {
                if (textBox_Impedance_Static_Re.Text != null || textBox_Impedance_Static_Im.Text != null)
                {
                    Complex Set_Impedance = new Complex(Convert.ToDouble(textBox_Impedance_Static_Re.Text), Convert.ToDouble(textBox_Impedance_Static_Im.Text));
                    foreach (Element line in Database.ListOfLines) 
                    {
                    if (line.Index == Var.selectedIndex) 
                        { line.Z_1 = Set_Impedance; Hide(); }
                    }
                }
                else 
                {
                    MessageBox.Show("Wykryto błąd!","Funkcja: Wymuś impedancje jest włączona, natomiast wymagane pola nie zwracają wartości");
                }
            }
            else 
            
            {
            
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
