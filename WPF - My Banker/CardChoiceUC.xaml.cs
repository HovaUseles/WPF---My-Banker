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
    /// Interaction logic for CardChoiceUC.xaml
    /// </summary>
    public partial class CardChoiceUC : UserControl
    {
        MainWindow main;
        public CardChoiceUC(MainWindow mainWindow)
        {
            InitializeComponent();

            main = mainWindow;
        }

        /// <summary>
        /// Gets and displays credit cards to the card select view
        /// </summary>
        public void PopulateCards()
        {
            List<CreditCard> cards = main.manager.GetActicveCustomer().Cards;
            if (cards.Count > 0)
            {
                int i = 0;
                foreach (CreditCard card in cards)
                {
                    CardUC cardUC = CreateCardUC(card);
                    cardGrid.Children.Add(cardUC);
                    Grid.SetColumn(cardUC, 1);
                    Grid.SetRow(cardUC, 1 + (i * 2));
                    Grid.SetColumnSpan(cardUC, 5);
                    i++;
                }
            }
        }

        /// <summary>
        /// Builds the credit cards user control for the card select view
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private CardUC CreateCardUC(CreditCard card)
        {
            CardUC cardUC = new CardUC(card, main);
            string accNumber = card.AccountNumber.Substring(4);
            string regNumber = card.AccountNumber.Substring(0, 4);
            cardUC.label_accountNumber.Content = "Acc: " + accNumber;
            cardUC.label_regNumber.Content = "Reg: " + regNumber;

            cardUC.label_Cardtype.Content = card.CardType;

            cardUC.label_expireDate.Content = "";
            cardUC.label_CardNumber1.Content = card.CardNumber.Substring(0, 4);
            cardUC.label_CardNumber2.Content = card.CardNumber.Substring(4, 4);
            cardUC.label_CardNumber3.Content = card.CardNumber.Substring(8, 4);
            cardUC.label_CardNumber4.Content = card.CardNumber.Substring(12);

            return cardUC;
        }
    }
}
