using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using ProjectResources.Properties;

namespace ProjectResources.Classes
{
    public sealed class ResourceImages : ImageUtility
    {
        private DataTable _bitMapImagesTable;
        private DataTable _iconImagesTable;

        private static readonly Lazy<ResourceImages> Lazy = 
            new Lazy<ResourceImages>(() => new ResourceImages());

        public static ResourceImages Instance => Lazy.Value;

        public DataTable BitMapDataTable()
        {
            if (_bitMapImagesTable == null)
            {
                GetBitMapImages();
            }

            return _bitMapImagesTable;

        }

        /// <summary>
        /// Container for icon resources
        /// </summary>
        /// <returns></returns>
        public DataTable IconDataTable()
        {
            if (_iconImagesTable == null)
            {
                GetIconImages();
            }

            return _iconImagesTable;

        }
        /// <summary>
        /// This was to answer a forum question, should be in another class for text only resources.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetTextResources()
        {
            
            var resultDictionary = new Dictionary<string,string>();
            var properties = typeof(Resources)
                .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            var stringItems = (from pi in properties
                where pi.PropertyType == typeof(string) select pi).ToList();

            if (stringItems.Count <= 0) return resultDictionary;

            foreach (var propertyInfo in stringItems)
            {
                resultDictionary.Add(propertyInfo.Name, Resources.ResourceManager.GetObject(propertyInfo.Name)?.ToString());
            }

            return resultDictionary;

        }
        /// <summary>
        /// Retrieve images from project resources
        /// </summary>
        /// <remarks></remarks>
        private void GetBitMapImages()
        {
            _bitMapImagesTable = new DataTable();

            _bitMapImagesTable.Columns.AddRange(new[]
                {
                    new DataColumn("Identifier", typeof(int)),
                    new DataColumn("Name", typeof(string)),
                    new DataColumn("Image", typeof(Image))
                });

            _bitMapImagesTable.Columns["Identifier"].AutoIncrement = true;
            _bitMapImagesTable.Columns["Identifier"].AutoIncrementSeed = 1;

            var properties = typeof(Resources)
                .GetProperties(
                    BindingFlags.NonPublic | 
                    BindingFlags.Instance | 
                    BindingFlags.Static);

            var bitMaps = (
                from T in properties
                where T.PropertyType == typeof(Bitmap)
                select T).ToList();

            if (bitMaps.Count <= 0) return;

            foreach (var propertyInfo in bitMaps)
            {                   
                _bitMapImagesTable.Rows.Add(null, 
                    propertyInfo.Name.Replace("_", " "), 
                    Resources.ResourceManager.GetObject(propertyInfo.Name));
            }
        }

        /// <summary>
        /// Get all Icon images from project resources
        /// </summary>
        private void GetIconImages()
        {

            _iconImagesTable = new DataTable();

            _iconImagesTable.Columns.AddRange(new[]
                {
                    new DataColumn("Identifier", typeof(int)),
                    new DataColumn("Name", typeof(string)),
                    new DataColumn("Image", typeof(Icon))
                });

            _iconImagesTable.Columns["Identifier"].AutoIncrement = true;
            _iconImagesTable.Columns["Identifier"].AutoIncrementSeed = 1;

            var properties = typeof(Resources).GetProperties(
                BindingFlags.NonPublic | 
                BindingFlags.Instance | 
                BindingFlags.Static);

            var propertyInfos = (
                from T in properties
                where T.PropertyType == typeof(Icon)
                select T).ToList();

            if (propertyInfos.Count <= 0) return;

            foreach (var propertyInfo in propertyInfos)
            {

                _iconImagesTable.Rows.Add(null, propertyInfo.Name.Replace("_", " "),
                    Resources.ResourceManager.GetObject(propertyInfo.Name));

            }
  
        }

        private ResourceImages()
        {
        }
    }

}
