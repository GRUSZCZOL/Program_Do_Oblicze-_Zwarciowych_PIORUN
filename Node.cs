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

        public int Index;
        public List<Element> ListOfNghElements = new List<Element> { };

    }
}
