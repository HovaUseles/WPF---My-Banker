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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KeypadUC keypadUC;
        AtmUC atmUC;
        CustomerChoiceUC customerChoiceUC;
        internal GUI_Manager manager;
        CardChoiceUC cardChoiceUC;

        public enum state
        {
            standby = 10,
            CustomerSelected = 20,
            CardInserted = 30,
            PinAccepted = 40,
            MoneyWithdrawen = 50
        };

        private state currentState;

        public MainWindow()
        {
            manager = new GUI_Manager();
            keypadUC = new KeypadUC(this);
            //atmUC = new AtmUC(this);
            cardChoiceUC = new CardChoiceUC(this); 
            customerChoiceUC = new CustomerChoiceUC(this);
            InitializeComponent();

            currentState = state.standby;
            ShowCustomerSelect();

        }

        /// <summary>
        /// Shows the ATM screen
        /// </summary>
        public void ShowATM()
        {
            this.Content = new AtmUC(this);
        }

        public void ShowCardChoice()
        {
            this.Content = cardChoiceUC;
            cardChoiceUC.PopulateCards();
        }

        public void CloseCardChoice(CreditCard card)
        {
            manager.SetActiveCard(card);
            currentState = state.CardInserted;
            ShowATM();
        }

        /// <summary>
        /// Returns the current state of the ATM.
        /// </summary>
        /// <returns></returns>
        public state GetState()
        {
            return currentState;
        }

        /// <summary>
        /// Shows the customer select screen
        /// </summary>
        public void ShowCustomerSelect()
        {
            this.Content = customerChoiceUC;
        }

        /// <summary>
        /// Closes the customer select screen and returns to atm view
        /// </summary>
        public void CloseCustomerSelect()
        {

            currentState = state.CustomerSelected;
            ShowATM();
        }

        /// <summary>
        /// Shows the keypad screen
        /// </summary>
        public void ShowKeypad()
        {
            if (((int)currentState) < 40)
            {
                this.Content = keypadUC;
            }

        }

        /// <summary>
        /// Closes the keypad screen and returns to atm view
        /// </summary>
        /// <param name="loggedIn"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void CloseKeypad(bool loggedIn)
        {
            if (loggedIn)
            {
                currentState = state.PinAccepted;
                ShowATM();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }
}
