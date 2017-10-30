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
    struct TypeRelation
    {
        string ForiegnType;
        QueryBuilderEncodingType LocalType;
    }   
    
    class MySqlQueryBuilder:Object,IQueryBuilder
    {
        Table _table;
        private TypeRelation[] TypeTable = { };

        public QueryBuilderEncodingType SqlEncodingType(string ColumnType)
        {
            QueryBuilderEncodingType retval = QueryBuilderEncodingType.String;
            Console.Out.WriteLine(ColumnType);
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
            else if (_table.Fields == null)
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
                if (_table.Fields[i].ColumnName != this._table.PrimaryKey.ColumnName)
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
             string SqlExist = "Select count (" + this._table.PrimaryKey.ColumnName+ ") from " + _table.Name + " Where " + _table.PrimaryKey.ColumnName + "={0}";
            return SqlExist;
        }

        
        DataServiceGenerator.PersistenceClasses.Table IQueryBuilder.Table
        {
            get
            {
                return _table;
            }
            set
            {
                _table = value;
            }
        }

        QueryBuilderEncodingType IQueryBuilder.SqlEncodingType(string ColumnType)
        {
            //throw new NotImplementedException();
            QueryBuilderEncodingType retval;

            retval = QueryBuilderEncodingType.NumericInteger;

            if (ColumnType == "bigint") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "varchar") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "datetime") retval = QueryBuilderEncodingType.DateTime;
            else if (ColumnType == "int") retval = QueryBuilderEncodingType.NumericInteger;
            else if (ColumnType == "timestamp") retval = QueryBuilderEncodingType.DateTime;
            else if (ColumnType == "mediumtext") retval = QueryBuilderEncodingType.String;
            else if (ColumnType == "bit") retval = QueryBuilderEncodingType.Boolean;
            else Console.Out.WriteLine(ColumnType);

            return retval;
        }

        #endregion
    }
}
