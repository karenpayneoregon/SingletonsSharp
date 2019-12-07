using System;
using System.Windows.Forms;
using PassingInformationBetweenForms.Classes;

namespace PassingInformationBetweenForms
{
    public partial class Form1 : Form
    {
        private Customer _customer = new Customer();
        public Form1()
        {
            InitializeComponent();

            _customer.FirstName = "Mary";
            _customer.LastName = "Adams";

            FirstNameTextBox.Text = _customer.FirstName;
            LastNameTextBox.Text = _customer.LastName;
        }

        private void OpenChildForm_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm(_customer);

            try
            {
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    FirstNameTextBox.Text = customerForm.Customer.FirstName;
                    LastNameTextBox.Text = customerForm.Customer.LastName; ;

                    _customer.FirstName = customerForm.Customer.FirstName;
                    _customer.LastName = customerForm.Customer.LastName;

                }
            }
            finally
            {
                customerForm.Dispose();
            }
        }
    }
}
