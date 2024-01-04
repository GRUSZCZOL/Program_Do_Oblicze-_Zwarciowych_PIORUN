using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using System.Numerics;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public static class Var
    {
        // Zmienne globalne

        public static double PI = 3.141592653589793; // Liczba PI

        public static string mode = "NULL";

        public static int N; // Liczba węzłów

        public static double short_Voltage_Zone;
        public static int short_Index;

        public static string res;

        public static int selectedIndex;
        public static int selectedVoltage_ZoneIndex;

        public static int m_X; // Wspolrzedne myszy X
        public static int m_Y; // Wspolrzedne myszy Y

        public static double scale_pix; // Odniesienie dla skali wyrażone w pikselach
        public static double scale_km; // Odniesienie dla skali wyrażone w km
        public static double scale_pix_per_km; // Odniesienie dla skali wyrażone w pikselach na km

        public static int index_setup = 1111; // Indeks przypisywany do elementu

        public static int button_size_Width = 64; // Rozmiar przycisku
        public static int button_size_Height = 64;


        // Parametry elektryczne

        public static string short_mode = "3-Faz";

            // 3-Faz             - trójfazowe
            // 3-Faz_GND         - trójfazowe z ziemią
            // 2-Faz             - międzyprewodowe
            // 2-Faz_GND         - międzyprewodowe
            // 1-Faz             - jednofazowe
            // 1-Faz_GND         - jednofazowe z ziemią



        public static double Frec = 50; //Częstotliwość

        public static double c = 1.1 ; // Parametr korygujący zwarcie

        public static Matrix<Complex> Z_1 = Matrix<Complex>.Build.Dense(1, 1);
        public static Matrix<Complex> Y_1 = Matrix<Complex>.Build.Dense(1, 1);









    }
}