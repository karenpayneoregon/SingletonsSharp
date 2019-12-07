using System;
using System.Windows.Forms;
using ApplicationDataConnectorRecommended.Classes;


namespace ApplicationDataConnectorRecommended
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Use AppSettings section of app.config for connection string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectUsingAppSettingButton_Click(object sender, EventArgs e)
        {
            var ops = new DataOperations();

            ops.ConnectionUsingAppSettings();

            if (ops.IsSuccessFul)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show($"{ops.LastExceptionMessage}");
            }
        }
        /// <summary>
        /// Use Project.Default setting for connection string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionStringFromProjectSettingsButton_Click(object sender, EventArgs e)
        {
            var ops = new DataOperations();

            ops.ConnectionUsingProjectSetting();

            if (ops.IsSuccessFul)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show($"{ops.LastExceptionMessage}");
            }
        }
    }
}
