using System;
using System.Collections.Generic;
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
    /// Interaction logic for AtmUC.xaml
    /// </summary>
    public partial class AtmUC : UserControl
    {
        MainWindow main;
        Button[] leftBtns;
        Label[] leftLabels;

        Button[] rightBtns;
        Label[] rightLabels;

        public AtmUC(MainWindow mainWindow)
        {
            main = mainWindow;
            InitializeComponent();

            leftBtns = new Button[4] { Btn_Left_1, Btn_Left_2, Btn_Left_3, Btn_Left_4 };
            leftLabels = new Label[4] { Label_Left_1, Label_Left_2, Label_Left_3, Label_Left_4 };

            rightBtns = new Button[4] { Btn_Right_1, Btn_Right_2, Btn_Right_3, Btn_Right_4 };
            rightLabels = new Label[4] { Label_Right_1, Label_Right_2, Label_Right_3, Label_Right_4 };
            ATMStateCheck();
        }

        /// <summary>
        /// Checks which state the ATM is in and calls the methods controlling the display of ATM components
        /// </summary>
        private void ATMStateCheck()
        {

            if (main.GetState() == MainWindow.state.CustomerSelected)
            {
                CustomerSelected();
            }
            else if (main.GetState() == MainWindow.state.CardInserted)
            {
                CardInserted();
            }
            else if (main.GetState() == MainWindow.state.PinAccepted)
            {
                PINAccepted();
            }
        }

        /// <summary>
        /// Display rules when customer has been selected
        /// </summary>
        private void CustomerSelected()
        {
            Label_MainScreenText.Content = "Please insert Card";
            Card_Intake.IsEnabled = true;
        }

        /// <summary>
        /// Display rules when a card has been inserted
        /// </summary>
        private void CardInserted()
        {
            Label_MainScreenText.Content = "Please type PIN code";
            Keypad.IsEnabled = true;
        }

        /// <summary>
        /// Display rules when the PIN code has been accepted
        /// </summary>
        private void PINAccepted()
        {
            Label_MainScreenText.Content = "How much to withdraw?";
            Label_ScreenText1.Content = "Account: " + main.manager.GetActiveCard().AccountNumber;
            UpdateBalance();
            Btn_Left_3.IsEnabled = true;
            Label_Left_3.Content = "100 kr.";

            Btn_Right_3.IsEnabled = true;
            Label_Right_3.Content = "200 kr.";

            Btn_Left_4.IsEnabled = true;
            Label_Left_4.Content = "500 kr.";

            Btn_Right_4.IsEnabled = true;
            Label_Right_4.Content = "1000 kr.";
        }

        /// <summary>
        /// Updates thelabel showing the balance of the account.
        /// </summary>
        private void UpdateBalance()
        {
            Label_ScreenText2.Content = "Balance: " + main.manager.GetActiveAccount().Balance + " kr.";
        }

        /// <summary>
        /// When keypad button is clicked show the keypad window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Keypad_Click(object sender, RoutedEventArgs e)
        {
            main.ShowKeypad();

        }

        /// <summary>
        /// When card intake is clicked show the card choice window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card_Intake_Click(object sender, RoutedEventArgs e)
        {
            main.ShowCardChoice();
        }

        private void DisplayMoney(double amount)
        {
            Label_Money.Content = amount.ToString() + " kr.";

        }

        /// <summary>
        /// third left side button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Left_3_Click(object sender, RoutedEventArgs e)
        {
            double withdrawen = main.manager.WithdrawMoney(100);
            DisplayMoney(withdrawen);
            UpdateBalance();
        }

        /// <summary>
        /// third right side button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Right_3_Click(object sender, RoutedEventArgs e)
        {
            double withdrawen = main.manager.WithdrawMoney(200);
            DisplayMoney(withdrawen); 
            UpdateBalance();
        }

        /// <summary>
        /// fourth left side button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Left_4_Click(object sender, RoutedEventArgs e)
        {
            double withdrawen = main.manager.WithdrawMoney(500);
            DisplayMoney(withdrawen);
            UpdateBalance();
        }

        /// <summary>
        /// fourth right side button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Right_4_Click(object sender, RoutedEventArgs e)
        {
            double withdrawen = main.manager.WithdrawMoney(1000);
            DisplayMoney(withdrawen);
            UpdateBalance();
        }
    }
}
