using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF___My_Banker
{
    internal class GUI_Manager
    {
        private BankController bankController;

        private Customer activeCustomer;

        private CreditCard activeCard;

        public GUI_Manager()
        {
            bankController = new BankController("3520");
        }


        /// <summary>
        /// Returns the active customer
        /// </summary>
        /// <returns>The active customer instance</returns>
        public Customer GetActicveCustomer()
        {
            if (activeCustomer != null)
            {
                return activeCustomer;

            }
            throw new Exception("No active customer.");
        }

        /// <summary>
        /// Sets the current active customer
        /// </summary>
        /// <param name="customer">The customer the user chose</param>
        public void SetActiveCustomer(Customer customer)
        {
            activeCustomer = customer;
        }

        /// <summary>
        /// Returns active chosen credit card if any
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CreditCard GetActiveCard()
        {
            if (activeCard != null)
            {
                return activeCard;

            }
            throw new Exception("No active credit card.");
        }

        /// <summary>
        /// Sets the active cards
        /// </summary>
        /// <param name="card"></param>
        public void SetActiveCard(CreditCard card)
        {
            activeCard = card;
        }

        public Account GetActiveAccount()
        {
            CreditCard card = GetActiveCard();

            Account acc = bankController.GetAccountWithCard(card, activeCustomer);
            return acc;
        }

        public double WithdrawMoney(double amount)
        {
            return bankController.WithdrawWithCard(GetActiveCard(), amount, activeCustomer);
        } 

        /// <summary>
        /// Creates a new customer, with a random name accounts and credit cards and returns it.
        /// </summary>
        /// <returns>An instance of the Customer class</returns>
        public Customer GetCustomer()
        {
            return bankController.CreateCustomer();
        }

        /// <summary>
        /// Validates the customers PIN code
        /// </summary>
        /// <returns>True if the code is right</returns>
        /// <param name="code">The code to test</param>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidatePINCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
