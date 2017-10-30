using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DataServiceGenerator.UtilClasses
{
    
    public class XmlUtil
    {
        //

        /// <summary>
        /// Creates a named, valued xml node for easy appending
        /// </summary>
        /// <param name="name">Name of Tag</param>
        /// <param name="value">Value of Tag</param>
        /// <returns>XmlNode ready to append</returns>
        public static XmlElement ComposeXmlElement(XmlDocument xdoc, string name, string value)
        {
            XmlElement retval = xdoc.CreateElement(name);
            
            retval.InnerText = value;
            return retval;
        }
        // 
        /// <summary>
        /// Creates a named, valued xml node with a single attribute (valued) 
        /// </summary>
        /// <param name="name">Name of tag </param>
        /// <param name="value">Value of tag</param>
        /// <param name="Attribute">First attribute of the element</param>
        /// <param name="AtributeValue">Value of first attribute</param>
        /// <returns>XmlNode ready to append</returns>
        public static XmlElement ComposeXmlElement(XmlDocument xmldoc, string name, string value, string Attribute, string AtributeValue)
        {
            XmlElement retval = xmldoc.CreateElement(name);
            
            retval.Value = value;
            XmlAttribute xattr = xmldoc.CreateAttribute(Attribute);
            
            xattr.Value=AtributeValue;
            retval.Attributes.Append(xattr);
            return retval;
        }
        public static bool YesNo2Bool(string YesNo)
        {
            return (YesNo.ToUpper().Substring(1, 1) == "Y") ? true : false;
        }
        public static string bool2YesNo(bool val)
        {
            return (val) ? "yes" : "no";
        }
        public XmlCDataSection Text2Cdata(XmlDocument x, string s)
        {
           return x.CreateCDataSection(s);
        }
        public string Cdata2Text(XmlDocument x, XmlNode n)
        {
            //return n.SelectNodes("text()");
            return "";
        }

        
    }
}
