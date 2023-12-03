using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_Do_Obliczeń_Zwarciowych_PIORUN
{
    public class Line_Data
    {

        Line_Data(string setName,string setConductorType, bool setWay, double setTemp, double setProfile, double setLenght, double setConductivity, double setMediumdistance) 
        {
            string Name = setName;
            string ConductorType = setConductorType;
            bool Way = setWay;
            double Temp = setTemp;
            double Profile = setProfile;
            double Lenght = setLenght;
            double Conductivity = setConductivity;
            double Mediumdistance = setMediumdistance;

        }
    }
}
