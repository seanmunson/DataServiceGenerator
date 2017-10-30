using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace DataServiceGenerator.PersistenceClasses
{
     class GenerationSettings:Object,IxmlSerialize
    {
       

        public GenerationSettings()
        {
               
        }


        #region xmlSerialize Members

        System.Xml.XmlNode IxmlSerialize.writeToXml(System.Xml.XmlDocument xmldoc)
        {
            throw new NotImplementedException();
        }

        bool IxmlSerialize.parseFromXml(System.Xml.XmlReader r)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
