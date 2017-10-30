using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DataServiceGenerator.QueryBuilderClasses;


namespace DataServiceGenerator.CodeBuilder_Classes
{
    class CSharpBuilder:CodeBuilder
    {
        private const string _constructor = "\npublic {0} ({1} {2})\n{{\n\tDataTable dt;\n\t dt=QueryDataTable(\"{3}\",{2});\n\t if(dt.Rows.Count==1){{\n\t\t {4}\n\t}}\n\t dt.Dispose(); \n}}\t\n";
        // 0 - Table Name, 
        // 1 - Primary Key C# type
        // 2 - Primart key column name
        // 3 - Select statement (SELECT * FROM tablename);

        private const string _deletor = "\npublic void Delete()\n{{\nstring s=\"{0}\";\n\tNonQuery(String.Format(s,this._primarykey));\n}}\n";
        private const string _existorpublic = "\npublic bool Exists({0} {1})\n{{\n\t string s=\"{2}\";\n\tint rowsCounted=QueryScalar(String.Format(s, {1}));\n \t return (rowsCounted>0)?true:false;\n }}\n";
        private const string _existorprivate = "\nprivate bool Exists({0} {1})\n{{\n\t string s=\"{2}\";\n\tint rowsCounted=QueryScalar(String.Format(s, {1}));\n \t return (rowsCounted>0)?true:false;\n }}\n";
        private const string _insertor= "\npublic long Insert()\n{{\n\tstring s = \"{0}\";\n\t nonQuery(String.Format(s,{1}));\n}}\n";
        private const string _updator = "public void Update()\n{{\n\tstring s = \"{0}\";\n\t nonQuery(String.Format(s,{1}));\n \n}}\n";
        private const string _savor= "public void Save()\n{{\n\t if(this.Exists())\n\t{{\n\tthis.Update();\n\t}}\n\telse\n\t{{\n\tthis.Insert();\n\t}}\n}}\n";
        

        public CSharpBuilder( 
                      DataServiceGenerator.PersistenceClasses.Table b,
                      DataServiceGenerator.QueryBuilderClasses.IQueryBuilder q)
                      : 
                      base( b,q)
        {
              
        }
        
        protected override void do_build()
        {

        }
        public override string Core
        {
            get
            {

                // Gets the Core library, including the primitive functions and includes;
                string retval;
                string filename = "C:\\Documents and Settings\\smuns631\\Desktop\\Courses\\CUS1159\\Workspace\\DataServiceGenerator\\DataServiceGenerator\\Templates\\CsharpSQLRoot.txt";
                StreamReader R = new StreamReader(filename);
               retval = R.ReadToEnd();
               return retval;
               string Creators = BuildCreators(this._buildInstructions);
               string Loaderts = BuildLoaders(this._buildInstructions);
               string Enums = BuildEnums(this._buildInstructions);
            }
        }

