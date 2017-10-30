using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataServiceGenerator.AccessClasses
{
    public enum DataSourceType
    {
        none = 0, MsSql = 1, MsAccess = 2, MySql=3
    }
    interface IDataSourcePlugin
    {
        string GetPrimaryKey(string TableName);
        //returns TRUE if connection works
        /// <summary>
        /// Tests and Opens the Database Connection. 
        /// If the Connectionstring needs to be cached, do it here.
        /// Provides an affirmative test of connectedness.
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <returns></returns>
         bool TestConnection(string connectionstring);
        /// <summary>
        /// Will return a list of all tables available through the 
        /// previously specified connection, with the name in the zeroth colum; 
        /// </summary>
        /// <returns></returns>
         DataTable GetTableList();

        /// <summary>
        /// Given a table name , will provide a table with a single record 
        /// in which the structure of the database will be available. If 
        /// possible, no actual data should be returned from the observed 
        /// Table.
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
         DataTable GetTable(string TableName);
        /// <summary>
        /// Returns a list of the fields available in a given view in the 
        /// form of a single record within a DataTable. In no way
        /// should this actually run a query that may alter data.
        /// </summary>
        /// <param name="ViewName"> Name of the view to retrieve</param>
        /// <returns></returns>
         DataTable GetView(string ViewName);
        /// <summary>
        /// Gets a list of the Views (or queries) available in a given view
        /// </summary>
        /// <returns></returns>
         DataTable GetViews();
        /// <summary>
        /// Perform cleanup, disconnection, object disposal here
        /// </summary>
         void Dispose();
    }
}
