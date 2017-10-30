using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace DataServiceGenerator.QueryBuilderClasses
{
    class AccessQueryBuilder:Object,IQueryBuilder
    {
        private DataTable _t;
        private string _tableName;
        private string _primaryKey;

        #region IQueryBuilder Members

       
        System.Data.DataTable IQueryBuilder.Columns
        {
            // Returns a table for of fields
            get { return _t; }
            set { _t = value; }
        }
        string IQueryBuilder.PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }
        string IQueryBuilder.TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        string IQueryBuilder.Insert()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;

            string SqlInsert = "Insert into " + _tableName + "( {0} ) VALUES {1} ";
            string fields = "";
            string values = "";

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
            return String.Format(SqlInsert, fields, values);
        }

        string IQueryBuilder.Create()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;

            return "SELECT * from " + _tableName + " WHERE " + _primaryKey + "={0}";

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
            for (int i = 0; i < _t.Rows.Count; i++)
                j = j + ((_primaryKey.ToUpper() == _t.Rows[i][0].ToString().ToUpper()) ? 1 : 0);
            return (j > 0 ? true : false);
        }
        private Exception ValidateObjectState()
        {

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

            string SqlDelete = "Delete from " + _tableName + " Where " + _primaryKey + "={0}";
            return SqlDelete;
        }

        string IQueryBuilder.Exist()
        {
            Exception e = ValidateObjectState();
            if (e != null) throw e;
            string fields = "";

            if (fields.EndsWith(",")) fields = fields.Substring(0, fields.Length - 1);
            string SqlExist = "Select count (" + this._primaryKey + ") from " + _tableName + " Where " + _primaryKey + "={0}";
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

        int SqlEncodingSize(string ColumnSize) { return 0; }
        #endregion
    }
}
