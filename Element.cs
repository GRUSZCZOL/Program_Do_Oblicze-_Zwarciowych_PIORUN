using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public class Element : Button
    {
       public Element(int setIndex,string setType) 
        {
            Index = setIndex; // Ustala Index dla wybranego elementu
            Type = setType; // Ustala typ elementu
        }
        // Początek i koniec gałęzi
        public int Start; // Początek
        public int End; // Koniec

        // Początek i koniec strefy napięcia
        public int VZ_Start; // Początek
        public int VZ_End; // Koniec

        // Przekładnia
        public double elm_tr_H =1;
        public double elm_tr_L =1;


        public List<Node> ListOfNghbNode = new List<Node>(); // Lista sąsiednich Nodeów  

        public int Index;
        public string Type;

        // Rezystancja, Reaktancja, Impedancja

        //ZGODNA
        public Complex R_1=0;
        public Complex X_1=0;
        public Complex Z_1= new Complex(1, 1);

        public Complex Z_1_H = new Complex(1, 1); // zmienne dla transformatora
        public Complex Z_1_L = new Complex(1, 1);

        //PRZECIWNA
        public Complex R_2 = 0;
        public Complex X_2 = 0;
        public Complex Z_2 = new Complex(1, 1);

        //ZEROWA
        public Complex R_0 = 0;
        public Complex X_0 = 0;
        public Complex Z_0 = new Complex(1, 1);

        //OBLICZENIOWE

        public Complex R = 0;
        public Complex X = 0;
        public Complex Z = new Complex(1,1);

        // Napięcie dla generatora

        public Complex U = new Complex(0, 0);   
        
       public Complex Zfunc(Complex setR, Complex setX)
        {
            Complex c = Complex.Sqrt(setR * setR + setX * setX);
            return c;
        }       
       public void LineReposition() 
        {          // MessageBox.Show(ListOfNghbNode.Count.ToString());

                    double X1 = ListOfNghbNode[0].Location.X;
                    double Y1 = ListOfNghbNode[0].Location.Y;
                    double X2 = ListOfNghbNode[1].Location.X;
                    double Y2 = ListOfNghbNode[1].Location.Y;

                    Location = new Point(Convert.ToInt32(X1 + X2) / 2, Convert.ToInt32(Y1 + Y2) / 2);
        }
       public void DrawingLine(PaintEventArgs e) 
        {
            
            Graphics gra = e.Graphics;

            double X1 = ListOfNghbNode[0].Location.X;
            double Y1 = ListOfNghbNode[0].Location.Y;
            double X2 = ListOfNghbNode[1].Location.X;
            double Y2 = ListOfNghbNode[1].Location.Y;

            gra.DrawLine(new Pen(Color.Blue),Convert.ToInt32(X1), Convert.ToInt32(Y1), Convert.ToInt32(X2), Convert.ToInt32(X2));
        }
            

        
      
        
       
    }
}
