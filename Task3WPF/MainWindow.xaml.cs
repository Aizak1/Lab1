using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LabLogicLibrary;

namespace Task3WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LabLogic _executer = new LabLogic();
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open File with tested data and output it in TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            
            string path = _executer.GetStringPath();
           List<string[]> formatedCoordinates = _executer.GetDataFromFile(path);
            if (_executer.FileIsChosen)
                OutputTextBox.Clear();

            foreach (var line in formatedCoordinates)
            {
                OutputTextBox.Text += $"X:{line[0]} Y:{line[1]}\n"; 
            }
        }

        /// <summary>
        /// Check the input char of TextBox.If char isn't digit or a point it wouldn't be entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9-.]+").IsMatch(e.Text);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Clear();
            
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (!String.IsNullOrWhiteSpace(XBox.Text) && !String.IsNullOrWhiteSpace(YBox.Text))
            {
                string line = $"{XBox.Text},{YBox.Text}";
                
                if (_executer.InputFormatIsValid(line))
                {
                    string[] formatedLineItems = _executer.ChangeDotToComma(line.Split(','));
                    OutputTextBox.Text += $"X:{formatedLineItems[0]} Y:{formatedLineItems[1]}\n";
                    XBox.Text = "";
                    YBox.Text = "";
                }
                else
                    MessageBox.Show("Incorrect Format");
               
            }
            else
                MessageBox.Show("You should Enter X and Y");
              
        }
    }
}
