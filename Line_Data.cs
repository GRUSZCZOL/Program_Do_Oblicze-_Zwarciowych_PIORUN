using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public class Line_Data
    {

        public Line_Data(string setTypeName,string setPoleType, bool set2Way,double setResistivity, double setTemp, double setLenght, double setConductivity,double setCross_section,double set_r,double set_r_0, double setMediumdistance1,double setMediumdistance2, double setD1_1,double setD2_1, double setD3_1,double setD1_2, double setD2_2, double setD3_2, double setD_w) 
        {
            string type_Name = setTypeName; // Nazwa zapisanych zmian
            string poleType = setPoleType; // Typ słupa
            bool _2Way = set2Way; // Czy jest 2-torowa
            double temp = setTemp; // Temperatura otoczenia
            double resistivity = setResistivity; // Rezystywność gruntu

            
            double lenght = setLenght; // Długość linii
            double conductivity = setConductivity; // Konduktancja lini
            double cross_section = setCross_section; // Przekrój przewodów
            double r = set_r; // promień rzeczywisty przewodu
            double r_0 = set_r_0; // promień nierzeczywisty 

            double mediumdistance1 = setMediumdistance1; // Uśredniona odległość w torze 1
            double D1_1 = setD1_1; 
            double D2_1 = setD2_1;
            double D3_1 = setD3_1;

            double mediumdistance2 = setMediumdistance2; // Uśredniona odległość w torze 2
            double D1_2 = setD1_2;
            double D2_2 = setD2_2;
            double D3_2 = setD3_2;
            double D_w = setD_w; // Odległość między torami           
    }

        public Line_Data() 
        {
        
        }

        

        public string Name { get; set; }
        public string PoleType { get; set; }

        public bool _2Way { get; set; }
        public double temp { get; set; }
        public double resistivity { get; set; }
        public double lenght { get; set; }
        public double conductivity { get; set; }
        public double cross_section { get; set; }
        public double r { get; set; }

        public double r_0 { get; set; }
        public double mediumdistance1 { get; set; }
        public double mediumdistance2 { get; set; }
        public double D1_1 { get; set; }
        public double D2_1 { get; set; }
        public double D3_1 { get; set; }

        public double D1_2 { get; set; }
        public double D2_2 { get; set; }
        public double D3_2 { get; set; }

        public double D_w { get; set; }

    }
}
