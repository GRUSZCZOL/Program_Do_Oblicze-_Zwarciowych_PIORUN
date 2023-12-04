﻿using System;
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

        public static int button_size_Width = 45; // Rozmiar przycisku
        public static int button_size_Height = 45;


        public static int Point_X1 = 1; 
        public static int Point_X2 = 1;
        public static int Point_Y1 = 1;
        public static int Point_Y2 = 1;
        public static int distance;

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
     

        #region Graphics
        // Zmienne dla grafiki
        //Kolory

        public static Color color_background = Color.White;
        public static Color color_foreground = Color.Black;

        //Inne

        public static int penSize=3;

        public static int m; // zmienna pomocnicza wykorzystywanaa w tworzeniu obiektu linni

        public static int v = 0; // przechowalnia indexów elementów
        public static int b = 0;
        public static bool IsVoltageZones = false; // Określa czy wybór strefy powstał pierwszy raz

        public static int[] InterpolateColor(double t, double n) // t - wybrany indeks // n - wszystkie indexy
        {
            /*int blueR = 0;
            int blueG = 0;
            int blueB = 255;

            // Kolor czerwony
            int redR = 255;
            int redG = 0;
            int redB = 0;

            // Interpolacja wartości RGB w zależności od parametru t
            int interpolatedR = (int)(blueR + (redR - blueR) * t/n);
            int interpolatedG = (int)(blueG + (redG - blueG) * t/n);
            int interpolatedB = (int)(blueB + (redB - blueB) * t/n);*/

            // Interpolacja kolorów tęczy w przestrzeni RGB
            double red = Math.Max(0, Math.Cos(((t * 10 / n) - 1) * Math.PI)); // od 1 do 0
            double green = Math.Max(0, Math.Cos(((t * 10 / n) + 1.0 / 3) * Math.PI)); // od 0 do 1
            double blue = Math.Max(0, Math.Cos(((t * 10 / n) + 2.0 / 3) * Math.PI)); // od 0 do 0

            int interpolatedR = (int)(red * 255);
            int interpolatedG = (int)(green * 255);
            int interpolatedB = (int)(blue * 255);

            return new int[] { interpolatedR, interpolatedG, interpolatedB };
        }
        #endregion


        // Zmienne pomocnicze



        // Listy

    





    }
}