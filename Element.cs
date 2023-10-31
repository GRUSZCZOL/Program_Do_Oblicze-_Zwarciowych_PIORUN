using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public class Element : Button
    {
       public Element(int setIndex,string setType) 
        {
            Index = setIndex; // Ustala Index dla wybranego elementu
            Type = setType; // Ustala typ elementu
        }

      

        

        // Typ i index do kategoryzowania

        public int Index;
        public string Type;

        // Rezystancja, Reaktancja, Impedancja

        double R=0;
        double X=0;
        double Z=0;
        
        void Zfunc(double setR, double setX)
        {
            Z = Math.Sqrt(setR * setR + setX * setX);
        }
    }
}
