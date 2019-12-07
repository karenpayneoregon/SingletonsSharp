using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Cached.Classes
{
    /// <summary>
    /// Responsible, using JsonNet to read and write json
    /// from a json file to and from a concrete class
    /// </summary>
    public class FileOperations
    {
        /// <summary>
        /// Read json file into a list which will be passed to
        /// a form to load into a ListView
        /// </summary>
        /// <param name="fileName">File to read json from</param>
        /// <returns></returns>
        public List<Application> LoadApplicationData(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Application>>(json);
            }
        }
    }
}