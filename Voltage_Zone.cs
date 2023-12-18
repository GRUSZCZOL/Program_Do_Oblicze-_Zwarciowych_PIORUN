using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public class Voltage_Zone
    {
        public Voltage_Zone(double setVoltageZone, Color setColor) 
        {
            V_Z = setVoltageZone;
            color = setColor;
        }

        public string Name {  get; set; }

        public double V_Z;
        public Color color;



        public List<Element> ListOfTransformators = new List<Element>();
        public List<Element> ListOfLines = new List<Element>();
        public List<Element> ListOfGenerators = new List<Element>();

        public List<Node> ListOfNodes = new List<Node>();
    }
}
