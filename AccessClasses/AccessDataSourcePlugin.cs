using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;


namespace DataServiceGenerator.AccessClasses
{
    class AccessDataSourcePlugin:Object,IDataSourcePlugin
    {
        System.Data.OleDb.OleDbConnection oDbConn;
        //SqlConnection oDbConn;

        const string STRING_GET_TABLES = "SELECT name from MSysObjects where (type in (1,4,6))   AND (Left([Name],4) <> \"MSys\") ";
        const string STRING_GET_FIELDS = "SELECT top 1 * from {0}";
   
        private void Open(string connectionstring)
        {
            // note : don't 'catch' here. Let the process above catch
            if (oDbConn != null)
            {
                oDbConn.Dispose();
                oDbConn = null;
            }
            oDbConn = new OleDbConnection(connectionstring);
            oDbConn.Open();
        }
        private void Close()
        {
            oDbConn.Dispose();
        }

        #region IDataSourcePlugin Members

        string IDataSourcePlugin.GetPrimaryKey(string TableName)
        {
            if (oDbConn == null)
            {
                throw new Exception("DataBaseConnection Unopened");
            }
            else
            {
                DataTable Dt = oDbConn.GetSchema("Indexes", new string[] { null, null, "PrimaryKey" });
             
                string s = "";
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (Dt.Rows[i][2].ToString()==TableName)
                    s = s + (Dt.Rows[i][17].ToString() + ", ");
                }
                if (s.Length > 2) s = s.Substring(0, s.Length - 2);
                return s;
            }
            
        }

        bool IDataSourcePlugin.TestConnection(string connectionstring)
        {
            try { this.Open(connectionstring); }
            catch (Exception ex) { return false; }
            return true;
        }

        System.Data.DataTable IDataSourcePlugin.GetTableList()
        {
            if (oDbConn == null)
            {
                throw new Exception("DataBaseConnection Unopened");
            }
            else
            {
                DataTable Dt;
                DataTable ReturnTable= new DataTable();
                ReturnTable.Columns.Add("TableName");
                Dt = oDbConn.GetSchema("tables");
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (!Dt.Rows[i][2].ToString().StartsWith("MSys"))
                        if (Dt.Rows[i][3].ToString()=="TABLE")
                            ReturnTable.Rows.Add(Dt.Rows[i][2]);
                }
                return ReturnTable;
            }
        }

        System.Data.DataTable IDataSourcePlugin.GetTable(string TableName)
        {
            if (oDbConn == null)
            {
                throw new Exception("DataBaseConnection Unopened");
            }
            else
            {
              
                string s = string.Format(STRING_GET_FIELDS, TableName);
                DataTable returnedTable = new DataTable();
                returnedTable.Columns.Add("Name");
                returnedTable.Columns.Add("Type");
                returnedTable.Columns.Add("Size");

                DataTable Dt = new DataTable();
                OleDbDataAdapter Da = new OleDbDataAdapter(s, oDbConn);
                Da.Fill(Dt);
                for (int i = 0; i < Dt.Columns.Count;i++ )
                {

                    DataColumn dc = Dt.Columns[i];
                    DataRow dr = returnedTable.Rows.Add(dc.ColumnName, dc.DataType, 0);
                }
                return returnedTable;
            }
        }

        System.Data.DataTable IDataSourcePlugin.GetView(string ViewName)
        {
            throw new NotImplementedException();
        }

        System.Data.DataTable IDataSourcePlugin.GetViews()
        {
            throw new NotImplementedException();
        }

        void IDataSourcePlugin.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
