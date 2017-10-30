using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataServiceGenerator.PersistenceClasses;
using DataServiceGenerator.QueryBuilderClasses;

namespace DataServiceGenerator.CodeBuilder_Classes
{
    abstract class CodeBuilder
    {
        // Root Class ; 
        protected DataTable _dataTable;        // database Layout
        protected List<Table> _buildInstructions; // config of output class
        protected IQueryBuilder _queryBuilder;
        protected string _GC;               // generated code

        public CodeBuilder( List<Table> b, QueryBuilderClasses.IQueryBuilder q)
        {
            ;
            _buildInstructions = b;
            _queryBuilder = q;

        }

       
        public PersistenceClasses.Table BuildInstructions
        {
            set { _buildInstructions = value; }
            get { return _buildInstructions; }

        }
        public QueryBuilderClasses.IQueryBuilder QueryBuilder
        {
            set { _queryBuilder = value; }
            get { return _queryBuilder; }
        }
        public void Build()
        {
            if (_buildInstructions == null) throw new Exception("BuildInstructions cannot be null");
            if (_queryBuilder == null) throw new Exception("QueryBuilder cannot be null");
            // Internal, private construction process.
            // Constructs the DataObjects in manner
            // Consistent with the Language, puts resulting string into
            // the Generated code (_GC) variable;
            do_build();

        }

        public string CodeText
        {
            get { return _GC; }
        }
        protected abstract void do_build();

        public abstract string Core
        {
            get;
        }
            


    }
}
