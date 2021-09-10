using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CSharpTools
{
    class FileIO
    {
        public static void Write<T>(string filename, T[] fileKeys)
        {
            using StreamWriter sw = new StreamWriter(filename);
            foreach (var fileKey in fileKeys)
            {
                string jsonData = JsonConvert.SerializeObject(fileKey);
                sw.WriteLine(jsonData);
            }
        }
        public static T[] Read<T>(string filename)
        {
            List<T> fileKeys = new List<T>();

            string line = "";
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    T fileKey = JsonConvert.DeserializeObject<T>(line);
                    fileKeys.Add(fileKey);
                }
            }

            return fileKeys.ToArray();
        }
    }
}