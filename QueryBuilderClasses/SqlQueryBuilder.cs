using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataServiceGenerator.QueryBuilderClasses;
using System.Data;
using System.Data.SqlClient;
using DataServiceGenerator.PersistenceClasses;

namespace DataServiceGenerator.QueryBuilderClasses
{
    
    class SqlQueryBuilder:Object,IQueryBuilder
    {
        Table _table;
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
            for (int i = 0; i < _table.Fields.Count; i++)
                j = j + ((_table.PrimaryKey.ColumnName.ToUpper() == _table.Fields[i].ColumnName.ToUpper()) ? 1 : 0);
            return (j > 0 ? true : false);
        }
        private Exception ValidateObjectState(){

            Exception retval = null;

            if (_table.PrimaryKey.ColumnName.Length == 0)
            {
                retval = new Exception("Primary Key is empty");
            }
            else if (_table.Name.Length == 0)
            {
                retval = new Exception("Target Table is empty");
            }
            else if (_table.Fields== null)
            {
                retval = new Exception("Field list is empty");
            }
            else if (_table.Name.IndexOfAny(",.;%$!#@&-:".ToCharArray()) >= 0)
            {
                retval = new Exception("Target Tablename is Illegal");
            }
            else if (_table.PrimaryKey.ColumnName.IndexOf(',') >= 0)
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
        

        // These relate the queries that are used in each call
        string IQueryBuilder.Insert()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;

            string SqlInsert = "Insert into " + _table.Name + "( {0} ) VALUES {1} ";
            string fields = "";
            string values="";
          
            for (int i = 0; i < _table.Fields.Count; i++)
            {
                if (_table.Fields[i].ColumnName != _table.PrimaryKey.ColumnName)
                {
                    fields += " " + _table.Fields[i].ColumnName + " ,";
                    switch (_table.Fields[i].ColumnType)
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

            return "SELECT * from "+ _table.Name + " WHERE "+_table.PrimaryKey.ColumnName+"={0}";

        }
        string IQueryBuilder.Update()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;

            string SqlUpdate = "UPDATE " + _table.Name + " SET  {1} WHERE {0} ";
            string valuesets="";
            string where="";
            string field = "";
            string value = "";
            for (int i = 0; i < _table.Fields.Count; i++)
            {
                switch (_table.Fields[i].ColumnType)
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
                if (_table.Fields[i].ColumnName != _table.PrimaryKey.ColumnName)
                    valuesets += " " + _table.Fields[i].ColumnName + "=" + value + " ,";
                else
                    where = " " + _table.Fields[i].ColumnName + " = ";
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

            string SqlDelete = "Delete from " + _table.Name + " Where " + _table.PrimaryKey.ColumnName + "={0}";
            return SqlDelete;
        }
        string IQueryBuilder.Exist()
         {
             Exception e = ValidateObjectState();
             if (e != null) throw e;
             string fields="";
             
             if ( fields.EndsWith(",")) fields=fields.Substring(0,fields.Length -1);
             string SqlExist = "Select count (" + _table.PrimaryKey.ColumnName+ ") from " + _table.Name + " Where " + _table.PrimaryKey.ColumnName + "={0}";
            return SqlExist;
        }
        Table IQueryBuilder.Table
        {
            get
            {
                return _table;
            }
            set
            {
                value = _table;
            }
        }
        QueryBuilderEncodingType IQueryBuilder.SqlEncodingType(string ColumnType)
        {
            QueryBuilderEncodingType retval = 0;
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

        #endregion
    }
}
