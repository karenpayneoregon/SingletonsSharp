using System;
using System.Windows.Forms;
using PassingInformationBetweenForms.Classes;

namespace PassingInformationBetweenForms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        public Customer Customer { get; set; } 
        public CustomerForm(Customer customer)
        {
            InitializeComponent();

            Customer = customer;

            FirstNameTextBox.Text = Customer.FirstName;
            LastNameTextBox.Text = Customer.LastName;

        }
        /// <summary>
        /// Set properties for our Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                Customer.FirstName = FirstNameTextBox.Text;
                Customer.LastName = LastNameTextBox.Text;

                DialogResult = DialogResult.OK;
            }
        }
    }
}
