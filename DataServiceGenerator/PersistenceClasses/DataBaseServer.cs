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

        public bool parseFromXml(System.Xml.XmlNode xnode)
        {
            try
            {
                foreach (XmlNode x in xnode)
                {
                    switch (x.Name)
                    {
                        case "Nickname":
                            Nickname = x.Value;
                            break;
                        case "ConnectString":
                            ConnectString = x.Value;
                            break;
                        case "Type":
                            switch (x.Value)
                            {
                                case "0":
                                    this.Type = DataSourceType.none;
                                    break;
                                case "1":
                                    this.Type = DataSourceType.MsAccess;
                                    break;
                                case "2":
                                    this.Type = DataSourceType.MsSql;
                                    break;
                                default:
                                    this.Type = DataSourceType.none;
                                    break;
                            }
                            break;
                        default:
                                // ignore
                            break;
                    }
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
