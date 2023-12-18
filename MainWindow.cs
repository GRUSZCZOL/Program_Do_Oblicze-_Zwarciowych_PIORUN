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

            private void MainWindow_Load(object sender, EventArgs e)
        {
            // UZUPEŁNIANIE BAZ DANYCH

            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(400,Color.Orange) { Name = "400" });
            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(220, Color.Blue) { Name = "220" });
            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(30, Color.Yellow) { Name = "30" });
            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(6, Color.Red) { Name = "6" });
            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(1, Color.Purple) { Name = "1" });


            listBox_Voltage_Zones.DataSource = Database.ListOfVoltage_Zones;
            listBox_Voltage_Zones.DisplayMember = "Name";





                        Database.ListOfLineData.Add(new Line_Data() { Name = "AFL", PoleType = "B04",temp = 25,resistivity=200,lenght=10,conductivity=44,cross_section=280,r = 6,r_0=7,D1_1=6,D2_1=5,D3_1=6 }); 
                        Database.ListOfLineData.Add(new Line_Data() {  Name = "AFL2", PoleType = "A03", temp = 25, resistivity = 100, lenght = 8, conductivity = 44, cross_section = 140, r = 6, r_0 = 5, D1_1 = 6, D2_1 = 2, D3_1 = 2 }); 
                        Database.ListOfLineData.Add(new Line_Data() {  Name = "Test", PoleType = "C02", temp = 25, resistivity = 300, lenght = 2, conductivity = 33, cross_section = 280, r = 6, r_0 = 5, D1_1 = 6, D2_1 = 8, D3_1 = 6}); 
        }

        // Wydarzenia ----------------------------------------------------------------------------------------------------------------------------

        #region MODE TYPE PARTS =================================================================

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

            //////////////////////////////// Strefa napięcia
            private void button_Voltage_Zones_Add_Click(object sender, EventArgs e) // Dodawanie stryfy napięcia
        {
            if (textBox_Set_Voltage_Zone.Text != null)
            { listBox_Voltage_Zones.Items.Add(textBox_Set_Voltage_Zone.Text); }
            else { MessageBox.Show("Nie ustawiono wartości"); }
        }
            private void button_Voltage_Zones_Delete_Click(object sender, EventArgs e)
        {
            while (listBox_Voltage_Zones.SelectedItems.Count > 0)
            {
                listBox_Voltage_Zones.Items.Remove(listBox_Voltage_Zones.SelectedItems[0]);
            }
        } // Usuwanie strefy napięcia




            //////////////////////////////// Przyciski budowania
            private void button_Build_Node_Click(object sender, EventArgs e) // Przejście do trybu budowania Węzła
            {
                Database.Support.Clear();
                Cancel_Grab();
                Var.mode = "Build_Node";
                HELP.Text = Var.mode;
            
            }
            private void button_Build_Line_Click(object sender, EventArgs e)
            {
                Database.Support.Clear();
                Cancel_Grab();
                Var.mode = "Build_Line";
                HELP.Text = Var.mode;
            }// Zmiana trybu na budowanie Linii / Tworzy nowy Element: LINE
            private void button_Build_Generator_Click(object sender, EventArgs e)
            {
                Database.Support.Clear();
                Cancel_Grab();
                Var.mode = "Build_Generator";
                HELP.Text = Var.mode;
            } // Przejście do trybu budowania Generatora
            private void button_Build_Transformator_Click(object sender, EventArgs e)
            {
                Database.Support.Clear();
                Cancel_Grab();
                Var.mode = "Build_Transformator";
                HELP.Text = Var.mode;
            } // Przycisk odpowiedzialny za budwanie transformatora



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


            //////////////////////////////// Funkcje mapy
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

            private void button_Short_parameters_Click(object sender, EventArgs e)
        {
            Short_mode_Settings SM_Set = new Short_mode_Settings();
            SM_Set.Show();
        } // Pokazuje parametry zwarciowe
            private void button_Short_Run_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Włączono przycisk");
            // 3-Faz             - trójfazowe
            // 3-Faz_GND         - trójfazowe z ziemią
            // 2-Faz             - międzyprewodowe
            // 2-Faz_GND         - międzyprewodowe
            // 1-Faz             - jednofazowe
            // 1-Faz_GND         - jednofazowe z ziemią

            switch (Var.short_mode) 
            {
                case "3-Faz": Solv_3_Faz(); setToResults_3_Faz(); break;
                case "3-Faz_GND": MessageBox.Show("Brak Solvera !"); break;
                case "2-Faz": MessageBox.Show("Brak Solvera !"); break;
                case "2-Faz_GND": MessageBox.Show("Brak Solvera !"); break;
                case "1-Faz": MessageBox.Show("Brak Solvera !"); break;
                case "1-Faz_GND": MessageBox.Show("Brak Solvera !"); break;                
            }
        } // Rozpoczyna obliczenia zwarciowe

        #endregion

        #region FUNCTION =================================================================

            // FUNCTION / METHODS

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
                if (listBox_Voltage_Zones.SelectedItems.Count > 0) 
                
            {
                Var.N++;
                Node Nd = new Node(Var.N); // Tworzenie nwego elementu
                Var.index_setup++; // Zwi?z?kowanie indeksu elementu
                this.Controls.Add(Nd);

                Nd.voltage_Zone = Database.ListOfVoltage_Zones[listBox_Voltage_Zones.SelectedIndex].V_Z;
                Nd.Name = "Node_" + Var.N.ToString();
                Nd.Image = ((System.Drawing.Image)(Properties.Resources.Circle));
                Nd.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                Nd.Location = new Point(Var.m_X + panel_Main_Map.HorizontalScroll.Value - (Nd.Size.Width / 2), Var.m_Y + panel_Main_Map.VerticalScroll.Value - (Nd.Size.Height / 2));
                Nd.Text = Nd.Index.ToString();

                // Color bc = Color.FromArgb(Var.InterpolateColor(listBox_Voltage_Zones.SelectedIndex, listBox_Voltage_Zones.Items.Count)[0], Var.InterpolateColor(listBox_Voltage_Zones.SelectedIndex, listBox_Voltage_Zones.Items.Count)[1], Var.InterpolateColor(listBox_Voltage_Zones.SelectedIndex, listBox_Voltage_Zones.Items.Count)[2]);
                //;
                Nd.BackColor = Database.ListOfVoltage_Zones[listBox_Voltage_Zones.SelectedIndex].color;
                Nd.BringToFront();
                Nd.Show();


                // Wydarzenia zaimplementowane do elementu
                Nd.Click += new EventHandler(this.Delete_Button);
                Nd.Click += new EventHandler(this.Inspector_Node);
                Nd.Click += new EventHandler(this.Create_Element_Line);
                Nd.Click += new EventHandler(this.Create_Element_Generator);
                Nd.Click += new EventHandler(this.Create_Element_Transformator);
                Nd.MouseUp += new MouseEventHandler(MousePressGrab);


                Nd.Parent = pictureBox_Map;

                Database.ListOfNodes.Add(Nd);
                Database.ListOfVoltage_Zones[listBox_Voltage_Zones.SelectedIndex].ListOfNodes.Add(Nd);

            } else { MessageBox.Show("Nie wybrano strefy napięcia"); }


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

                Elm.ListOfNghbNode.Add(Database.Support[0]);

                Elm.Parent = pictureBox_Map;
                Elm.Name = "Element_Generator_" + Var.index_setup.ToString();
                Elm.Image = ((System.Drawing.Image)(Properties.Resources.Square)); // Do odkomentowania
                Elm.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                Elm.Location = new Point( Nd.Location.X, Nd.Location.Y + 80);
                Elm.Text = "Gen_"+Elm.Index.ToString();
                Elm.BackColor = Elm.ListOfNghbNode[0].BackColor;
                Elm.BringToFront();
                Elm.Show();


                FormSetGenerator FSGen = new FormSetGenerator(Elm.Name, Elm.Index, Elm.ListOfNghbNode[0].Name, Elm.ListOfNghbNode[0].Index);


                Elm.Click += new EventHandler(this.Inspector_Element);
                Elm.Click += (FormSetGenerator, args) =>
                {
                    if (Var.mode == "Build_Inspector")
                    {
                        Var.selectedIndex = Elm.Index;
                        FSGen.Show();
                    }


                };

                Elm.ListOfNghbNode.Add(Nd);
                Database.ListOfElements.Add(Elm);
                Database.ListOfGenerators.Add(Elm);

                Database.ListOfVoltage_Zones[listBox_Voltage_Zones.SelectedIndex].ListOfGenerators.Add(Elm);


                // Wydarzenia zaimplementowane do elementu
                
                // Elm.MouseUp += new MouseEventHandler(MousePressGrab);

                pictureBox_Map.CreateGraphics().DrawLine(new Pen(Elm.ListOfNghbNode[0].BackColor,3), Nd.Location.X+(Var.button_size_Width/2), Nd.Location.Y + (Var.button_size_Height/2), Elm.Location.X + (Var.button_size_Width/2), Elm.Location.Y + (Var.button_size_Height/2));
                Database.Support.Clear();
            }
            


           
        } // Tworzenie elementu generator
            public void Create_Element_Line(Object sender, EventArgs e) 
        {
            Node Nd = sender as Node;
            if (Database.Support.Count == 0&& Var.mode=="Build_Line") 
            {
                Database.Support.Add(Nd);

            } else if(Database.Support.Count == 1 && Var.mode == "Build_Line") 
            {
                Database.Support.Add(Nd);
                HELP_Multiline1.Text = Database.Support[0].Name.ToString() +" / " +Database.Support[1].Name.ToString();

                if (Database.Support[0].Location != Database.Support[1].Location && Var.mode == "Build_Line" && Database.Support[0].voltage_Zone == Database.Support[1].voltage_Zone)
                {
                    Var.index_setup++;
                    Element Elm = new Element(Var.index_setup, "Line"); // Tworzenie nowego element
                    
                    Elm.ListOfNghbNode.Add(Database.Support[0]);
                    Elm.ListOfNghbNode.Add(Database.Support[1]);

                    Elm.Index = Var.index_setup;
                    Elm.Parent = pictureBox_Map;
                    Elm.Name = "Element_Line_" + Var.index_setup.ToString();
                    
                    Elm.BackColor = Elm.ListOfNghbNode[1].BackColor;
                    Elm.Image = ((System.Drawing.Image)(Properties.Resources.Cross)); // Do odkomentowania
                    Elm.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                    Elm.Location = new Point(
                        ((Elm.ListOfNghbNode[0].Location.X + Elm.ListOfNghbNode[1].Location.X) / 2) /*+ (Elm.Size.Width / 2)*/,
                        ((Elm.ListOfNghbNode[0].Location.Y + Elm.ListOfNghbNode[1].Location.Y) / 2)) /*+(Elm.Size.Height / 2))*/;

                    Point P = new Point(20, 20);
                    pictureBox_Map.CreateGraphics().DrawLine(new Pen(Elm.ListOfNghbNode[1].BackColor, 3), Elm.ListOfNghbNode[0].Location.X + (Elm.Size.Width / 2), Elm.ListOfNghbNode[0].Location.Y + (Elm.Size.Height / 2), Elm.ListOfNghbNode[1].Location.X + (Elm.Size.Width / 2), Elm.ListOfNghbNode[1].Location.Y + (Elm.Size.Height / 2));

                   
                    Elm.BringToFront();
                    Elm.Show();

                    Database.ListOfLines.Add(Elm);
                    Database.ListOfElements.Add(Elm);

                    Database.ListOfVoltage_Zones[listBox_Voltage_Zones.SelectedIndex].ListOfLines.Add(Elm);

                    Elm.ListOfNghbNode[0].ListOfNghElements.Add(Elm);
                    Elm.ListOfNghbNode[1].ListOfNghElements.Add(Elm);

                    Elm.Click += new EventHandler(this.Inspector_Element);

                    FormSetLine fsline = new FormSetLine(Elm.Name, Elm.Index, Elm.ListOfNghbNode[0].Name, Elm.ListOfNghbNode[1].Name, Elm.ListOfNghbNode[0].Index, Elm.ListOfNghbNode[1].Index);
                    Elm.Click += (FormSetLine, args) =>
                    {
                        if(Var.mode == "Build_Inspector")
                        {
                            Var.selectedIndex = Elm.Index;                           
                            fsline.Text = "Ustawienie Parametrów Obiektu: Linia";
                            fsline.Show();                           
                        }
                        

                    };

                   // comboBox_Control_1.DataSource = Elm.ListOfNghbNode;
                    
                    Database.Support.Clear(); // Czyszczenie listy support  
                }
                else 
                {
                    MessageBox.Show("Zaznaczono ten sam obiekt lub wskazano dwie różne strefy napięcia");
                    Database.Support.Clear(); // Czyszczenie listy support  
                }
                

               
            }
            


        } // Tworzenie elementu linii
            public void Create_Element_Transformator(Object sender, EventArgs e) 
            {
            Node Nd = sender as Node;

            if(Database.Support.Count == 0 && Var.mode == "Build_Transformator") 
            {               
                Database.Support.Add(Nd);
            }
            else if(Database.Support.Count == 1 && Var.mode == "Build_Transformator") 
            {
                Database.Support.Add(Nd);
                if (Database.Support[0].voltage_Zone != Database.Support[1].voltage_Zone && Database.Support[0].Location != Database.Support[1].Location) 
                {
                    MessageBox.Show("POWODZENIE: Wybrano dwie różne strefy napięcia");

                    Var.index_setup++;
                    Element Elm = new Element(Var.index_setup, "Transformator"); // Tworzenie nowego element

                    Elm.ListOfNghbNode.Add(Database.Support[0]);
                    Elm.ListOfNghbNode.Add(Database.Support[1]);

                    Elm.Index = Var.index_setup;
                    Elm.Parent = pictureBox_Map;
                    Elm.Name = "Element_Transformator_" + Var.index_setup.ToString();

                    Elm.BackColor = Color.Purple;
                    Elm.Image = ((System.Drawing.Image)(Properties.Resources.Square)); // Do odkomentowania
                    Elm.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                    Elm.Location = new Point(
                        ((Elm.ListOfNghbNode[0].Location.X + Elm.ListOfNghbNode[1].Location.X) / 2) /*+ (Elm.Size.Width / 2)*/,
                        ((Elm.ListOfNghbNode[0].Location.Y + Elm.ListOfNghbNode[1].Location.Y) / 2)) /*+(Elm.Size.Height / 2))*/;

                    Point P = new Point(20, 20);
                    pictureBox_Map.CreateGraphics().DrawLine(new Pen(Color.Purple, 3), Elm.ListOfNghbNode[0].Location.X + (Elm.Size.Width / 2), Elm.ListOfNghbNode[0].Location.Y + (Elm.Size.Height / 2), Elm.ListOfNghbNode[1].Location.X + (Elm.Size.Width / 2), Elm.ListOfNghbNode[1].Location.Y + (Elm.Size.Height / 2));


                    Elm.BringToFront();
                    Elm.Show();

                    Database.ListOfTransformators.Add(Elm);
                    Database.ListOfElements.Add(Elm);

                    Database.ListOfVoltage_Zones[listBox_Voltage_Zones.SelectedIndex].ListOfTransformators.Add(Elm);

                    Elm.ListOfNghbNode[0].ListOfNghElements.Add(Elm);
                    Elm.ListOfNghbNode[1].ListOfNghElements.Add(Elm);
                    Elm.Click += new EventHandler(this.Inspector_Element);

                    FormSetTransformator F_tr = new FormSetTransformator(Elm.Name, Elm.Index, Elm.ListOfNghbNode[0].Name, Elm.ListOfNghbNode[1].Name, Elm.ListOfNghbNode[0].Index, Elm.ListOfNghbNode[1].Index, Elm.ListOfNghbNode[0].voltage_Zone, Elm.ListOfNghbNode[1].voltage_Zone);
                    Elm.Click += (FormSetTransformator, args) =>
                    {
                        if (Var.mode == "Build_Inspector")
                        {
                            Var.selectedIndex = Elm.Index;
                            F_tr.Text = "Ustawienie Parametrów Obiektu: Transformator";
                            F_tr.Show();
                        }


                    };


                    Database.Support.Clear();
                }
                else 
                {
                    MessageBox.Show("NIEPOWODZENIE: Wybrano tę samą strefe napięcia");
                    Database.Support.Clear();
                }
            
            
            
            
            
            
            
            
            
            
            
            
            }

        } // Tworzenie elementu transformator



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
            { HELP_Multiline1.Text = Nd.Location.ToString() +"\r\n"+Nd.voltage_Zone.ToString(); }
        } // Wyświetla informacje o obiekcie
            public void Inspector_Element(Object sender, EventArgs e)
        {
            Element Elm = sender as Element;
            if (Var.mode == "Build_Inspector" && Elm.Type == "Generator")
            { HELP_Multiline1.Text = Elm.Location.ToString() + "\r\n" + Elm.Name + "\r\n"+ 
                    "Napięcie: " + Elm.U.Real.ToString() + " +j" + Elm.U.Imaginary.ToString() +"\r\n" + 
                    "Impedancja: " + "\r\n" + Elm.Z_1.Real + " +j" + Elm.Z_1.Imaginary; }
            else if (Var.mode == "Build_Inspector" && Elm.Type == "Line") 
            {
                HELP_Multiline1.Text = Elm.Location.ToString() + "\r\n" + Elm.Name + "\r\n" + "Napięcie: " + Elm.U.Real.ToString() + " +j" + Elm.U.Imaginary.ToString() + "\r\n" + "Impedancja: " + "\r\n" + Elm.Z_1.Real + " +j" + Elm.Z_1.Imaginary;
            }
            else if(Var.mode == "Build_Inspector")
            {
                HELP_Multiline1.Text = Elm.Location.ToString() + "\r\n" + Elm.Name;
                HELP_Multiline1.Text = "\r\n" + "Impedancja" + Elm.Z_1.Real + Elm.Z_1.Imaginary+"i";
            }



        } // Wyświetla informacje o obiekcie

        #endregion

        #region SOLVERS =================================================================

            // SOLVERS

            public void setToResults_3_Faz() 
        {
            Result_Form R_F = new Result_Form(Solv_3_Faz()[0], Solv_3_Faz()[1], Solv_3_Faz()[2]);
            R_F.Show();

        }
            public double[] Solv_3_Faz() 
        {





            double I_k = 1;
            double I_c = 3;
            double I_b = 2;

        
        return new double[] { I_k, I_b, I_c };
        }


        #endregion

    }
}
