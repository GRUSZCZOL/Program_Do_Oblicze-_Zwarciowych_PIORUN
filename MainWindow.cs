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
using MathNet.Numerics.LinearAlgebra;

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

            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(400,Color.Orange) { Name = "400" , Index = 1});
            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(220, Color.Blue) { Name = "220",Index = 2 });
            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(30, Color.Yellow) { Name = "30", Index = 3 });
            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(6, Color.Red) { Name = "6", Index = 4 });
            Database.ListOfVoltage_Zones.Add(new Voltage_Zone(1, Color.Purple) { Name = "1", Index = 5 });


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
            private void button_Short_Set_Node_Click(object sender, EventArgs e)
            {
            Database.Support.Clear();
            Cancel_Grab();
            Var.mode = "Short_Set_Node";
            HELP.Text = Var.mode;
        } // Ustala miejsce zwarcia

            // TRYB: KONTROLI
             private void button_Check_Elements_Click(object sender, EventArgs e)
             {
                Result_Form R_F = new Result_Form();
                Check_Elements();
                R_F.Show();
             } // Sprawdzanie przypisania elementów
             private void button_Show_elements_Data_Click(object sender, EventArgs e) 
            {
            Result_Form R_F = new Result_Form();
            Show_Elements_Data();
            R_F.Show();
        } // Pokaż dane elementów
             private void button_Show_Ngh_VZ_Click(object sender, EventArgs e)
        {
            Result_Form R_form = new Result_Form();
            foreach (Voltage_Zone item in Database.ListOfVoltage_Zones)
            {
                Var.res += "Dla Strefy: " + item.V_Z.ToString() + " Sąsiednie: " + "\r\n";
                foreach (Voltage_Zone ngh_vz in item.ListOfNghVoltage_Zones)
                {
                    Var.res += "Strefa napięica: " + ngh_vz.V_Z.ToString() + "\r\n";
                    //MessageBox.Show("");
                }
                Var.res += "\r\n";
            }
            R_form.Show();

        } // Pokazuje listę sąsiednich stref napięcia
             private void button_Check_Impedance_Status_Click(object sender, EventArgs e)
        {

            foreach (Element item in Database.ListOfElements)
            {
                Var.res += "Nazwa: " + item.Name + "Impedancja: " + item.Z_1.ToString() + "Dodatkowa Z_H: " + item.Z_1_H.ToString() + "Dodatkowa Z_L: " + item.Z_1_L.ToString() + "\r\n";
            }

            foreach (Node Nd in Database.ListOfNodes)
            {
                Var.res += "Nazwa Węzła: " + Nd.Name + "\r\n";
                Var.res += "----------------------------------------------------------------";

                foreach (Element Elm in Nd.ListOfNghElements)
                {
                    Var.res += "Nazwa: " + Elm.Name + "Impedancja: " + Elm.Z_1.ToString() + "Dodatkowa Z_H: " + Elm.Z_1_H.ToString() + "Dodatkowa Z_L: " + Elm.Z_1_L.ToString() + "\r\n";
                }
            }

            Result_Form R_F = new Result_Form();
            R_F.Show();
        } // Pokazuje impedancje sąsiednich elementó dla Node'a


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
                Nd.Click += new EventHandler(this.Short_Set_Node);
                Nd.MouseUp += new MouseEventHandler(MousePressGrab);


                Nd.Parent = pictureBox_Map;

                Database.ListOfNodes.Add(Nd); // Dodawanie Node'a do ogólnej listy nodów

                Database.ListOfVoltage_Zones[listBox_Voltage_Zones.SelectedIndex].ListOfNodes.Add(Nd); // Dodawanie Node'a do strefy napięcia

            } else { MessageBox.Show("Nie wybrano strefy napięcia"); }


        } // Tworzy nowy Element: NODE
            public void Create_Element_Generator(Object sender, EventArgs e) 
            {
            Node Nd = sender as Node;
            if(Database.Support.Count == 0&& Var.mode =="Build_Generator") 
            {
            Database.Support.Add(Nd);

                Var.index_setup++; // Zwi?z?kowanie indeksu elementu
                Element Elm = new Element(Var.index_setup, "Generator"); // Tworzenie nwego elementu
                
                
                this.Controls.Add(Elm);

                Nd.ListOfNghElements.Add(Elm);
                Elm.ListOfNghbNode.Add(Database.Support[0]);

                Elm.Start = 0; // Ustalenie początku i końca
                Elm.End = Elm.ListOfNghbNode[0].Index;

                Elm.Parent = pictureBox_Map;
                Elm.Name = "Element_Generator_" + Var.index_setup.ToString();
                Elm.Image = ((System.Drawing.Image)(Properties.Resources.Square)); // Do odkomentowania
                Elm.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                Elm.Location = new Point( Nd.Location.X, Nd.Location.Y + 80);
                Elm.Text = "Gen_"+Elm.Index.ToString();
                Elm.BackColor = Elm.ListOfNghbNode[0].BackColor;
                Elm.BringToFront();
                Elm.Show();

                Elm.ListOfNghbNode.Add(Nd);
                Database.ListOfElements.Add(Elm);
                Database.ListOfGenerators.Add(Elm);
                
                foreach (Voltage_Zone vz in Database.ListOfVoltage_Zones) 
                {
                    if (Elm.ListOfNghbNode[0].voltage_Zone == vz.V_Z) 
                    {
                        vz.ListOfGenerators.Add(Elm);
                    }
                } // Dodawanie linii do strefy napięcia

                

                // Wydarzenia
                Elm.Click += new EventHandler(this.Inspector_Element);

                FormSetGenerator FSGen = new FormSetGenerator(Elm.Name, Elm.Index, Elm.ListOfNghbNode[0].Name, Elm.ListOfNghbNode[0].Index);
                Elm.Click += (FormSetGenerator, args) =>
                {
                    if (Var.mode == "Build_Inspector")
                    {
                        Var.selectedIndex = Elm.Index;
                        MessageBox.Show("Nadano indeks: "+ Var.selectedIndex.ToString());
                        FSGen.Show();
                    }


                };

                

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

                    Elm.Start = Elm.ListOfNghbNode[0].Index; // Ustalenie początku i końca
                    Elm.End = Elm.ListOfNghbNode[1].Index;

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

                    Elm.Start = Elm.ListOfNghbNode[0].Index; // Ustalenie początku i końca
                    Elm.End = Elm.ListOfNghbNode[1].Index;

                    Elm.Index = Var.index_setup;
                    Elm.Parent = pictureBox_Map;
                    Elm.Name = "Element_Transformator_" + Var.index_setup.ToString();

                    Elm.BackColor = Color.Purple;
                    Elm.Image = ((System.Drawing.Image)(Properties.Resources.Square)); // Do odkomentowania
                    Elm.Size = new Size(Var.button_size_Width, Var.button_size_Height);
                    Elm.Location = new Point(
                        ((Elm.ListOfNghbNode[0].Location.X + Elm.ListOfNghbNode[1].Location.X) / 2) /*+ (Elm.Size.Width / 2)*/,
                        ((Elm.ListOfNghbNode[0].Location.Y + Elm.ListOfNghbNode[1].Location.Y) / 2)) /*+(Elm.Size.Height / 2))*/;

                    Elm.ListOfNghbNode[0].ListOfNghElements.Add(Elm);
                    Elm.ListOfNghbNode[1].ListOfNghElements.Add(Elm);

                    // Dodawanie sąsiednich stref napięcia

                    // Porównuje liczby zmiennoprzecinkowe // POZMIENIAĆ NA PRZYSZŁOŚĆ
                    foreach (Voltage_Zone vz in Database.ListOfVoltage_Zones) 
                    {
                        if (Elm.ListOfNghbNode[0].voltage_Zone == vz.V_Z) 
                        {
                            foreach (Voltage_Zone vz_ngh in Database.ListOfVoltage_Zones) 
                            {
                                if (vz_ngh.V_Z == Elm.ListOfNghbNode[1].voltage_Zone) 
                                { vz.ListOfNghVoltage_Zones.Add(vz_ngh); }
                                
                            }
                        }

                        if (Elm.ListOfNghbNode[1].voltage_Zone == vz.V_Z) 
                        {
                            foreach (Voltage_Zone vz_ngh in Database.ListOfVoltage_Zones)
                            {
                                if (vz_ngh.V_Z == Elm.ListOfNghbNode[0].voltage_Zone)
                                { vz.ListOfNghVoltage_Zones.Add(vz_ngh); }

                            }
                        }
                    }

                    Point P = new Point(20, 20);
                    pictureBox_Map.CreateGraphics().DrawLine(new Pen(Color.Purple, 3), Elm.ListOfNghbNode[0].Location.X + (Elm.Size.Width / 2), Elm.ListOfNghbNode[0].Location.Y + (Elm.Size.Height / 2), Elm.ListOfNghbNode[1].Location.X + (Elm.Size.Width / 2), Elm.ListOfNghbNode[1].Location.Y + (Elm.Size.Height / 2));


                    Elm.BringToFront();
                    Elm.Show();

                    Database.ListOfTransformators.Add(Elm);
                    Database.ListOfElements.Add(Elm);

                    //Database.ListOfVoltage_Zones[listBox_Voltage_Zones.SelectedIndex].ListOfTransformators.Add(Elm);


                    /*Elm.ListOfNghbNode[0].ListOfNghElements.Add(Elm);
                    Elm.ListOfNghbNode[1].ListOfNghElements.Add(Elm);*/

                    // Przyłączanie transformatora do strefy napięcia
                    foreach (Voltage_Zone item in Database.ListOfVoltage_Zones) 
                    {
                        if (item.V_Z == Elm.ListOfNghbNode[0].voltage_Zone) 
                        {
                            item.ListOfTransformators.Add(Elm);
                            Elm.VZ_Start = item.Index;
                        }                                      
                    }

                    foreach (Voltage_Zone item in Database.ListOfVoltage_Zones) 
                    {
                        if (item.V_Z == Elm.ListOfNghbNode[1].voltage_Zone)
                        {
                            item.ListOfTransformators.Add(Elm);
                            Elm.VZ_End = item.Index;
                        }
                    }







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
            public void Create_Y_mtx()
        {
            Var.Y_1 = Matrix<Complex>.Build.Dense(Var.N, Var.N);
            Var.Z_1 = Matrix<Complex>.Build.Dense(Var.N, Var.N);

            foreach (Voltage_Zone vz in Database.ListOfVoltage_Zones)
            {


                // Przeliczanie impedancji przez przekłądnie strefy // Transformatory osobno


                foreach (Element gen in vz.ListOfGenerators)
                {
                    gen.Z = gen.Z_1 * vz.tr;
                    MessageBox.Show(gen.Name +" / "+ gen.Z.ToString() + " = "+gen.Z_1.ToString() +" * " + vz.tr.ToString());
                    /*                    Var.Y_1[gen.ListOfNghbNode[0].Index - 1, gen.ListOfNghbNode[1].Index - 1] = -1 / gen.Z;
                                        Var.Y_1[gen.ListOfNghbNode[1].Index - 1, gen.ListOfNghbNode[2].Index - 1] = -1 / gen.Z;*/
                }
                foreach (Element line in vz.ListOfLines)
                {
                    line.Z = line.Z_1 * Math.Pow(vz.tr, 2);
                    Var.Y_1[line.ListOfNghbNode[0].Index - 1, line.ListOfNghbNode[1].Index - 1] = -1 / line.Z;
                    Var.Y_1[line.ListOfNghbNode[1].Index - 1, line.ListOfNghbNode[0].Index - 1] = -1 / line.Z;
                }
                foreach (Element tran in vz.ListOfTransformators)
                {
                    Var.Y_1[tran.ListOfNghbNode[0].Index - 1, tran.ListOfNghbNode[1].Index - 1] = -1 / tran.Z;
                    Var.Y_1[tran.ListOfNghbNode[1].Index - 1, tran.ListOfNghbNode[0].Index - 1] = -1 / tran.Z;
                }
                foreach (Node nd in vz.ListOfNodes)
                {
                    foreach (Element elm in nd.ListOfNghElements)
                    {
                        Var.Y_1[nd.Index - 1, nd.Index - 1] += 1 / elm.Z;
                    }
                }

                
            }

            Var.Z_1 = Var.Y_1.Inverse();

        } // Wypełnia macierz poprzez wybór elementów strefy napięcia i uwzględnia przekładnie



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
            { HELP_Multiline1.Text = Nd.Location.ToString() +"\r\n"+Nd.voltage_Zone.ToString()+"\r\n";
            
            foreach(Element elm in Nd.ListOfNghElements) 
                {
                    HELP_Multiline1.Text += elm.Name + " Z_1 => " + elm.Z_1+"\r\n";
                }
                      
            }
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
                HELP_Multiline1.Text += "\r\n" + "Impedancja" + Elm.Z_1.Real + " " + Elm.Z_1.Imaginary+"i"+ "\r\n";
                HELP_Multiline1.Text += "Impedancja" + Elm.Z_1_H.Real + " " + Elm.Z_1_H.Imaginary + "i" + "\r\n";
                HELP_Multiline1.Text += "Impedancja" + Elm.Z_1_L.Real + " " + Elm.Z_1_L.Imaginary + "i" + "\r\n";
            }



        } // Wyświetla informacje o obiekcie
            public void Short_Set_Node(Object sender, EventArgs e) 
            {
            Node Nd = sender as Node;
            if(Var.mode == "Short_Set_Node")

            Var.short_Voltage_Zone = Nd.voltage_Zone; // Strefa napięcia od któej zaczyna się rysowanie grafu
            Var.short_Index = Nd.Index; // Indeks węzła w któym nastąpiło zwarcie

        } // Metoda ustalająca miejsce zwarcia
            public void Check_Elements() 
            {
            for (int i = 0; i < Database.ListOfVoltage_Zones.Count; i++ ) 
            {
                //MessageBox.Show(Database.ListOfVoltage_Zones.Count.ToString());
                Var.res += "Strefa napięcia: " + Database.ListOfVoltage_Zones[i].Name + "\r\n"+"\r\n";
                Var.res += "Elementy typu: LINIA:" + "\r\n";
                foreach(Element line in Database.ListOfVoltage_Zones[i].ListOfLines) 
                {
                    Var.res += line.Name + "\r\n";
                }
                Var.res += "\r\n\r\n";
                Var.res += "Elementy typu: GENERATOR:" + "\r\n";
                foreach (Element gen in Database.ListOfVoltage_Zones[i].ListOfGenerators)
                {
                    Var.res += gen.Name + "\r\n";
                }
                Var.res += "\r\n\r\n";
                Var.res += "Elementy typu: TRANSFORMATOR:" + "\r\n";
                foreach (Element tran in Database.ListOfVoltage_Zones[i].ListOfTransformators)
                {
                    Var.res += tran.Name + "\r\n";
                }
                Var.res += "\r\n\r\n";
                Var.res += "Elementy typu: WĘZEŁ:" + "\r\n";
                foreach (Node Nd in Database.ListOfVoltage_Zones[i].ListOfNodes)
                {
                    Var.res += Nd.Name + "\r\n";
                }
            }
            } // Funkcja odpowiadająca przypisaniu elementów
            public void Show_Elements_Data() 
            {
            foreach (Element Elm in Database.ListOfElements) 
            {
                Var.res += "Nazwa: " + Elm.Name + " Start:  " + Elm.Start + " End: " + Elm.End + "\r\n";
            }
        } // Pokazuje informacje o elementach takie jak początek i koniec
            public void Vz_tr_Data() 
        {
            foreach (Voltage_Zone vz in Database.ListOfVoltage_Zones)
            {
                Var.res += vz.Name + " ==> [";
                foreach (Voltage_Zone ngh_vz in vz.ListOfNghVoltage_Zones)
                {
                    Var.res += ngh_vz.Name + " tr => " + ngh_vz.tr + ",";
                }
                Var.res += "]\r\n";
            }
            /*Result_Form r_f = new Result_Form();
            r_f.Show();*/
        }
            

        #endregion

        #region SOLVERS =================================================================

        // SOLVERS

            public void setToResults_3_Faz() 
            {
            Result_Form R_F = new Result_Form();
            R_F.Show();
            }

            public void Solv_3_Faz() 
            {
            Complex I_1 = new Complex(12,13);

            foreach (Voltage_Zone vz in Database.ListOfVoltage_Zones) 
            {
                if (vz.V_Z == Var.short_Voltage_Zone) 
                {
                    vz.GraphSearch(vz.tr);
                }
            }

            Vz_tr_Data(); // Wyświetla informacje o stanie przekładni
            Create_Y_mtx(); // Wypełnia macierz admitancji
           
            I_1 = (Var.c * Var.short_Voltage_Zone) / (Math.Sqrt(3) *2* Var.Z_1[Var.short_Index-1,Var.short_Index-1]);
            Var.res += "Macierz Admitancji: Y:\r\n" + Var.Y_1;
            Var.res += "Macierz Impedancji: Z:\r\n" + Var.Z_1;
            Var.res += "Prąd I_k: " + I_1.Real + " " + I_1.Imaginary + "i" + " [kA]";

        }






        #endregion

        
    }
}
