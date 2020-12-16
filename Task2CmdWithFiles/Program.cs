using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabLogicLibrary;

namespace Task2CmdWithFiles
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            LabLogic executer = new LabLogic();
            string path = executer.GetStringPath();
            List<string[]> formatedCoordinates = executer.GetDataFromFile(path);
            executer.ShowFormatedData(formatedCoordinates);
            

        }
    }
}
