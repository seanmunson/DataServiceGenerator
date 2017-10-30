using System;
using System.Collections.Generic;
using System.Data;
using DataServiceGenerator.PersistenceClasses;

namespace DataServiceGenerator.QueryBuilderClasses
{
    public enum QueryBuilderEncodingType
    {
            NumericInteger=0,
            NumericReal=1,
            String=2,
            DateTime=3,
            Boolean=4
    }
    interface IQueryBuilder
    {

        /// <summary>
        /// Table Object used to compose the queries
        /// </summary>
         PersistenceClasses.Table Table
        {
            get;
            set;
        }
        

        /// <summary>
        /// creates an insert statement for this table
        /// used when inserting a new record into the table.
        /// </summary>
        /// <returns>INSERT SQL string</returns>
        string Insert();

        /// <summary>
        /// gets the data from the database, given the 
        /// primary key
        /// </summary>
        /// <returns>the SELECT SQL statement</returns>
        string Create();

        /// <summary>
        /// creates the SQL statement that alters the contents of 
        /// a record in the table
        /// </summary>
        /// <returns>the UPDATE SQL statement</returns>
        string Update();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string Save();

        /// <summary>
        /// creates the SQL statement to remove the record 
        /// indicated by the primary key
        /// </summary>
        /// <returns>the DELETE SQL command</returns>
        string Delete();

        /// <summary>
        /// create the SQL statement that determines 
        /// whether or not the 
        /// </summary>
        /// <returns></returns>
        string Exist();

        QueryBuilderEncodingType SqlEncodingType(string ColumnType);
        int SqlEncodingSize(string ColumnSize);
        
        
    }
}
