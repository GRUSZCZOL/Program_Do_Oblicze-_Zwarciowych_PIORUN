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
        public FormSetLine(string setName,int setIndex,string setNode1_Name, string setNode2_Name, int setNode1_Index, int setNode2_Index)
        {
            InitializeComponent();
            textBox_Line_Name.Text = setName;
            textBox_Line_Index.Text = setIndex.ToString();

            textBox_Node_1_Name.Text = setNode1_Name;
            textBox_Node_2_Name.Text = setNode2_Name;
            textBox_Node_1_Index.Text = setNode1_Index.ToString();
            textBox_Node_2_Index.Text = setNode2_Index.ToString();
        }

        
        // PRZYCISKI FUNKCYJNE
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


        // WYDARZENIA
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormSetLine_Shown(object sender, EventArgs e)
        {

        }
    }
}
