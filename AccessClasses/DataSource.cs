using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataServiceGenerator.UtilClasses;
namespace DataServiceGenerator.AccessClasses
{
   

    /// <summary>
    /// Provides consistent programmatic interface to one of multiple 
    /// types of database, using the DataSourcePlugIn Component to manage
    /// any specialized code. 
    /// </summary>
    class DataSource
    {

        private IDataSourcePlugin DSP = null;


        public DataSource() 
        { 
        }
        public DataSource( DataSourceType t)
        {
            switch (t)
            {
                case DataSourceType.MsAccess:
                    DSP = new AccessClasses.AccessDataSourcePlugin();
                    break;
                case DataSourceType.MsSql:
                    DSP = new AccessClasses.SqlDataSourcePlugin();
                    break;
                case DataSourceType.MySql:
                    DSP = new AccessClasses.MySqlDataSourcePlugin();
                    break;
            }
        }
        public bool TestConnection(string connectionstring)
        {
            return DSP.TestConnection(connectionstring);
            //returns TRUE if connection works
        }
        public DataTable GetTableList()
        {
            return DSP.GetTableList();
        }
        public string GetPrimaryKey(string Tablename)
        {
            string s = DSP.GetPrimaryKey(Tablename);
            return s;
        }
        public DataTable GetTable(string Tablename)
        {
            DataTable dt = DSP.GetTable( Tablename);
            return dt;
        }
        public DataTable GetView(string Viewname)
        {
            return DSP.GetView(Viewname);
        }
        public DataTable GetViews()
        {
            return DSP.GetViews();
        }
    }
   
}
