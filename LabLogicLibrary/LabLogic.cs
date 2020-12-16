using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace LabLogicLibrary
{
   
    public class LabLogic
    {
        private bool _fileIsChosen;
        public bool FileIsChosen => _fileIsChosen;
        public string GetStringPath()
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text documents (.txt)| *.txt"
            };
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
              
        }

        public List<string[]> GetDataFromFile(string path)
        {
           
            List<string[]> formatedCoordinates = new List<string[]>();
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();
                        if (InputFormatIsValid(line))
                        {
                            string[] lineItems = line.Split(',');
                            formatedCoordinates.Add(ChangeDotToComma(lineItems));
                        }
                            
                    }
                    _fileIsChosen = true;
                   return formatedCoordinates;
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.ToString());
                _fileIsChosen = false;
                return new List<string[]>();
            }
        }

        public List<string[]> GetDataFromConsole()
        {
            List<string[]> formatedCoordinates = new List<string[]>();
            Console.WriteLine("Enter coordinates in format: FirstCoordinate,Second Coordinate.If you want to stop enter \'exit\'");
            string userInput = Console.ReadLine();
            while (userInput != "exit")
            {
                if (InputFormatIsValid(userInput))
                {
                    string[] lineItems = userInput.Split(',');
                    formatedCoordinates.Add(ChangeDotToComma(lineItems));
                }
                    
                    userInput = Console.ReadLine();
            }
           
            return formatedCoordinates;
        }

        public string[] ChangeDotToComma(string[] coordinates)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                string formatedLine = coordinates[i].Replace('.', ',');
                coordinates[i] = formatedLine;
            }
            return coordinates;
        }

        public void ShowFormatedData(List<string[]> formatedCoordinates)
        {
            foreach (var line in formatedCoordinates)
            {
                Console.WriteLine($"X:{line[0]} Y:{line[1]}");
            }
        }
        public bool InputFormatIsValid(string line)
        {
            string[] lines = line.Split(',');
            try
            {
                float x = Convert.ToSingle(lines[0], new NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                });
                x = Convert.ToSingle(lines[1], new NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

      
       

       
    }
}
