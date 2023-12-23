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

        // Zmienne identyfikujące strfe napięcia
        public string Name {  get; set; } // Nazwa strefy napięcia 
        public int Index { get; set; } // Indeks określający kolejność w liście będący jednocześnie dentyfikatorem


        // Zmienne definiujące strefe napięcia i kolor
        public double V_Z;
        public Color color;

        // Zmienne operujące na grafie
        public bool isChecked = false; // Ocenia czy dany lement w grafie został sprawdzony

        // Zmienne transformujące impedancje
        public double tr; // Przekładnia transformująca impedancje względem strefy zwarcia (Odniesienia)


        // Listy przechowujące informacje
        public List<Voltage_Zone> ListOfNghVoltage_Zones = new List<Voltage_Zone>(); // Lista sąsiednich stref napięcia

        public List<Element> ListOfTransformators = new List<Element>(); // Lista transformatorów przystających do strefy napięcia
        public List<Element> ListOfLines = new List<Element>(); // Lista elementów typu: Linia
        public List<Element> ListOfGenerators = new List<Element>(); // Lista elementów typu: Generator

        public List<Node> ListOfNodes = new List<Node>(); // Lista elementów typu: Węzeł


        // Funkcja wykrywająca sąsiednie strefy napięcia

        public void Parasite(Object sender) // Funkja pasożytnicza
        {           
        foreach(Voltage_Zone item in ListOfNghVoltage_Zones) 
            {
               item.ListOfNghVoltage_Zones.Remove(this);
            }
        }
    }
}
