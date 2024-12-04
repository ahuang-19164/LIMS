using System.IO;
using System.Xml;

namespace Common.BLL
{
    public class XmlHelper
    {
        public static string GetXmlValue(string nodeName, string valueString)
        {
            System.IO.TextReader textReader = new StringReader(valueString);
            XmlDocument doc = new XmlDocument();
            doc.Load(textReader);
            XmlNode AjaxResult = doc.SelectSingleNode("AjaxResult");
            XmlNode data = AjaxResult.SelectSingleNode("data");
            //XmlNode data = msg.SelectSingleNode("data");
            return data.InnerText;
        }
    }
}
