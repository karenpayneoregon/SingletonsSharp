using System;
using System.Windows.Forms;
using Cached.Classes;

namespace Cached
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            Shown += CustomerForm_Shown;
        }
        /// <summary>
        /// Get current property values for our Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerForm_Shown(object sender, EventArgs e)
        {

            FirstNameTextBox.Text = CachedInformation.Instance.Customer.FirstName;
            LastNameTextBox.Text = CachedInformation.Instance.Customer.LastName;

        }
        /// <summary>
        /// Set properties for our Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetButton_Click(object sender, EventArgs e)
        {

            CachedInformation.Instance.Customer
                .FirstName = FirstNameTextBox.Text;

            CachedInformation.Instance.Customer
                .LastName = LastNameTextBox.Text;

            Close();
        }
    }
}
