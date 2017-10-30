using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data
using DataServiceGenerator.UtilClasses;
using DataServiceGenerator.QueryBuilderClasses;
namespace DataServiceGenerator.PersistenceClasses
{
    public class ColumnDefintion
    {
        public string ColumnName;
        public QueryBuilderEncodingType ColumnType;
        public int ColumnSize;

    }
    public class Table:Object,IxmlSerialize
    {
        public bool generateConstructor;
        public bool generateSave;
        public bool generateInsert;
        public string preInsertScript;
        public string postInsertScript;
        public bool generateUpdate;
        public string preUpdateScript;
        public string postUpdateScript;
        public bool generateDelete;
        public string preDeleteScript;
        public string postDeleteScript;
        public bool generateExists;

        public string Name;
        public string DatabaseID;
        public List<ColumnDefintion> Fields;
        public ColumnDefintion PrimaryKey;

        
        public Table()
        {
            Name = "";
            DatabaseID = "";
        }
        public Table(string n, string dbid)
        {
            Name = n;
            DatabaseID = dbid;
        }
        

        #region IxmlSerialize Members

        public XmlNode writeToXml(XmlDocument xmldoc)
        {
          
            XmlNode x = xmldoc.CreateElement("Table");
            x.AppendChild( XmlUtil.ComposeXmlElement(xmldoc, "DatabaseID", DatabaseID));

            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "generateConstructor", XmlUtil.bool2YesNo(generateConstructor)));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "generateDelete", XmlUtil.bool2YesNo( generateDelete)));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "generateInsert", XmlUtil.bool2YesNo( generateInsert)));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "generateUpdate", XmlUtil.bool2YesNo( generateUpdate)));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "generateSave", XmlUtil.bool2YesNo( generateSave)));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "generateExists", XmlUtil.bool2YesNo( generateExists)));

            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "Name", Name));

            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "postDeleteScript", postDeleteScript));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "preDeleteScript", preDeleteScript));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "preInsertScript", preInsertScript));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "postInsertScript", postInsertScript));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "preUpdateScript", preUpdateScript));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc, "postUpdateScript", postUpdateScript));

            return x;
        }

        public bool parseFromXml(XmlNode xnode)
        {
            /*
             * Assumed document:
             * <table>
             *    <DatabaseID>ServerName</DatabaseID>
             *    <generateConstructor>yes</generateConstructor>
             *    <generateDelete>yes</generateDelete>
             *    <generateInsert>yes</generateInsert>
             *    <generateUpdate>yes</generateUpdate>
             *    <generateSave>yes</generateSave>
             *    <generateExists>yes</generateExists>
             *    <Name></Name>
             *    <postDeleteScript><![CDATA[SOMETHING]]></postDeleteScript>
             *    <preDeleteScript><![CDATA[SOMETHING]]></preDeleteScript>
             *    <preInsertScript><![CDATA[SOMETHING]]></preInsertScript>
             *    <postInsertScript><![CDATA[SOMETHING]]></postInsertScript>
             *    <preUpdateScript><![CDATA[SOMETHING]]></preUpdateScript>  
             *    <postUpdateScript><![CDATA[SOMETHING]]></postUpdateScript>
             *</table> 
              */

            // Retrieve the required data from the node.
            try
            {
                foreach (XmlNode n in xnode.ChildNodes)
                {
                    switch (n.Name)
                    {
                        case "DatabaseID": this.DatabaseID = n.Value;
                            break;
                        case "generateConstructor": this.generateConstructor = XmlUtil.YesNo2Bool(n.Value);
                            break;
                        case "generateDelete": this.generateDelete = XmlUtil.YesNo2Bool(n.Value);
                            break;
                        case "generateInsert": this.generateInsert = XmlUtil.YesNo2Bool(n.Value);
                            break;
                        case "generateUpdate": this.generateUpdate = XmlUtil.YesNo2Bool(n.Value);
                            break;
                        case "generateSave": this.generateSave = XmlUtil.YesNo2Bool(n.Value);
                            break;
                        case "generateExists": this.generateExists = XmlUtil.YesNo2Bool(n.Value);
                            break;

                        case "Name": this.Name = n.Value;
                            break;

                        case "postDeleteScript": this.postDeleteScript = n.Value;
                            break;
                        case "preDeleteScript": this.preDeleteScript = n.Value;
                            break;
                        case "preInsertScript": this.preInsertScript = n.Value;
                            break;
                        case "postInsertScript": this.postInsertScript = n.Value;
                            break;
                        case "preUpdateScript": this.preUpdateScript = n.Value;
                            break;
                        case "postUpdateScript": this.preUpdateScript = n.Value;
                            break;
                        default:
                            // Ignore 
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error Parsing Table Element", e);
                return false;
            }
                
            return true;
            
        }

        #endregion
    }
}
