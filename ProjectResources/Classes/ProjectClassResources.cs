using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using ProjectResources.Properties;

namespace ProjectResources.Classes
{
    public sealed class ProjectClassResources : ImageUtility
    {
        private static readonly Lazy<ProjectClassResources> Lazy =
            new Lazy<ProjectClassResources>(() => new ProjectClassResources());

        public static ProjectClassResources Instance => Lazy.Value;

        private List<IconItem> _iconImagesList;
        public List<IconItem> IconDataTable()
        {
            if (_iconImagesList == null)
            {
                GetIconImages();
            }

            return _iconImagesList;

        }

        private void GetIconImages()
        {
            _iconImagesList = new List<IconItem>();

            var properties = typeof(Resources).GetProperties(
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            var propertyInfos = (
                from T in properties
                where T.PropertyType == typeof(Icon)
                select T).ToList();

            if (propertyInfos.Count <= 0) return;

            var index = 1;
            foreach (var propertyInfo in propertyInfos)
            {
                _iconImagesList.Add(new IconItem()
                {
                    Identifier = index,
                    Name = propertyInfo.Name.Replace("_", " "),
                    Image = (Icon)Resources.ResourceManager.GetObject(propertyInfo.Name)
                });

                index += 1;
            }

        }



        private List<BitMapItem> _bitMapImagesList;
        private void GetBitMapImages()
        {
            _bitMapImagesList = new List<BitMapItem>();

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

            var index = 1;
            foreach (var propertyInfo in bitMaps)
            {
                _bitMapImagesList.Add(new BitMapItem()
                {
                    Identifier = index,
                    Name = propertyInfo.Name.Replace("_", " "),
                    Image = (Image)Resources.ResourceManager.GetObject(propertyInfo.Name)
                });

                index += 1;
            }

        }

        public List<BitMapItem> BitMapList()
        {
            if (_bitMapImagesList == null)
            {
                GetBitMapImages();
            }

            return _bitMapImagesList;
        }
        public ProjectClassResources()
        {
            
        }
    }
}
