using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Example.Helper
{
    public static class SerializToFile
    {
        public static string Serializ<T>(T obj, string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream;

            string message = "successful";
            if (obj == null) return "Given object is null";
            try
            {
                stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, obj);
                stream.Close();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }

        public static T DeSerializ<T>(string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream;
            T objectOut = default(T);
            try
            {
                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                objectOut = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception)
            {
                //Error
            }
            return objectOut;
        }
    }
}
