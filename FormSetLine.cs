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
using ComponentFactory.Krypton.Toolkit;
using System.CodeDom.Compiler;
using System.Security.Policy;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public partial class FormSetLine : Form
    {
        public FormSetLine(string setName, int setIndex, string setNode1_Name, string setNode2_Name, int setNode1_Index, int setNode2_Index)
        {
            InitializeComponent();
            textBox_Line_Name.Text = setName;
            textBox_Line_Index.Text = setIndex.ToString();

            textBox_Node_1_Name.Text = setNode1_Name;
            textBox_Node_2_Name.Text = setNode2_Name;
            textBox_Node_1_Index.Text = setNode1_Index.ToString();
            textBox_Node_2_Index.Text = setNode2_Index.ToString();
        }
        //

        public bool SelectedIndexChange = true;

        // PRZYCISKI FUNKCYJNE

        private void button_Hide_Click(object sender, EventArgs e)
        {
            Hide();
        } // Zamknięcie okna bez jesgo edycji
        private void button_Accept_Click(object sender, EventArgs e)
        {
            if (checkBox_Impedance_Static.Checked == true)
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
                    MessageBox.Show("Wykryto błąd!", "Funkcja: Wymuś impedancje jest włączona, natomiast wymagane pola nie zwracają wartości");
                }
            }
            else if(checkBox_units_parameters.Checked == true)
            {
                Complex Set_Impedance = new Complex(Convert.ToDouble(textBox_units_parameters_resistance.Text)*Convert.ToDouble(textBox_Lenght_value.Text), Convert.ToDouble(textBox_units_parameters_reactance.Text) * Convert.ToDouble(textBox_Lenght_value.Text));
                foreach (Element line in Database.ListOfLines)
                {
                    if (line.Index == Var.selectedIndex)
                    { line.Z_1 = Set_Impedance; Hide(); }
                }
            }
            else 
            {
            
            }
        } // Akceptacja // Zamknięcie okna // Wyliczanie impedancji
        private void button_Delete_Click(object sender, EventArgs e)
        {
            SelectedIndexChange = false;

            Database.ListOfLineData.RemoveAt(comboBox_Form_Set_Line.SelectedIndex);
            comboBox_Form_Set_Line.DataSource = null;
            comboBox_Form_Set_Line.DataSource = Database.ListOfLineData;
            comboBox_Form_Set_Line.DisplayMember = "Name";


            SelectedIndexChange = true;

        } // Usuwanie wybranego elementu
        private void button_Duplicate_Click(object sender, EventArgs e)
        {
            SelectedIndexChange = false;

            int k = comboBox_Form_Set_Line.SelectedIndex;
            Line_Data L_D = Database.ListOfLineData[k];
            Database.ListOfLineData.Add(L_D);

            comboBox_Form_Set_Line.DataSource = null;
            comboBox_Form_Set_Line.DataSource = Database.ListOfLineData;
            comboBox_Form_Set_Line.DisplayMember = "Name";

            SelectedIndexChange = true;

        } // Duplikowanie wybranego elementu
        private void button_Add_Click(object sender, EventArgs e) // Dodawanie nowego elementu
        {
            SelectedIndexChange = false;

            Database.ListOfLineData.Add(new Line_Data() { Name = comboBox_Form_Set_Line.Text, PoleType = comboBox3.SelectedText, temp = Convert.ToDouble(textBox_Temp.Text), resistivity = Convert.ToDouble(textBox_Resistivity_GND.Text), lenght = Convert.ToDouble(textBox_Lenght_value.Text), conductivity = Convert.ToDouble(textBox_Conductivity_value.Text), cross_section = Convert.ToDouble(textBox_S_value.Text), r = Convert.ToDouble(textBox_r_value.Text), r_0 = Convert.ToDouble(textBox_r_0_value.Text), D1_1 = Convert.ToDouble(textBox_Line_1_D1.Text), D2_1 = Convert.ToDouble(textBox_Line_1_D2.Text), D3_1 = Convert.ToDouble(textBox_Line_1_D3.Text) });
            comboBox_Form_Set_Line.DataSource = null;
            comboBox_Form_Set_Line.DataSource = Database.ListOfLineData;
            comboBox_Form_Set_Line.DisplayMember = "Name";

            SelectedIndexChange = true;

        }  // DOPORPRAWY!!!!!!!!
        private void button_Save_Click(object sender, EventArgs e)
        {
            SelectedIndexChange = false;


            SelectedIndexChange = true;

        } // Zapisuje wybrane zmiany w elemencie
       


        // WYDARZENIA

        private void FormSetLine_Load(object sender, EventArgs e)
        {

            comboBox_Form_Set_Line.DataSource = Database.ListOfLineData;
            comboBox_Form_Set_Line.DisplayMember = "Name";

        }
        private void comboBox_Form_Set_Line_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChange != false)
            {
                textBox_Lenght_value.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].lenght.ToString();
                textBox_Conductivity_value.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].conductivity.ToString();
                textBox_S_value.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].cross_section.ToString();
                textBox_Resistivity_GND.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].resistivity.ToString();
                textBox_r_value.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].r.ToString();
                textBox_r_0_value.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].r_0.ToString();
                textBox_Line_1_D1.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].D1_1.ToString();
                textBox_Line_1_D2.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].D2_1.ToString();
                textBox_Line_1_D3.Text = Database.ListOfLineData[comboBox_Form_Set_Line.SelectedIndex].D3_1.ToString();
            }




        } // Wczytywanie danych podczas zmiany indeksu



    }
}