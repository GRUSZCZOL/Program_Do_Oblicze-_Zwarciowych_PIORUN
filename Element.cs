﻿using System;
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

       public List<Node> ListOfNghbNode = new List<Node>(); // Lista sąsiednich Nodeów  

        // Zegary

         public static Timer tim = new Timer();
         
        

        // Punkt poczatkowy

        public int StartX;
        public int StartY;
        public int FinishX;
        public int FinishY;

        int k=0;
        // Typ i index do kategoryzowania

        public int Index;
        public string Type;

        // Rezystancja, Reaktancja, Impedancja

        public Complex R=0;
        public Complex X=0;
        public Complex Z=0;
        
        public void Zfunc(Complex setR, Complex setX)
        {
            Z = Complex.Sqrt(setR * setR + setX * setX);
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
