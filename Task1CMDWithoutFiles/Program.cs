using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabLogicLibrary;

namespace Task1CMDWithoutFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            LabLogic executer = new LabLogic();
            List<string[]>formatedCoordinates = executer.GetDataFromConsole();
            executer.ShowFormatedData(formatedCoordinates);


        }
    }
}