        private string BuildClass(PersistenceClasses.Table t)
        {
                        string Properties = "";
            string Methods="";
            string PrivateVars = "";
            string Usings = "";
            string Declarator = "";

            Declarator = "public class " +  t.Name + "\n{\n";
            Stack<string> StringFields = new Stack<string>();
            Stack<string> IntFields = new Stack<string>();
            Stack<string> DateTimeFields = new Stack<string>();
            Stack<string> FloatingFields = new Stack<string>();
            Stack<string> BoolFields = new Stack<string>();
            for (int i = 0; i < t.Fields.count;i++ )
            {
                switch (t.Fields[i].ColumnType)
                {
                        
                    case QueryBuilderEncodingType.NumericInteger:
                        IntFields.Push(t.Fields[i].ColumnName);
                        break;
                    case QueryBuilderEncodingType.NumericReal:
                        FloatingFields.Push(t.Fields[i].ColumnName);
                        break;
                    case QueryBuilderEncodingType.String:
                        StringFields.Push(t.Fields[i].ColumnName);
                        break;
                    case QueryBuilderEncodingType.DateTime:
                        DateTimeFields.Push(t.Fields[i].ColumnName);
                        break;
                    case QueryBuilderEncodingType.Boolean:
                        BoolFields.Push(t.Fields[i].ColumnName);
                        break;
                }
            }
            Properties = "";
       
            /// BUILD CODE HERE 

            string ConstructorTxt = ""; 
            string DeletorTxt="" ;
            string ExistorTxt=""; 
            string Insertor="" ;
            string SavorTxt="" ;
            string UpdatorTxt="";

            StringBuilder sb = new StringBuilder("\n/*Begin Public property Declarations */");
            sb.Append(MakeDeclarationFromStack(StringFields," public string "));
            sb.Append(MakeDeclarationFromStack(FloatingFields, " public double "));
            sb.Append(MakeDeclarationFromStack(IntFields, " public int "));
            sb.Append(MakeDeclarationFromStack(DateTimeFields, " public DateTime "));
            sb.Append(MakeDeclarationFromStack(BoolFields, " public bool "));
            sb.Append("\n\n/*End public property definitions*/\n\n");
            Properties = sb.ToString();
            /*
                Always build a private primary index property
            */
            PrivateVars = " private " + 
                          GetLocalTypeFromFieldName(_queryBuilder.PrimaryKey) + 
                          " _primarykey \n{\n\t get{\n\t \t return this." + 
                          this._queryBuilder.PrimaryKey + 
                          ";\n\t}\n}\n";

            if (this._buildInstructions.generateConstructor)
            {
                string n = BuildInstructions.Name;
                string kn = _queryBuilder.PrimaryKey;
                string kt= GetLocalTypeFromFieldName(_queryBuilder.PrimaryKey);
                string Sql=_queryBuilder.Create();
                string v =  MakeDataTransferToLocalVars("dt");
                
                ConstructorTxt = String.Format(_constructor, n, kt, kn, Sql, v); ;
            }
            if (this._buildInstructions.generateDelete)
            {
                DeletorTxt = String.Format(_deletor, _queryBuilder.Delete());
            }
            if (this._buildInstructions.generateExists)
            {
                ExistorTxt =String.Format(_existorpublic, GetLocalTypeFromFieldName(QueryBuilder.PrimaryKey),QueryBuilder.PrimaryKey, _queryBuilder.Exist());
            }
            else
            {
                if (this._buildInstructions.generateSave)
                {
                    ExistorTxt = String.Format(_existorprivate, GetLocalTypeFromFieldName(QueryBuilder.PrimaryKey), QueryBuilder.PrimaryKey, _queryBuilder.Exist());
                }
            }
            if (this._buildInstructions.generateInsert)
            {
                Insertor = String.Format(_insertor,QueryBuilder.Insert(),MakeParameterListFromTable());
            }
            if (this._buildInstructions.generateSave)
            {
                SavorTxt = String.Format(_savor, this.Table.TableName);
            }
            if (this._buildInstructions.generateUpdate)
            {
                UpdatorTxt = String.Format(_updator,QueryBuilder.Update(),MakeParameterListFromTable() );
            }
            Methods = ConstructorTxt + DeletorTxt + ExistorTxt + Insertor + SavorTxt + UpdatorTxt;
            /// END CODE BUILD 
            // Put the output together here ;
            return  "\n/* BEGIN CLASS " + _buildInstructions.Name + " */\n" + Declarator + "\n" + Properties + "\n" + PrivateVars + "\n" + Methods + "\n}" + "\n/* END CLASS " + _buildInstructions.Name + " */\n";
            
        }
        private BuildEnumerator(){}
        private BuildCreators(){}
        private BuildEnums(){}

        private string MakeDataTransferToLocalVars(string DataTableName)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < this._dataTable.Rows.Count; i++)
            {
                s.Append ( "\n\t");
                s.Append(_dataTable.Rows[i][0].ToString());
                s.Append("=");
                s.Append(DataTableName + ".Rows[0][\"" + _dataTable.Rows[i][0].ToString() + "\"];"); 
            }
            return s.ToString();
        }
        private string MakeParameterListFromTable()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = this.QueryBuilder.Columns;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                sb.Append(dt.Rows[i][0].ToString());
                if ((dt.Rows.Count - i) > 1)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }
        private string GetLocalTypeFromFieldName(string fieldname)
        {
            for(int i=0;i<_dataTable.Rows.Count;i++)
                if (_dataTable.Rows[i][0].ToString() == fieldname)
                    return GetLocalTypeFromSqlDescription(_dataTable.Rows[i][1].ToString(), Int32.Parse(_dataTable.Rows[i][2].ToString()));
            return "null";
        }
        private string GetLocalTypeFromSqlDescription(string SqlEncodedType, int SizeInBytes)
        {
            switch (QueryBuilder.SqlEncodingType(SqlEncodedType))
            {

                case QueryBuilderEncodingType.NumericInteger:
                    switch (SizeInBytes)
                    {
                        case 8:
                            return "long";
                        default:
                            return "int";
                    }
                    break;
                case QueryBuilderEncodingType.NumericReal:
                    switch (SizeInBytes)
                    {
                        default:
                            return "float";
                    }
                    break;
                case QueryBuilderEncodingType.String:
                    return "string";
                    break;
                case QueryBuilderEncodingType.DateTime:
                    return "DateTime";
                    break;
                case QueryBuilderEncodingType.Boolean:
                    return "bool";
                    break;
            }
            return "null";
        }
        private string MakeDeclarationFromStack(Stack<string> stk, string decl)
        {
            // turns the strings in stk into properly defined variables

            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            if (stk.Count > 0)
            {
                
                sb.Append(decl);
                while (stk.Count > 0)
                {
                    sb.Append(stk.Pop());
                    if (stk.Count > 0)
                        sb.Append(",\n\t");
                    else
                        sb.Append(";");
                }
            }
            return sb.ToString();
        }
       
    }
        
    }

