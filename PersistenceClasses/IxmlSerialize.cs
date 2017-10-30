using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DataServiceGenerator.PersistenceClasses
{
    /// <summary>
    /// This interface defines how an object inthe problem should 
    /// produce an xml 'document' from its contents. 
    /// This means that the entity must present a single root node
    /// with its properties within. It should know how to 
    /// compose this node and its children and how to decompose it.
    /// </summary>
    interface IxmlSerialize
    {
        /// <summary>
        /// composes the class and its properties into 
        /// an xml representation of the class
        /// </summary>
        /// <returns>A Node representing the object</returns>
         XmlNode writeToXml(XmlDocument xmldoc);

        /// <summary>
        /// fills out the properties of an object given an xml node
        /// created by an object of similar class.
        /// </summary>
        /// <param name="xnode">An Xml node representing the given object</param>
        /// <returns>returns true if parse succeeds</returns>
         bool parseFromXml(XmlReader xmldoc);
    }
}
