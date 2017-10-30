using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DataServiceGenerator.UtilClasses;
using DataServiceGenerator.AccessClasses;

namespace DataServiceGenerator.PersistenceClasses
{
     public class DataBaseServer:Object,IxmlSerialize
    {
        private string nickName="";
        private string connectString="";
        private DataSourceType type=DataSourceType.none; 
        public DataBaseServer()
        {
            
        }
        public DataBaseServer(string n, string cs, DataSourceType dt)
        {
             nickName = n;
             connectString = cs;
             type = dt;
        }
        public DataBaseServer(XmlReader r)
        {
            parseFromXml(r);
        }
        public string Nickname { 
            get
             { return nickName; } 
            set
             { nickName = value;} 
        }
        public string ConnectString
        {
            get
            { return connectString; }
            set
            { connectString = value;}
        } 
        public DataSourceType Type { 
            get 
            {
                return this.type;
            }
            private set
            {
                type = value;
            }

        }
       


        #region IxmlSerialize Members

        public System.Xml.XmlNode writeToXml(System.Xml.XmlDocument xmldoc)
        {
            XmlNode x = xmldoc.CreateElement("Database");
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc,"Nickname",Nickname));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc,"ConnectString",this.ConnectString));
            x.AppendChild(XmlUtil.ComposeXmlElement(xmldoc,"Type",this.Type.ToString()));
            return x;
        }

        public bool parseFromXml(XmlReader xReader)
        {
            try
            {
                xReader.ReadToDescendant("Nickname");
                Nickname = xReader.ReadContentAsString();
                xReader.ReadToDescendant("ConnectString");
                ConnectString  = xReader.ReadContentAsString();
                xReader.ReadToDescendant("Type");
                switch (xReader.ReadContentAsString())
                {
                    case "none":
                         this.type = DataSourceType.none;
                        break;
                    case "MsSql":
                        this.type = DataSourceType.MsSql;
                        break;
                    case "MsAccess":
                        this.type = DataSourceType.MsAccess;
                        break;
                    case "MySql":
                        this.type = DataSourceType.MySql;
                        break;
                    default:
                        this.type=DataSourceType.none;
                        break;
                    
                }
            }catch(Exception e )
            {
                throw new Exception("Error Parsing DatabaseServer Object", e);
                return false;
            }
            return true;
        }

        #endregion
    }
}
