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
    /// Interaction logic for CustomerChoiceUC.xaml
    /// </summary>
    public partial class CustomerChoiceUC : UserControl
    {
        Label[] nameAgeLabels;
        Label[] accountCardslabels;
        Button[] btns;
        MainWindow main;
        Customer[] customers;
        public CustomerChoiceUC(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
            nameAgeLabels = new Label[6] {Label_NaAg_1, Label_NaAg_2, Label_NaAg_3, Label_NaAg_4, Label_NaAg_5, Label_NaAg_6};
            accountCardslabels = new Label[6] { Label_AcCa_1, Label_AcCa_2, Label_AcCa_3, Label_AcCa_4, Label_AcCa_5, Label_AcCa_6};
            btns = new Button[6] {Btn_1, Btn_2, Btn_3, Btn_4, Btn_5, Btn_6};
            customers = new Customer[6];

            PopulateCustomers();
        }

        /// <summary>
        /// 
        /// </summary>
        public void PopulateCustomers()
        {
            for (int i = 0; i < 6; i++)
            {
                Customer customer = main.manager.GetCustomer();
                customers[i] = customer;
                DisplayCustomer(customer, nameAgeLabels[i], accountCardslabels[i]);
            }
        }

        /// <summary>
        /// Choose a specific customer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseCustomer(object sender, RoutedEventArgs e)
        {
            Button clickedBtn = sender as Button;
            string btnNum = clickedBtn.Name.Substring(clickedBtn.Name.Length - 1, 1);
            int btnIndex = Convert.ToInt16(btnNum) - 1;
            Customer chosenCustomer = customers[btnIndex];
            main.manager.SetActiveCustomer(chosenCustomer);
            main.CloseCustomerSelect();
        }

        /// <summary>
        /// Displays customer instance in labels
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="nameAgeLabel"></param>
        /// <param name="accCardLabel"></param>
        private void DisplayCustomer(Customer customer, Label nameAgeLabel, Label accCardLabel)
        {
            nameAgeLabel.Content = $"{customer.GetFullName()}, {customer.Age}";
            accCardLabel.Content = $"Accounts: {customer.Accounts.Count}, Cards: {customer.Cards.Count}";
        }
    }
}
