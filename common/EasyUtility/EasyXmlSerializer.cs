using System;
using System.IO;
using System.Xml.Serialization;

namespace EasyCommon
{
    public class EasyXmlSerializer
    {
        public string FilePath;
        public FileStream fs;
        public EasyXmlSerializer()
        {
        }
        public EasyXmlSerializer(string filePath)
        {
            FilePath = filePath;
             fs = new FileStream(FilePath, FileMode.Open);
        }
        public void Serialize(object obj)
        {
            XmlSerializer xsl = new XmlSerializer(obj.GetType());
            xsl.Serialize(fs, obj);
            fs.Close();
        }

        public object DeSerialize(object obj)
        {
            XmlSerializer xsl = new XmlSerializer(obj.GetType());
            obj= xsl.Deserialize(fs);
            fs.Close();
            return obj;
        }
    }
}
