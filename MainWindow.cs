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
using ComponentFactory.Krypton.Toolkit;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        // Wydarzenia

        #region MODE TYPE PARTS

        // TRYB MAPY / MAP MODE
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_Map_MouseMove(object sender, MouseEventArgs e)
        {          
            Var.m_X = e.Location.X + pictureBox_Map.Location.X;
            Var.m_Y = e.Location.Y + pictureBox_Map.Location.Y;
            HELP_Multiline1.Text = string.Format("Pozycja kursora na mapie:X: {0},Y: {1}: ", e.Location.X, e.Location.Y);
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
        

            
            pictureBox_Map.Image = null; // zamienia obraz na null

            // TODO: Usuwanie mapy wraz z elementami

            
        }









        // TRYB: BUDOWANIE / BUILD MODE
        private void button_Build_Node_Click(object sender, EventArgs e) // Przejście do trybu budowania Węzła
        {
            Var.mode = "Build_Node";
            HELP_Multiline2.Text = Var.mode;
        }

        private void pictureBox_Map_Click(object sender, EventArgs e) // Inicjowanie budowania wybranego elementu poprzez kliknięcie w PictureBox
        {
            switch (Var.mode) 
            {
                case "Build_Node": Create_Element_Node(); break;
                case "Build_Line": /*Create_Element_Line()*/ break;
                case "Build_Transformator": /*Create_Element_Transformer()*/; break;
                case "Build_Generator": /*Create_Element_Generator()*/; break;
                case "Build_Receiver": /*Create_Element_Receiver()*/; break;
                case "Build_System": /*Create_Element_System()*/; break;
                case "Build_Delete": /*Delete_Element()*/; break;

                default: MessageBox.Show("Coś poszło nie tak. Upewnij sie że typ string mode jest prawidłowo ustawiony"); break;

            }

        }

        private void button_Build_Delete_Click(object sender, EventArgs e)
        {
            Var.mode = "Build_Delete";
            HELP_Multiline2.Text = Var.mode;
        } // Usuwanie wybranego elementu

        #endregion






        // Funkcje / Metody

        public void Delete_Button(Object sender, EventArgs e)
        {
            if (Var.mode == "Build_Delete")
            {
                Element ToDelete = sender as Element;
                ToDelete.Parent = null;
                this.Controls.Remove(ToDelete);

                //Zaznaczony element

            }

        } // Usuwa wskazany element

    




        public void Create_Element_Node()
        {
            Var.N++;
            Element newElement = new Element(Var.index_setup,"Node"); // Tworzenie nwego elementu
            Var.index_setup++; // Zwi?z?kowanie indeksu elementu
            this.Controls.Add(newElement);
            newElement.Parent = pictureBox_Map;
            newElement.Name = "Element_Node_" + Var.N.ToString();
            newElement.Image = ((System.Drawing.Image)(Properties.Resources.Circle)); // Do odkomentowania
            newElement.Size = new Size(40, 40);
            newElement.Location = new Point(Var.m_X-(newElement.Size.Width/2),   Var.m_Y-(newElement.Size.Height/2));      
            newElement.BringToFront(); 
            newElement.Show();
            

            // Wydarzenia zaimplementowane do elementu
            newElement.Click += new EventHandler(this.Delete_Button);
            newElement.Click += new EventHandler(this.Create_Element_Line_For_Node);


        } // Tworzy nowy Element: NODE

        public void Create_Element_Line_For_Node(Object sender, EventArgs e)
        {
       
            Element thisElement = sender as Element;
            if (Var.mode == "Build_Line" && Var.m == 0)
            {
                Var.Point_X1 = thisElement.Location.X + (thisElement.Size.Width / 2);
                Var.Point_Y1 = thisElement.Location.Y + (thisElement.Size.Height / 2);
                Var.m = 1;

            }
            else if (Var.mode == "Build_Line" && Var.m == 1)
            {
                Var.Point_X2 = thisElement.Location.X + (thisElement.Size.Width / 2);
                Var.Point_Y2 = thisElement.Location.Y + (thisElement.Size.Height / 2);
                Var.m = 0;
                if(Var.Point_X1!=Var.Point_X2 && Var.Point_Y1 != Var.Point_Y2)
                {
                    Point P_1 = new Point(Convert.ToInt32(Var.Point_X1), Convert.ToInt32(Var.Point_Y1));
                    Point P_2 = new Point(Convert.ToInt32(Var.Point_X2), Convert.ToInt32(Var.Point_Y2));
                    pictureBox_Map.CreateGraphics().DrawLine(new Pen(Color.Blue, 3), P_1, P_2);

                    Element newElement = new Element(Var.index_setup, "Line"); // Tworzenie nwego elementu
                    Var.index_setup++; // Zwi?z?kowanie indeksu elementu
                    this.Controls.Add(newElement);
                    newElement.Parent = pictureBox_Map;
                    newElement.Name = "Element_Line_" + Var.N.ToString();
                    newElement.Image = ((System.Drawing.Image)(Properties.Resources.Cross)); // Do odkomentowania
                    newElement.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                    newElement.Location = new Point( 
                        ((Var.Point_X1+Var.Point_X2)/2)-(newElement.Size.Width/2)                ,   
                        ((Var.Point_Y1 + Var.Point_Y2) / 2)- (newElement.Size.Width / 2));
                    newElement.BringToFront();
                    newElement.Show();

                    Var.m = 0;
                }
               

            }
            else if (Var.mode != "Build_Line") { Var.m = 0; }
        } // Tworzy nowy Element: LINE / Funkcja przypisywana do każdego elementu NODE

        private void button_Build_Line_Click(object sender, EventArgs e)
        {
            Var.mode = "Build_Line";
            HELP_Multiline2.Text = Var.mode;
        }// Zmiana trybu na budowanie Linii / Tworzy nowy Element: LINE
    } 
}
