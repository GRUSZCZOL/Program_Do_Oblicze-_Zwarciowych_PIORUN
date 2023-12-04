using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public partial class FormSetGenerator : Form
    {
        public FormSetGenerator()
        {
            InitializeComponent();
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            if (checkBox_Impedance_Static.Checked == true)
            {
                if (textBox_Impedance_Static_Re.Text != null && textBox_Impedance_Static_Im.Text != null)
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
                    MessageBox.Show("Wykryto błąd!", "Funkcja: Wymuś impedancje jest włączona, natomiast wymagane pola nie zwracają wartości");
                }

           
            } // Sprawdzenie warunku dla checkbox Impedancja i ustawienie wartości

            if (checkBox_Voltage_Static.Checked == true)
            {
                if (textBox_Voltage_Static_Re.Text != null && textBox_Voltage_Static_Im.Text != null)
                {
                    Complex Set_Voltage = new Complex(Convert.ToDouble(textBox_Voltage_Static_Re.Text), Convert.ToDouble(textBox_Voltage_Static_Im.Text));
                    foreach (Element gen in Database.ListOfGenerators)
                    {
                        if (gen.Index == Var.selectedIndex)
                        { gen.U = Set_Voltage; Hide(); }
                    }
                }
                else
                {
                    MessageBox.Show("Wykryto błąd!", "Funkcja: Wymuś napięcie jest włączona, natomiast wymagane pola nie zwracają wartości");
                }
            } // Sprawdzenie warunku dla checkbox Napięcie i ustawienie wartości
        }

        private void button_Hide_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void checkBox_Impedance_Static_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Impedance_Static.Checked == true)
            {
                textBox_Impedance_Static_Re.Enabled = true;
                textBox_Impedance_Static_Im.Enabled = true;
            }
            else if (checkBox_Impedance_Static.Checked == false)
            {
                textBox_Impedance_Static_Re.Enabled = false;
                textBox_Impedance_Static_Im.Enabled = true;
            }
        }

        private void checkBox_Voltage_Static_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Voltage_Static.Checked == true)
            {
                textBox_Voltage_Static_Re.Enabled = true;
                textBox_Voltage_Static_Im.Enabled = true;
            }
            else if (checkBox_Impedance_Static.Checked == false)
            {
                textBox_Voltage_Static_Re.Enabled = false;
                textBox_Voltage_Static_Im.Enabled = true;
            }
        }
    }
}
