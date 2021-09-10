using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpTools
{
    public class BinaryFormatTool
    {
        public static byte[] Serialize<T>(T obj)
        {
            if (obj == null) return null;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, obj);
            byte[] bytes = memoryStream.GetBuffer();
            memoryStream.Close();
            return bytes;
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            object obj = null;
            if (bytes != null)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream(bytes);
                obj = binaryFormatter.Deserialize(memoryStream);
                memoryStream.Close();
            }
            return (T)obj;
        }
    }
}
