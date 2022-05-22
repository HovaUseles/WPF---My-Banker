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
            else if (main.GetState() == MainWindow.state.MoneyWithdrawen)
            {

            }
        }

        private void CustomerSelected()
        {
            Label_MainScreenText.Content = "Please insert Card";
            Card_Intake.IsEnabled = true;
        }

        private void CardInserted()
        {
            Label_MainScreenText.Content = "Please type PIN code";
            Keypad.IsEnabled = true;
        }

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

        private void UpdateBalance()
        {
            Label_ScreenText2.Content = "Balance: " + main.manager.GetActiveAccount().Balance + " kr.";
        }

        private void Keypad_Click(object sender, RoutedEventArgs e)
        {
            main.ShowKeypad();

        }

        private void Card_Intake_Click(object sender, RoutedEventArgs e)
        {
            main.ShowCardChoice();
        }


        private void Btn_Left_3_Click(object sender, RoutedEventArgs e)
        {
            double withdrawen = main.manager.WithdrawMoney(100);
            Label_Money.Content = withdrawen.ToString();
            UpdateBalance();
        }

        private void Btn_Right_3_Click(object sender, RoutedEventArgs e)
        {
            double withdrawen = main.manager.WithdrawMoney(200);
            Label_Money.Content = withdrawen.ToString();
            UpdateBalance();
        }
        private void Btn_Left_4_Click(object sender, RoutedEventArgs e)
        {
            double withdrawen = main.manager.WithdrawMoney(500);
            Label_Money.Content = withdrawen.ToString();
            UpdateBalance();
        }

        private void Btn_Right_4_Click(object sender, RoutedEventArgs e)
        {
            double withdrawen = main.manager.WithdrawMoney(1000);
            Label_Money.Content = withdrawen.ToString();
            UpdateBalance();
        }
    }
}
