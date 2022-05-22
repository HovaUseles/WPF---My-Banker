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
    /// Interaction logic for CardUC.xaml
    /// </summary>
    public partial class CardUC : UserControl
    {
        private CreditCard card;
        private MainWindow main;

        public CardUC(CreditCard card, MainWindow mainWindow)
        {
            InitializeComponent();
            this.card = card;
            main = mainWindow;
        }

        /// <summary>
        /// When card is clicked close the card select view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChooseCard_Click(object sender, RoutedEventArgs e)
        {
            main.CloseCardChoice(card);
        }
    }
}
