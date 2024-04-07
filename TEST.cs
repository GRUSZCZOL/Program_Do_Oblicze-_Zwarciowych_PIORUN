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
    public partial class TEST : Form
    {
        public TEST(int setNumber)
        {
            
            InitializeComponent();
            Value = setNumber.ToString();

            textBox1.Text = Value;
        }

        string Value;
        

        

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wszystko działa");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
