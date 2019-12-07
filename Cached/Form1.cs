using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cached.Classes;
using Application = Cached.Classes.Application;

namespace Cached
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
            Console.WriteLine(Directory.Exists(CachedInformation.Instance.ConfigurationFolder));

            dataGridView1.DataSource = CachedInformation.Instance.Applications;
        }
        /// <summary>
        /// Set a breakpoint on the constructor in CachedInformation and note
        /// it will not be called as the data is loaded for the json data once.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetCachedApplicationsButton_Click(object sender, EventArgs e)
        {

            List<Application> test = CachedInformation.Instance.Applications;

            Console.WriteLine(
                "Set breakpoint here and also in CachedInformation constructor");
        }

        /// <summary>
        /// Demonstrate passing a Customers data between two
        /// forms. Note there is no validation here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessButton_Click(object sender, EventArgs e)
        {
            /*
             * Set properties as they have no values the first time
             */
            CachedInformation.Instance.Customer.FirstName = FirstNameTextBox.Text;
            CachedInformation.Instance.Customer.LastName = LastNameTextBox.Text;

            var customerForm = new CustomerForm();

            try
            {
                customerForm.ShowDialog();

                /*
                 * Get property values
                 */
                FirstNameTextBox.Text = CachedInformation.Instance.Customer.FirstName;
                LastNameTextBox.Text = CachedInformation.Instance.Customer.LastName;

            }
            finally
            {
                customerForm.Dispose();
            }
        }
    }
}

