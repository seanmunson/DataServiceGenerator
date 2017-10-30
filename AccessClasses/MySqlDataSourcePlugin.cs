using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataServiceGenerator.AccessClasses
{
    class MySqlDataSourcePlugin:Object,IDataSourcePlugin
    {
        
            MySqlConnection oDbConn;
            private string schema="";

            const string STRING_GET_TABLES = "SELECT TABLE_NAME FROM information_schema.tables where table_schema='{0}'";
            //const string STRING_GET_TABLE_ID = "SELECT id FROM dbo.sysobjects WHERE xtype = 'U' AND name='{0}'";

            const string STRING_GET_FIELDS = "select column_name,Data_type,column_type from information_schema.columns where Table_schema='{0}'  and table_name='{1}';";

            const string STRING_GET_PRIMARYKEY = "select column_name,table_name from information_schema.key_column_usage where Table_schema='{0}' and table_name='{1}' and CONSTRAINT_NAME='PRIMARY'";

            private void Open(string connectionstring)
            {
                // note : don't 'catch' here. Let the process above catch
                if (oDbConn != null)
                {
                    oDbConn.Dispose();
                    oDbConn = null;
                }
                foreach(string s in connectionstring.Split(';'))
                {
                    if (s.ToUpper().StartsWith("DATABASE="))
                    {
                        schema = s.Substring(9);
                    }

                }
                oDbConn = new MySqlConnection(connectionstring);
                oDbConn.Open();
            }
            private void Close()
            {
                oDbConn.Dispose();
            }

            #region IDataSourcePlugin Members
            string IDataSourcePlugin.GetPrimaryKey(string tablename)
            {
                string s = "";

                DataTable Dt = new DataTable();
                MySqlDataAdapter Da = new MySqlDataAdapter(String.Format(STRING_GET_PRIMARYKEY,schema ,tablename), oDbConn);
                Da.Fill(Dt);
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    s = s + (Dt.Rows[i][0].ToString() + ", ");
                }
                if (s.Length > 2) s = s.Substring(0, s.Length - 2);
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
                if (oDbConn == null)
                {
                    throw new Exception("DataBaseConnection Unopened");
                }
                else
                {
                    DataTable Dt = new DataTable();
                    MySqlDataAdapter Da = new MySqlDataAdapter(String.Format(STRING_GET_TABLES,schema), oDbConn);
                    Da.Fill(Dt);
                    return Dt;
                }
            }

            System.Data.DataTable IDataSourcePlugin.GetTable(string TableName)
            {

                DataTable Dt = new DataTable();
                MySqlDataAdapter Da = new MySqlDataAdapter(String.Format(STRING_GET_FIELDS,schema, TableName), oDbConn);
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
            void IDataSourcePlugin.Dispose() { }
            #endregion
        }
    }

