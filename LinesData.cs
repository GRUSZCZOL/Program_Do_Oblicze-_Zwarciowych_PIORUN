using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    internal class LinesData
    {
        public LinesData(int setIndex, string setName, double setX, double setR, string setType) 
        {
            index = setIndex; // Index nowo wstawionego elemenatu
            name = setName; // Nazwa nowo wstawionego elemenatu
            X = setX; // Reaktancja nowo wstawionego elemenatu
            R = setR; // Rezystancja nowo wstawionego elemenatu
            Type = setType; // Typ nowo wstawionego elemenatu

        }

        string name = "NULL";
        string Type = "NULL";
        double X = 0;
        double R = 0;
        int index = 0;


    }
}
