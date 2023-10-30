using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public static class Var
    {
        // Zmienne globalne

        public static string mode = "NULL";

        public static int N; // Liczba węzłów

        public static int m_X; // Wspolrzedne myszy X
        public static int m_Y; // Wspolrzedne myszy Y

        public static double scale_pix; // Odniesienie dla skali wyrażone w pikselach
        public static double scale_km; // Odniesienie dla skali wyrażone w km
        public static double scale_pix_per_km; // Odniesienie dla skali wyrażone w pikselach na km

        // Zmienne pomocnicze
    }
}