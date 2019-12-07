using System.Drawing;
using System.Reflection;

namespace ProjectResources.Classes
{
    public class ImageUtility
    {
        /// <summary>
        /// Get Icon by string name, if name does not exists
        /// a runtime error is thrown
        /// </summary>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public Icon GetImageByName(string imageName)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resourceName = $"{asm.GetName().Name}.Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            return (Icon)rm.GetObject(imageName);
        }

    }
}
