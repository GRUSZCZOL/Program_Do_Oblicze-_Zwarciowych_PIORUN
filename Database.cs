using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;


namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public static class Database 
    {
        // Przechowywanie danych dla Combobox i obiektów



        public static List<Element> ListOfElements = new  List<Element>(); // Lista wszystkich elementów
        public static List<Node> ListOfNodes = new List<Node>(); // Lista wszystkich nodów

        public static List<Element> ListOfLines = new List<Element>(); // Lista wszystkich Linii
        public static List<Element> ListOfGenerators = new List<Element>(); // Lista generatorów
        public static List<Element> ListOfTransformators = new List<Element>(); // Lista transforów

        public static List<Node> Support = new List<Node>(); // Lista wspomagająca

        public static List<Complex> ListOf_Nd_Ngh_Elm_Y = new List<Complex>(); // Lista przechowująca informacje o admitancjach obiektów dla Node'a 


        // Zapamiętuje strefy napięcia     public static List<VoltageZone> ListOfVoltageZones = new List<VoltageZone>();

        public static List<Voltage_Zone> ListOfVoltage_Zones = new List<Voltage_Zone>(); // Nowy system Voltage Zones


        public static List<Line_Data> ListOfLineData = new List<Line_Data>(); // Lista przechowująca wszystkie typy linii
        public static List<Generator_Data> ListOfGeneratorData = new List<Generator_Data>(); // Lista przechowująca wszystkie typy Generatorów
        public static List<Transformator_Data> ListOfTransformatorData = new List<Transformator_Data>(); // Lista przechowująca wszystkie typy Transformatorów

        public static Dictionary<int,double> Tr_Data = new Dictionary<int,double>();

        public static double I_k_Re;
        public static double I_k_Im;

        public static Complex I_k = new Complex();


    }
}