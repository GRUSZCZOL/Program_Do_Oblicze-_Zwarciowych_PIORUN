using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Complex32;
using MathNet.Numerics;


namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        // Funkcje
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_Map_MouseMove(object sender, MouseEventArgs e)
        {          
            Var.m_X = e.Location.X + pictureBox_Map.Location.X;
            Var.m_Y = e.Location.Y + pictureBox_Map.Location.Y;
            HELP.Text = "Pozycja: " + string.Format("{0}: ,{1}: ", e.Location.X, e.Location.Y);
        }  // Lokalizowanie pozycji myszy

        private void button_Map_Select_Click(object sender, EventArgs e)
        {
            // Wgrywanie pliku przez filtrowanie treści

            this.openFileDialog1.Filter = "BMP Files (*.BMP;*.DIB;*.RLE)|*.BMP;*.DIB;*.RLE|JPEG Files (*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|GIF Files(*.GIF)|*.GIF|TIFF Files (*.TIF;*.TIFF)|*.TIF;*.TIFF|PNG Files(*.PNG)|*.PNG";
           // Filtr dla obrazów

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                // Ustawienia PictureBox i wgrywanie pliku ze ścieżki

                Bitmap bmp = new Bitmap(filename);
                int size_x = bmp.Width;
                int size_y = bmp.Height;
                pictureBox_Map.Visible = true;
                pictureBox_Map.Height = size_y;
                pictureBox_Map.Width = size_x;
                pictureBox_Map.Image = Image.FromFile(filename);
                Var.N = 0;
            }
        } // Załadowanie mapy przez przycisk button_Map_Select

        private void button_Map_Delete_Click(object sender, EventArgs e) // Usuwanie mapy
        {
            #region Testowanie funkcji statycznej
            /*HELP_Multiline1.Text += Test_Values.Number.ToString() + "      ";
            Test_Values.Number = 1;
            HELP_Multiline1.Text += Test_Values.Number.ToString();
            HELP_Multiline1.Text += " ----- ";
            Test_Values.newList.Add(1);
            Test_Values.newList.Add(2);
            Test_Values.newList.Add(3);
            Test_Values.newList.Add(N + 1);

            foreach (int item in Test_Values.newList)
            {
                HELP_Multiline1.Text += item.ToString();
            }

            Test_Values.newList.Clear();
            HELP_Multiline1.Text += Test_Values.newList.Count.ToString();*/

            #endregion
            pictureBox_Map.Image = null; // zamienia obraz na null

            // TODO: Usuwanie mapy wraz z elementami

            
        }

       
    }
}
