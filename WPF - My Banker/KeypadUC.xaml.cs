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

        private void generic_Click(object sender, RoutedEventArgs e)
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

        private void BackToAtm(bool loggedIn)
        {
            main.CloseKeypad(loggedIn);
        }

        private void ResetCode()
        {
            foreach (Label label in code)
            {
                label.Content = "*";
            }
        }

        private void ChangeCodeLabel(Label label, int codeNum)
        {
            label.Content = codeNum;
        }

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
