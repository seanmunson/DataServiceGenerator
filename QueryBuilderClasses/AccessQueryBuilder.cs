using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using DataServiceGenerator.PersistenceClasses;

namespace DataServiceGenerator.QueryBuilderClasses
{
    class AccessQueryBuilder:Object,IQueryBuilder
    {
        private Table _table;   
        
        #region IQueryBuilder Members

        public Table Table
        {
            set { _table = value; }
            get { return _table; }
        }
       
        

        string IQueryBuilder.Insert()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;

            string SqlInsert = "Insert into " + _table.Name + "( {0} ) VALUES {1} ";
            string fields = "";
            string values = "";

            for (int i = 0; i < _table.Fields.Count; i++)
            {
                if (_table.Fields[i] != _table.PrimaryKey)
                {
                    fields += " " + _table.Fields[i].ColumnName + " ,";
                    values += RepresentValueInString(i.ToString(), _table.Fields[i].ColumnType) + " ,";
                }
            }
            if (values.EndsWith(",")) values = values.Substring(0, values.Length - 1);
            if (fields.EndsWith(",")) fields = fields.Substring(0, fields.Length - 1);
            return String.Format(SqlInsert, fields, values);
        }
        string RepresentValueInString(string value,QueryBuilderEncodingType t)
        {
            string retval = "";
            switch (t)
            {
                case QueryBuilderEncodingType.DateTime:
                    retval = " '{" + value + "}' ";
                    break;
                case QueryBuilderEncodingType.String:
                    retval = " '{" + value + "} ";
                    break;
                case QueryBuilderEncodingType.NumericInteger:

                    retval = " {" + value + "} ";
                    break;
                case QueryBuilderEncodingType.NumericReal:

                    retval = " {" + value + "} ";
                    break;
                case QueryBuilderEncodingType.Boolean:
                    retval = " {" + value + "} ";
                    break;
                default:
                    retval = " {" + value + "} ";
                    break;
            }
            return retval;
        }
        string IQueryBuilder.Create()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;

            return "SELECT * from " + _table.Name + " WHERE " + _table.PrimaryKey.ColumnName + "={0}";

        }


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
            int j = 0;
            for (int i = 0; i < _table.Fields.Count; i++)
                j = j + ((_table.PrimaryKey.ColumnName.ToUpper() == _table.Fields[i].ColumnName.ToUpper()) ? 1 : 0);
            return (j > 0 ? true : false);
        }
        private Exception ValidateObjectState()
        {

            Exception retval = null;

            if (_table.PrimaryKey==null)
            {
                retval = new Exception("Primary Key is empty");
            }
            else if (_table.Name.Length == 0)
            {
                retval = new Exception("Target Table is empty");
            }
            else if (_table.Fields.Count < 2)
            {
                    retval=new Exception("Too Few columns");
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

        string IQueryBuilder.Update()
        {
            return "";
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
            string fields = "";

            if (fields.EndsWith(",")) fields = fields.Substring(0, fields.Length - 1);
            string SqlExist = "Select count (" + _table.PrimaryKey.ColumnName + ") from " + _table.Name + " Where " + _table.PrimaryKey.ColumnName + "={0}";
            return SqlExist;
        }

        QueryBuilderEncodingType IQueryBuilder.SqlEncodingType(string ColumnType)
        {
            QueryBuilderEncodingType retval = QueryBuilderEncodingType.String; 

            switch (ColumnType)
            {
                case "System.String":
                    retval =  QueryBuilderEncodingType.String;
                    break;
                case "System.DateTime":
                    retval = QueryBuilderEncodingType.DateTime;
                    break;
                case "System.Decimal":
                    retval = QueryBuilderEncodingType.NumericReal;
                    break;
                case "System.Boolean":
                    break;
                    retval = QueryBuilderEncodingType.Boolean;
                    break;
                case "System.Byte[]":
                    retval = QueryBuilderEncodingType.String;
                    break;
                case "System.Byte":
                    retval = QueryBuilderEncodingType.Boolean;
                    break;
                case "System.Int16":
                    retval = QueryBuilderEncodingType.NumericInteger;
                    break;
                case "System.Int32":
                    retval = QueryBuilderEncodingType.NumericInteger;
                    break;
                case "System.Single":
                    retval = QueryBuilderEncodingType.NumericReal;
                    break;
                case "System.Double":
                    retval = QueryBuilderEncodingType.NumericReal;
                    break;
                case "System.Guid":
                    retval = QueryBuilderEncodingType.String;
                    break;
                default:
                    retval = QueryBuilderEncodingType.String;
                    break;
            }
            return retval;
        }

        int IQueryBuilder.SqlEncodingSize(string ColumnSize) { return 0; }
        #endregion
    }
}
