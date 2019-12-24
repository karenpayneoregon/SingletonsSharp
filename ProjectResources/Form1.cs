using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ProjectResources.Classes;

namespace ProjectResources
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Shown += Form1_Shown;
            iconImageListBox.SelectedIndexChanged += 
                IconImageListBox_SelectedIndexChanged;
           
        }
        /// <summary>
        /// Present current icon in ListBox as the
        /// Form Icon based on which class was used,
        /// either ResourceImages or ProjectClassResources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconImageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentImageName = iconImageListBox.SelectedItem is DataRowView view ? 
                view.Row.Field<string>("Name") : 
                ((IconItem) iconImageListBox.SelectedItem).Name;

            Icon = ResourceImages.Instance.GetImageByName(currentImageName);
        }

        /// <summary>
        /// Get images from project resources either by DataTable objects
        /// or class list objects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            var results = ResourceImages.Instance.GetTextResources();
            foreach (var entry in results)
            {
                Console.WriteLine(entry.Key);
                Console.WriteLine(entry.Value);
                Console.WriteLine();
            }



            //var icons = ProjectClassResources.Instance.IconDataTable(); 
            var icons =  ResourceImages.Instance.IconDataTable();

            //var bitmaps = ProjectClassResources.Instance.BitMapList();
            var bitmaps =  ResourceImages.Instance.BitMapDataTable();

            iconImageListBox.DataSource = icons;
            iconImageListBox.DisplayMember = "name";

            iconPictureBox1.DataBindings.Add("image", icons, "Image");
            IconIdentifierLabel.DataBindings.Add("text", icons, "Identifier");

            bitMapListBox.DataSource = bitmaps;
            bitMapListBox.DisplayMember = "name";

            bitMapPictureBox1.DataBindings.Add("image", bitmaps, "Image");
            Identifier.DataBindings.Add("text", bitmaps, "Identifier");

        }
    }
}
