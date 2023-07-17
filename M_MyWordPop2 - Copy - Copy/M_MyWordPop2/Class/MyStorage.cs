using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace M_MyWordPop2
{
    public class MyStorage
    {
        public static async Task<T> GetEmbeddedXML<T>(string file)
        {
            try
            {
                using Stream stream = await FileSystem.OpenAppPackageFileAsync(file);
                using (TextReader reader = new StreamReader(stream))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(reader);
                }
            }

            catch (Exception)
            {
                return default(T);
            }
        }

        public static async Task<string> ReadEmbeddedFile(string file)
        {
            using Stream stream = await FileSystem.Current.OpenAppPackageFileAsync(file);
            if (stream == null)
                return default(string);

            var data = (new System.IO.StreamReader(stream)).ReadToEnd();
            return (string)data;

        }
    }
}
