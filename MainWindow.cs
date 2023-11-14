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

using MathNet.Numerics;
using ComponentFactory.Krypton.Toolkit;
using System.Diagnostics.Eventing.Reader;
using System.Numerics;
using static System.Windows.Forms.AxHost;
using System.Runtime.Remoting.Channels;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        
       
     // Wydarzenia ----------------------------------------------------------------------------------------------------------------------------

        #region MODE TYPE PARTS

            // TRYB MAPY / MAP MODE
        
            private void pictureBox_Map_MouseMove(object sender, MouseEventArgs e)
            {          
                Var.m_X = e.Location.X + pictureBox_Map.Location.X;
                Var.m_Y = e.Location.Y + pictureBox_Map.Location.Y;
               // HELP_Multiline1.Text = string.Format("Pozycja kursora na mapie:X: {0},Y: {1}: ", e.Location.X-20, e.Location.Y-20);
                //HELP_Multiline2.Text = panel_Main_Map.VerticalScroll.Value.ToString() +"\r\n" +panel_Main_Map.HorizontalScroll.Value.ToString();
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
                Cancel_Grab();
                Var.mode = "Build_Node";
                HELP.Text = Var.mode;
            
            }
            private void button_Build_Line_Click(object sender, EventArgs e)
            {
                Cancel_Grab();
                Var.mode = "Build_Line";
                HELP.Text = Var.mode;
            }// Zmiana trybu na budowanie Linii / Tworzy nowy Element: LINE
            private void button_Build_Generator_Click(object sender, EventArgs e)
        {
            Cancel_Grab();
            Var.mode = "Build_Generator";
            HELP.Text = Var.mode;
        } // Przejście do trybu budowania Generatora
            private void button_Build_Delete_Click(object sender, EventArgs e)
            {
                Cancel_Grab();
                Var.mode = "Build_Delete";
                HELP.Text = Var.mode;
            } // Usuwanie wybranego elementu
            private void button_Build_Inspector_Click(object sender, EventArgs e) // Ustawia treyb inspekcji umożliwiający zmiane parametrów elementów
            {
                Cancel_Grab();
                Var.mode = "Build_Inspector";
                HELP.Text = Var.mode;
            }
            private void button_Build_Grab_Click(object sender, EventArgs e)
            {
            
                Var.mode = "Build_Grab";
                HELP.Text = Var.mode;

                foreach (Node item in Database.ListOfNodes) 
                {
                    ControlExtension.Draggable(item, true);
                }
                foreach (Element item in Database.ListOfElements) 
                {
                if(item.Type != "Line") 
                    {
                    ControlExtension.Draggable(item, true);
                    }
            
                }
            } // Ustawia na przenoszenie elementów
           

            private void pictureBox_Map_Click(object sender, EventArgs e) // Inicjowanie budowania wybranego elementu poprzez kliknięcie w PictureBox
            {
                switch (Var.mode) 
                {
                    case "Build_Node": Create_Element_Node(); break;
                    case "Build_Line":  break;
                    case "Build_Transformator": ; break;
                    case "Build_Generator": ; break;
                    case "Build_Receiver": ; break;
                    case "Build_System": ; break;

                    case "Build_Delete": ; break; // Usuwanie wybranego elementu
                    case "Build_Inspector": ; break; // Przejście do trybu inspekcji
                    case "Build_Grab":; break; //Przejście do trybu przesuwania
                    default: MessageBox.Show("Coś poszło nie tak. Upewnij sie, że zmienna Var.mode jest prawidłowo ustawiona"); break;

                }

            }


            // TRYB: ZWARCIE / SHORT MODE


        #endregion




        

             // Funkcje / Metody

            public void Delete_Button(Object sender, EventArgs e)
            {
            Node Nd = sender as Node;

            foreach(Element item in Nd.ListOfNghElements)
            {
                this.Controls.Remove(item);
            }
                int k = panel_Main_Map.HorizontalScroll.Value;
                int l = panel_Main_Map.VerticalScroll.Value;

                if (Var.mode == "Build_Delete")
                {
                    Node ToDelete = sender as Node;
                    ToDelete.Parent = null;
                    this.Controls.Remove(ToDelete);


                    panel_Main_Map.HorizontalScroll.Value = k;
                    panel_Main_Map.VerticalScroll.Value = l;

                    
                    //Zaznaczony element

                }

            } // Usuwa wskazany element
            public void Create_Element_Node()
        {


            Var.N++;
            Node Nd = new Node(Var.N); // Tworzenie nwego elementu
            Var.index_setup++; // Zwi?z?kowanie indeksu elementu
            this.Controls.Add(Nd);

            Nd.Name = "Element_Node_" + Var.N.ToString();
            Nd.Image = ((System.Drawing.Image)(Properties.Resources.Circle)); // Do odkomentowania
            Nd.Size = new Size(40, 40);
            Nd.Location = new Point(Var.m_X + panel_Main_Map.HorizontalScroll.Value - (Nd.Size.Width / 2), Var.m_Y + panel_Main_Map.VerticalScroll.Value - (Nd.Size.Height / 2));
            Nd.Text = Nd.Index.ToString();
            Nd.BringToFront();
            Nd.Show();


            // Wydarzenia zaimplementowane do elementu
            Nd.Click += new EventHandler(this.Delete_Button);
            Nd.Click += new EventHandler(this.Inspector_Node);
            Nd.Click += new EventHandler(this.Create_Element_Line);
            Nd.Click += new EventHandler(this.Create_Element_Generator);
            Nd.MouseUp += new MouseEventHandler(MousePressGrab);


            Nd.Parent = pictureBox_Map;

            Database.ListOfNodes.Add(Nd);




        } // Tworzy nowy Element: NODE
            public void Create_Element_Generator(Object sender, EventArgs e) 
            {
            Node Nd = sender as Node;
            if(Database.Support.Count == 0&& Var.mode =="Build_Generator") 
            {
            Database.Support.Add(Nd);

                
                Element Elm = new Element(Var.index_setup, "Generator"); // Tworzenie nwego elementu
                Var.index_setup++; // Zwi?z?kowanie indeksu elementu
                this.Controls.Add(Elm);

                Elm.Parent = pictureBox_Map;
                Elm.Name = "Element_Generator_" + Var.index_setup.ToString();
                Elm.Image = ((System.Drawing.Image)(Properties.Resources.Circle)); // Do odkomentowania
                Elm.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                Elm.Location = new Point( Nd.Location.X, Nd.Location.Y + 80);
                Elm.Text = "Gen_"+Elm.Index.ToString();
                Elm.BringToFront();
                Elm.Show();

                Elm.Click += new EventHandler(this.Inspector_Element);

                Elm.ListOfNghbNode.Add(Nd);
                Database.ListOfElements.Add(Elm);
                Database.ListOfGenerators.Add(Elm);


                // Wydarzenia zaimplementowane do elementu
                
                // Elm.MouseUp += new MouseEventHandler(MousePressGrab);

                pictureBox_Map.CreateGraphics().DrawLine(new Pen(Color.Blue,3), Nd.Location.X+(Var.button_size_Width/2), Nd.Location.Y + (Var.button_size_Height/2), Elm.Location.X + (Var.button_size_Width/2), Elm.Location.Y + (Var.button_size_Height/2));
                Database.Support.Clear();
            }
            


           
        } // Tworzenie elementu generator
            public void Create_Element_Line(Object sender, EventArgs e) 
        {
            Node Nd = sender as Node;
            if (Database.Support.Count == 0&& Var.mode=="Build_Line") 
            {
                Database.Support.Add(Nd);

            } else if(Database.Support.Count == 1) 
            {
                Database.Support.Add(Nd);
                HELP_Multiline1.Text = Database.Support[0].Name.ToString() +" / " +Database.Support[1].Name.ToString();

                if (Database.Support[0].Location != Database.Support[1].Location && Var.mode == "Build_Line")
                {
                    Element Elm = new Element(Var.index_setup, "Line"); // Tworzenie nowego element

                  //  MessageBox.Show(Database.Support.Count.ToString());

                    Elm.ListOfNghbNode.Add(Database.Support[0]);
                    Elm.ListOfNghbNode.Add(Database.Support[1]);

                    Var.index_setup++;
                    Elm.Parent = pictureBox_Map;
                    Elm.Name = "Element_Line_" + Var.index_setup.ToString();
                    Elm.Image = ((System.Drawing.Image)(Properties.Resources.Cross)); // Do odkomentowania
                    Elm.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                    Elm.Location = new Point(
                        ((Elm.ListOfNghbNode[0].Location.X + Elm.ListOfNghbNode[1].Location.X) / 2) /*+ (Elm.Size.Width / 2)*/,
                        ((Elm.ListOfNghbNode[0].Location.Y + Elm.ListOfNghbNode[1].Location.Y) / 2)) /*+(Elm.Size.Height / 2))*/;

                    Point P = new Point(20, 20);
                    pictureBox_Map.CreateGraphics().DrawLine(new Pen(Color.Blue, 3), Elm.ListOfNghbNode[0].Location.X + (Elm.Size.Width / 2), Elm.ListOfNghbNode[0].Location.Y + (Elm.Size.Height / 2), Elm.ListOfNghbNode[1].Location.X + (Elm.Size.Width / 2), Elm.ListOfNghbNode[1].Location.Y + (Elm.Size.Height / 2));

                   
                    Elm.BringToFront();
                    Elm.Show();

                    Database.ListOfLines.Add(Elm);
                    Database.ListOfElements.Add(Elm);
                    Elm.ListOfNghbNode[0].ListOfNghElements.Add(Elm);
                    Elm.ListOfNghbNode[1].ListOfNghElements.Add(Elm);

                    Elm.Click += new EventHandler(this.Inspector_Element);

                   // comboBox_Control_1.DataSource = Elm.ListOfNghbNode;
                    
                    Database.Support.Clear(); // Czyszczenie listy support  
                }
                else if(Database.Support[0].Location == Database.Support[1].Location) 
                {
                    Database.Support.Clear(); // Czyszczenie listy support  
                }
                

               
            }
            


        } // Pojawia się problem przy tworzeniu linii

       

            public void Cancel_Grab() 
            {
                foreach (Node item in Database.ListOfNodes)
                {
                    ControlExtension.Draggable(item, false);
                }
                foreach (Element item in Database.ListOfElements)
                {
                    if (item.Type != "Line")
                    {
                        ControlExtension.Draggable(item, false);
                    }

            }   

        }// Anuluj przesuwanie elementów
            public void MousePressGrab(Object sender,MouseEventArgs e) 
            {
            if(Var.mode == "Build_Grab") {
                Node Nd = sender as Node;

                pictureBox_Map.Invalidate();
                foreach (Element item in Nd.ListOfNghElements)
                {
                    HELP.Text = item.ListOfNghbNode.Count.ToString();

                    item.LineReposition();                 
                    pictureBox_Map.CreateGraphics().DrawLine(new Pen(Color.Blue, 3), item.ListOfNghbNode[0].Location.X + (item.Size.Width / 2), item.ListOfNghbNode[0].Location.Y + (item.Size.Height / 2), item.ListOfNghbNode[1].Location.X + (item.Size.Width / 2), item.ListOfNghbNode[1].Location.Y + (item.Size.Height / 2));

                }
                
                           
            }
            
           

           

        }  // Zmiana pozycji po przesunięciu // Rysowanie od nowa linii
            public void Inspector_Node(Object sender, EventArgs e) 
        {
            Node Nd = sender as Node;
            if (Var.mode == "Build_Inspector")
            { HELP_Multiline1.Text = Nd.Location.ToString(); }
        }
            public void Inspector_Element(Object sender, EventArgs e) 
        {
            Element Elm = sender as Element;
            if (Var.mode == "Build_Inspector") 
            { HELP_Multiline1.Text = Elm.Location.ToString()+"\r\n"+Elm.Name; }
            
            
        }
            


    } 
}
