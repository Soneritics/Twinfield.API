using System.Xml;

namespace Api.Extensions
{
    /// <summary>
    /// Extensions for working with XML.
    /// </summary>
    internal static class XmlExtensions
    {
        /// <summary>
        /// Converts a string to an XmlNode.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns></returns>
        public static XmlNode ToXmlNode(this string contents)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(contents);
            return xmlDoc;
        }
    }
}
