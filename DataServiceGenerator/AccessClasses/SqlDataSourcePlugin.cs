using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataServiceGenerator.AccessClasses
{
    class SqlDataSourcePlugin:Object,IDataSourcePlugin
    {
        SqlConnection oDbConn;
        const string STRING_GET_TABLES = "SELECT name FROM dbo.sysobjects WHERE xtype = 'U' ";
        const string STRING_GET_TABLE_ID = "SELECT id FROM dbo.sysobjects WHERE xtype = 'U' AND name='{0}'";
        const string STRING_GET_TABLES_SQLEXPRESS = "Select * from Sys.tables";
        const string STRING_GET_FIELDS = "SELECT name, type_name(xtype),length from syscolumns where id = object_id('{0}') order by colid";

        const string STRING_GET_PRIMARYKEY = "SELECT sys.syscolumns.name FROM sys.syscolumns INNER JOIN sys.sysindexkeys ON sys.syscolumns.colid = sys.sysindexkeys.colid AND sys.syscolumns.id = sys.sysindexkeys.id WHERE (sys.syscolumns.id = OBJECT_ID('{0}'))";
        
        private void Open(string connectionstring)
        {
            // note : don't 'catch' here. Let the process above catch
            if (oDbConn!=null)
                {
                    oDbConn.Dispose();
                    oDbConn = null;
                }
                oDbConn = new SqlConnection(connectionstring);
                oDbConn.Open();
        }
        private void Close()
        {
            oDbConn.Dispose();
        }

        #region IDataSourcePlugin Members
        string IDataSourcePlugin.GetPrimaryKey(string tablename)
        {
            string s="";
          
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(String.Format(STRING_GET_PRIMARYKEY,tablename), oDbConn);
            Da.Fill(Dt);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                s = s+ (Dt.Rows[i][0].ToString() + ", ") ; 
            }
            if (s.Length>2)s= s.Substring(0, s.Length - 2);
            return s;
           
        }
        bool IDataSourcePlugin.TestConnection(string connectionstring)
        {
            try
            {
                this.Open(connectionstring);
            }
            catch (Exception ex)
            {
                
                return false;
            }
            return true;
        }

        System.Data.DataTable IDataSourcePlugin.GetTableList()
        {
            if (oDbConn==null)
            {
                throw new Exception("DataBaseConnection Unopened");
            }
            else
            {
                DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter(STRING_GET_TABLES_SQLEXPRESS, oDbConn);
                Da.Fill(Dt);
                return Dt;
            }
        }

        System.Data.DataTable IDataSourcePlugin.GetTable(string TableName)
        {

            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(STRING_GET_FIELDS.Replace("{0}", TableName),oDbConn);            
            Da.Fill(Dt);
            return Dt;
        }
       
        System.Data.DataTable IDataSourcePlugin.GetView(string ViewName)
        {
            throw new NotImplementedException();
        }

        System.Data.DataTable IDataSourcePlugin.GetViews()
        {
            throw new NotImplementedException();
        }
        void IDataSourcePlugin.Dispose(){}
        #endregion
    }
}