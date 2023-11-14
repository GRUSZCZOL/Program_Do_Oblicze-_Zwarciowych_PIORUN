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

        public static double PI = 3.141592653589793; // Liczba PI

        public static string mode = "NULL";

        public static int N; // Liczba węzłów

        public static int selectedIndex;

        public static int m_X; // Wspolrzedne myszy X
        public static int m_Y; // Wspolrzedne myszy Y

        public static double scale_pix; // Odniesienie dla skali wyrażone w pikselach
        public static double scale_km; // Odniesienie dla skali wyrażone w km
        public static double scale_pix_per_km; // Odniesienie dla skali wyrażone w pikselach na km

        public static int index_setup = 1111; // Indeks przypisywany do elementu

        public static int button_size_Width = 40; // Rozmiar przycisku
        public static int button_size_Height = 40;


        public static int Point_X1 = 1; 
        public static int Point_X2 = 1;
        public static int Point_Y1 = 1;
        public static int Point_Y2 = 1;
        public static int distance;

             // Parametry elektryczne

        public static double Frec = 50; //Częstotliwość

        

        /* public static void Distanse_Point(double setX1,double setX2,double setY1, double setY2) // Funkcja określająca odległość między punktami
         {
             // Punkt początkowy i końcowy dla Linii
             Point_X1 = Convert.ToDouble(setX1);
             Point_X2 = setX2;
             Point_Y1 = setY1;
             Point_Y2 = setY2;
             distance = Math.Sqrt(Math.Pow(Point_X2-Point_X1,2) +   Math.Pow(Point_Y2-Point_Y1,2) ) ;
         }*/

        #region Graphics
        // Zmienne dla grafiki
        //Kolory

        public static Color color_background = Color.White;
        public static Color color_foreground = Color.Black;

        //Inne

        public static int penSize=3;

       

        #endregion
        // Zmienne pomocnicze

        public static int m; // zmienna pomocnicza wykorzystywanaa w tworzeniu obiektu linni

        public static int v = 0; // przechowalnia indexów elementów
        public static int b = 0;

        // Listy

       

    }
}