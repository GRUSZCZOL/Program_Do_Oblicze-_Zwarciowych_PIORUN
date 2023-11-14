using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public class Element : Button
    {
       public Element(int setIndex,string setType) 
        {
            Index = setIndex; // Ustala Index dla wybranego elementu
            Type = setType; // Ustala typ elementu
        }


        public int In; // Nazewnictwo węzłów i ich sąsiadó
        public int Out;


        // Typ i index do kategoryzowania

        public List<Node> ListOfNghNodes = new List<Node>();

        public int Index;
        public string Type;

        // Rezystancja, Reaktancja, Impedancja

        Complex R= new Complex(0, 0);
        Complex X= new Complex(0, 0);
        Complex Z= new Complex(0, 0);
        
        void Zfunc(Complex setR, Complex setX)
        {
            Z = Complex.Sqrt(setR * setR + setX * setX);
        }


       public void Reposition() 
        {
            double X1 = ListOfNghNodes[0].Location.X;
            double Y1 = ListOfNghNodes[0].Location.Y;
            double X2 = ListOfNghNodes[1].Location.X;
            double Y2 = ListOfNghNodes[1].Location.Y;

            Location = new Point(Convert.ToInt32(X1+X2/2),Convert.ToInt32(Y1+Y2)/2);

           

        }
    }
}
