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
    public partial class Short_mode_Settings : Form
    {
        public Short_mode_Settings()
        {
            InitializeComponent();
        }

       

        private void Short_mode_Settings_Load(object sender, EventArgs e)
        {
            textBox_c_value.Text = Var.c.ToString();
            textBox_Frec_value.Text = Var.Frec.ToString();
            
            switch (Var.short_mode) 
            {
                case "3-Faz": checkedListBox_Short_Type.Items[0] = true; break;
                case "3-Faz_GND": break;
                case "2-Faz": break;
                case "2-Faz_GND":break;
                case "1-Faz": break;
                case "1-Faz_GND": break;
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            switch (checkedListBox_Short_Type.SelectedIndex)
            {
                case 0: Var.short_mode = "3-Faz"; break;
                case 1: Var.short_mode = "3-Faz_GND"; break;
                case 2: Var.short_mode = "2-Faz"; break;
                case 3: Var.short_mode = "2-Faz_GND"; break;
                case 4: Var.short_mode = "1-Faz"; break;
                case 5: Var.short_mode = "1-Faz_GND"; break;
            }

            Var.Frec = Convert.ToDouble(textBox_Frec_value);
            Var.c = Convert.ToDouble(textBox_c_value);

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
