using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace WPF___My_Banker
{
    /// <summary>
    /// Interaction logic for KeypadUC.xaml
    /// </summary>
    public partial class KeypadUC : UserControl
    {
        private Label[] code;
        private MainWindow main;
        public KeypadUC(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
            code = new Label[4] { Label_Code_1, Label_Code_2, Label_Code_3, Label_Code_4 };
        }

        /// <summary>
        /// Updates code when a number button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            foreach (Label label in code)
            {
                if (label.Content.ToString() == "*")
                {
                    int numClicked = Convert.ToInt16(clickedButton.Content);
                    ChangeCodeLabel(label, numClicked);
                    if (label == Label_Code_4)
                    {
                        if (PostCode())
                        {
                            BackToAtm(true);
                        }
                        else
                        {
                            ResetCode();
                        }
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// Closes keypad window and returns to atm
        /// </summary>
        /// <param name="loggedIn"></param>
        private void BackToAtm(bool loggedIn)
        {
            main.CloseKeypad(loggedIn);
        }

        /// <summary>
        /// Resets the code
        /// </summary>
        private void ResetCode()
        {
            foreach (Label label in code)
            {
                label.Content = "*";
            }
        }

        /// <summary>
        /// Changes the code label to match the number key pressed
        /// </summary>
        /// <param name="label"></param>
        /// <param name="codeNum"></param>
        private void ChangeCodeLabel(Label label, int codeNum)
        {
            label.Content = codeNum;
        }

        /// <summary>
        /// Sends code for validating
        /// </summary>
        /// <returns>A bool if the code was corret</returns>
        private bool PostCode()
        {
            string codeConcat = "";
            foreach (Label label in code)
            {
                codeConcat += label.Content;
            }
            try
            {
                return main.manager.ValidatePINCode(codeConcat);
            }
            catch (NotImplementedException)
            {
                return true;
            }
        }
    }
}
