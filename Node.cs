using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public class Node : Button 
    {

        public Node(int setIndex) { Index = setIndex; }

        public double voltage_Zone; // Strefa napięcia w jakiej znajduje sie Node

        public int Index; // Index Node'a unikalny dla każdego

        public List<Element> ListOfNghElements = new List<Element> { }; // Lista innych elementów skojarzonych z Node'em

    }
}
