using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataServiceGenerator.QueryBuilderClasses;
using System.Data;
using System.Data.SqlClient;

namespace DataServiceGenerator.QueryBuilderClasses
{
    
    class SqlQueryBuilder:Object,IQueryBuilder
    {
        

        private DataTable _t;
        private string _tableName;
        private string _primaryKey;

        public QueryBuilderEncodingType SqlEncodingType(string ColumnType)
        {
            QueryBuilderEncodingType retval = 0;
            /* returns ;
            0 - numeric
            1 - string ' ' 
            2 - date   # #
           */
           
            if (ColumnType == "bigint") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "binary") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "bit") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "char") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "date") retval = QueryBuilderEncodingType.DateTime;
            else if (ColumnType == "datetime") retval = QueryBuilderEncodingType.DateTime;
            else if (ColumnType == "datetime2") retval = QueryBuilderEncodingType.DateTime;
            else if (ColumnType == "datetimeoffset") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "decimal") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "float") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "image") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "int") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "money") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "nchar") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "ntext") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "numeric") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "nvarchar") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "nvarchar") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "real") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "smalldatetime") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "smalldatetime") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "smallint") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "smallmoney") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "sql_variant") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "text") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "time") retval = QueryBuilderEncodingType.DateTime;
            else if (ColumnType == "timestamp") retval = QueryBuilderEncodingType.NumericInteger; // Not legal, btw.
            else if (ColumnType == "tinyint") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "uniqueidentifier") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "varbinary") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "varbinary") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "varchar") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "varchar") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "xml") retval = QueryBuilderEncodingType.NumericInteger;
            return retval;
        }
        private bool ContainsKey()
        {
            int j=0;
            for (int i = 0; i < _t.Rows.Count; i++)
                j = j + ((_primaryKey.ToUpper() == _t.Rows[i][0].ToString().ToUpper()) ? 1 : 0);
            return (j > 0 ? true : false);
        }
        private Exception ValidateObjectState(){

            Exception retval = null;

            if (_primaryKey.Length == 0)
            {
                retval = new Exception("Primary Key is empty");
            }
            else if (_tableName.Length == 0)
            {
                retval = new Exception("Target Table is empty");
            }
            else if (_t == null)
            {
                retval = new Exception("Field list is empty");
            }
            else if (_tableName.IndexOfAny(",.;%$!#@&-:".ToCharArray()) >= 0)
            {
                retval = new Exception("Target Tablename is Illegal");
            }
            else if (_primaryKey.IndexOf(',') >= 0)
            {
                retval = new Exception("Primary Key is too complex");
            }
            else if (!ContainsKey())
            {
                retval = new Exception("Primary Key is not in Table");
            }
            return retval;

        }

        #region IQueryBuilder Members
        int IQueryBuilder.SqlEncodingSize(string ColumnSize) { return 0; }
        System.Data.DataTable IQueryBuilder.Columns
        {
            // Returns a table for of fields
             get { return _t;           }
             set { _t = value;          }
        }
        string IQueryBuilder.PrimaryKey
        {
            get { return _primaryKey;   }
            set { _primaryKey = value;  }
        }
        string IQueryBuilder.TableName
        {
            get {return _tableName;     }
            set {_tableName = value;    }
        }   

        // These relate the queries that are used in each call
        string IQueryBuilder.Insert()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;

            string SqlInsert = "Insert into " + _tableName + "( {0} ) VALUES {1} ";
            string fields = "";
            string values="";
          
            for (int i = 0; i < _t.Rows.Count; i++)
            {
                if (_t.Rows[i][0] != this._primaryKey)
                {
                    fields += " " + _t.Rows[i][0] + " ,";
                    switch (SqlEncodingType(_t.Rows[i][1].ToString()))
                    {
                        case QueryBuilderEncodingType.DateTime:
                            values += " '{" + i.ToString() + "}', ";
                            break;
                        case QueryBuilderEncodingType.String:
                            values += " '{" + i.ToString() + "}', ";
                            break;
                        case QueryBuilderEncodingType.NumericInteger:

                            values += " {" + i.ToString() + "}, ";
                            break;
                        case QueryBuilderEncodingType.NumericReal:

                            values += " {" + i.ToString() + "}, ";
                            break;
                        case QueryBuilderEncodingType.Boolean:
                            values += " {" + i.ToString() + "}, ";
                            break;
                        default:
                            values += " {" + i.ToString() + "}, ";
                            break;
                    }
                }
            }
            if (values.EndsWith(",")) values = values.Substring(0, values.Length - 1);
            if (fields.EndsWith(",")) fields = fields.Substring(0, fields.Length - 1);
            return String.Format(SqlInsert,fields,values);
        }
        string IQueryBuilder.Create()
         {

            // The code used in the Constructor
             Exception e = ValidateObjectState();
             if (e != null) throw e;

            return "SELECT * from "+ _tableName + " WHERE "+_primaryKey+"={0}";

        }
        string IQueryBuilder.Update()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;

            string SqlUpdate = "UPDATE " + _tableName + " SET  {1} WHERE {0} ";
            string valuesets="";
            string where="";
            string field = "";
            string value = "";
            for (int i = 0; i < _t.Rows.Count; i++)
            {
                switch (SqlEncodingType(_t.Rows[i][1].ToString()))
                {
                    case  QueryBuilderEncodingType.DateTime:
                        value = "'{" + i.ToString() + "}'";
                        break;
                    case QueryBuilderEncodingType.String:
                        value = "'{" + i.ToString() + "}'";
                        break;
                    case QueryBuilderEncodingType.NumericInteger:
                        value = "{" + i.ToString() + "}";
                        break;
                    case QueryBuilderEncodingType.NumericReal:
                        value = "{" + i.ToString() + "}";
                        break;
                    case QueryBuilderEncodingType.Boolean:
                        value = "{" + i.ToString() + "}";
                        break;
                    default:
                        value = "{" + i.ToString() + "}";
                        break;
                }
                if (_t.Rows[i][0].ToString() != _primaryKey)
                    valuesets += " " + _t.Rows[i][0].ToString() + "=" + value + " ,";
                else
                    where = " " + _t.Rows[i][0].ToString() + " = ";
            }
            if (valuesets.EndsWith(",")) valuesets = valuesets.Substring(0, valuesets.Length - 1);
            return (String.Format(SqlUpdate, where, valuesets) + "{0}");
        }
        string IQueryBuilder.Save()
         {
             Exception e = ValidateObjectState();
             if (e != null) throw e;

             return "";

        }
        string IQueryBuilder.Delete()
         {
             Exception e = ValidateObjectState();
             if (e != null) throw e;

            string SqlDelete = "Delete from " + _tableName + " Where " + _primaryKey + "={0}";
            return SqlDelete;
        }
        string IQueryBuilder.Exist()
         {
             Exception e = ValidateObjectState();
             if (e != null) throw e;
             string fields="";
             
             if ( fields.EndsWith(",")) fields=fields.Substring(0,fields.Length -1);
             string SqlExist = "Select count (" + this._primaryKey+ ") from " + _tableName + " Where " + _primaryKey + "={0}";
            return SqlExist;
        }

        #endregion
    }
}
