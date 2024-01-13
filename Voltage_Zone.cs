using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
        public string Name { get; set; } // Nazwa strefy napięcia 
        public int Index { get; set; } // Indeks określający kolejność w liście będący jednocześnie dentyfikatorem


        // Zmienne definiujące strefe napięcia i kolor
        public double V_Z;
        public Color color;

        // Zmienne operujące na grafie
        public bool isChecked = false; // Ocenia czy dany lement w grafie został sprawdzony

        // Zmienne transformujące impedancje
        public double tr = 1; // Przekładnia transformująca impedancje względem strefy zwarcia (Odniesienia)


        // Listy przechowujące informacje
        public List<Voltage_Zone> ListOfNghVoltage_Zones = new List<Voltage_Zone>(); // Lista sąsiednich stref napięcia

        public List<Element> ListOfTransformators = new List<Element>(); // Lista transformatorów przystających do strefy napięcia
        public List<Element> ListOfLines = new List<Element>(); // Lista elementów typu: Linia
        public List<Element> ListOfGenerators = new List<Element>(); // Lista elementów typu: Generator

        public List<Node> ListOfNodes = new List<Node>(); // Lista elementów typu: Węzeł


        // Funkcja wykrywająca sąsiednie strefy napięcia

        public void GraphSearch (double set_tr)
        {
            double prev_tr = set_tr;

            isChecked = true;

            foreach (Voltage_Zone vz_ngh in ListOfNghVoltage_Zones) 
            {
                if (vz_ngh.isChecked == false) 
                {

                    foreach (Element tran in ListOfTransformators) 
                    {
                        if (vz_ngh.ListOfTransformators.Contains(tran)) 
                        {

                            if (tran.ListOfNghbNode[0].voltage_Zone == V_Z)  // Gdy pierwszy Node jest po stronie górnej grafu //tj od strony z której przyszedł sygnał
                            {
                                tran.Z_1 = tran.Z_1_H;
                                tran.Z = tran.Z_1*tr;                               
                                vz_ngh.tr = Math.Pow(tran.elm_tr_H, 2) * prev_tr;
                            }
                            else // Druga opcja
                            {
                                tran.Z_1 = tran.Z_1_L;
                                tran.Z = tran.Z_1 * tr;
                                vz_ngh.tr = Math.Pow(tran.elm_tr_L, 2) * prev_tr;
                            }// Ustawienie przekładni dla strefy napięcia                           
                        }
                    }// Wysyłanie informacji dalej

                    vz_ngh.GraphSearch(vz_ngh.tr);
                }
            }           
        } // Przszukuje graf i odnajduje transformatory

        







    }
}
