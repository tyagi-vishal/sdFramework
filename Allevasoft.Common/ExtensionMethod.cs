using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Allevasoft.Common
{
    public static class ExtensionMethod
    {  
            public static string UpperCaseFirstLatter(this string value)
            {
                if (value.Length > 0)
                {
                    value = value.ToLower();
                    char[] array = value.Trim().ToCharArray();
                    array[0] = char.ToUpper(array[0]);
                    return new string(array);
                }
                return value;
            }
            public static string LowerCaseFirstLatter(this string value)
            {
                if (value.Length > 0)
                {
                    value = value.ToUpper();
                    char[] array = value.Trim().ToCharArray();
                    array[0] = char.ToLower(array[0]);
                    return new string(array);
                }
                return value;
            }


        /// <summary>
        /// Convert obj into model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Model Object</param>
        /// <returns></returns>
        public static string ConvertToXml<T>(T obj)
        {
            MemoryStream stream = null;
            TextWriter writer = null;
            try
            {
                stream = new MemoryStream(); // read xml in memory
                writer = new StreamWriter(stream, Encoding.Unicode);
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj); // read object
                var count = (int)stream.Length; // saves object in memory stream
                var arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                // copy stream contents in byte array
                stream.Read(arr, 0, count);
                var utf = new UnicodeEncoding(); // convert byte array to string
                //return ReplaceFirstOccurrance(utf.GetString(arr).Trim(), "utf-16", "utf-8");
                return utf.GetString(arr).Trim().Remove(0, 40);
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                if (stream != null) stream.Close();
                if (writer != null) writer.Close();
            }
        }
    }
}
