using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataServiceGenerator.QueryBuilderClasses;
using System.Data;
using System.Data.SqlClient;

namespace DataServiceGenerator.QueryBuilderClasses
{
    struct TypeRelation
    {
        string ForiegnType;
        QueryBuilderEncodingType LocalType;
    }   
    
    class MySqlQueryBuilder:Object,IQueryBuilder
    {
        private DataTable _t;
        private string _tableName;
        private string _primaryKey;
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
