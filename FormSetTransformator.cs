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
    public partial class FormSetTransformator : Form
    {
        public FormSetTransformator(string setName, int setIndex, string setNode1_Name, string setNode2_Name, int setNode1_Index, int setNode2_Index, double setNode1_Voltage_Zone,double setNode2_Voltage_Zone)
        {
            InitializeComponent();
            textBox_Line_Name.Text = setName;
            textBox_Line_Index.Text = setIndex.ToString();

            textBox_Node_1_Name.Text = setNode1_Name;
            textBox_Node_2_Name.Text = setNode2_Name;
            textBox_Node_1_Index.Text = setNode1_Index.ToString();
            textBox_Node_2_Index.Text = setNode2_Index.ToString();
            textBox_Node_1_Voltage_Zone.Text = setNode1_Voltage_Zone.ToString();
            textBox_Node_2_Voltage_Zone.Text = setNode2_Voltage_Zone.ToString();
        }

        private void button_Hide_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormSetTransformator_Shown(object sender, EventArgs e)
        {
            listBox_Set_Transformator.DataSource = Database.ListOfTransformatorData;
            listBox_Set_Transformator.DisplayMember = "Name";
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            if (checkBox_Impedance_Static.Checked == true)
            {
                // Rozwiązanie poprzez ręczne wpisanie Impedancji

                if (textBox_Impedance_Static_Re.Text != null || textBox_Impedance_Static_Im.Text != null)
                {
                    Complex Set_Impedance = new Complex(Convert.ToDouble(textBox_Impedance_Static_Re.Text), Convert.ToDouble(textBox_Impedance_Static_Im.Text));
                    foreach (Element tran in Database.ListOfTransformators)
                    {
                        if (tran.Index == Var.selectedIndex)
                        { tran.Z_1 = Set_Impedance;
                            tran.Image =  ((System.Drawing.Image)(Properties.Resources.Transformator));
                            Hide(); }
                    }
                }
                else
                {
                    MessageBox.Show("Wykryto błąd!", "Funkcja: Wymuś impedancje jest włączona, natomiast wymagane pola nie zwracają wartości");
                }
            }
            else
            {
                // Obliczenia matematyczne

                

                double D_Pcu = Convert.ToDouble(textBox_D_Pcu.Text);
                double D_Pfe = Convert.ToDouble(textBox_D_Pfe.Text); // Nie wybierane w tej wersji
                double U_k = Convert.ToDouble(textBox_uk_prc.Text);
                double S = Convert.ToDouble(textBox_S_value.Text);
                double Ur_H = Convert.ToDouble(textBox_t_H.Text);
                double Ur_L = Convert.ToDouble(textBox_t_L.Text);

                double R_H = (D_Pcu / 100) * (Math.Pow(Ur_H, 2) / S);
                double R_L = (D_Pcu / 100) * (Math.Pow(Ur_L, 2) / S);


                double Z_H = (U_k / 100) * (Math.Pow(Ur_H, 2)/S);
                double Z_L = (U_k / 100) * (Math.Pow(Ur_L, 2) / S);

                double X_H = Math.Sqrt(Math.Pow(Z_H,2) - Math.Pow(R_H,2));
                double X_L = Math.Sqrt(Math.Pow(Z_L, 2) - Math.Pow(R_L, 2));

                Complex Set_Impedance_H = new Complex(R_H,X_H);
                Complex Set_Impedance_L = new Complex(R_L, X_L);

                foreach (Element tran in Database.ListOfTransformators)
                {
                    if (tran.Index == Var.selectedIndex)
                    {   
                        tran.Z_1_H = Set_Impedance_H; 
                        tran.Z_1_L = Set_Impedance_L ;
                        tran.elm_tr_H = Ur_H / Ur_L;
                        tran.elm_tr_L = Ur_L / Ur_H;
                    }
                }

                Hide();

                // MessageBox.Show("R_H = "+R_H+"  X_H = "+ X_H + "Z_H = "+Z_H);

            }
        }
    }
}
