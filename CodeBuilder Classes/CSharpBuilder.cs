using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DataServiceGenerator.QueryBuilderClasses;
using DataServiceGenerator.PersistenceClasses;


namespace DataServiceGenerator.CodeBuilder_Classes
{
    class CSharpBuilder:CodeBuilder
    {
        private const string _constructor_Parameterized = "\npublic {0} ({1} {2}, DSFactory _factoryReference )\n{{\nthis.db=_factoryReference;\nDataTable dt;\n\t dt=db.QueryDataTable(String.Format(\"{3}\",{2}));\n\t if(dt.Rows.Count==1){{\n\t\t {4}\n\t}}\n\t dt.Dispose(); \n}}\t\n";
        private const string _constructor_unParameterized = "\npublic {0} ( DSFactory _factoryReference)\n{{\n\tthis.db=_factoryReference;\n\t}}\t\n";
        private const string _constructor = _constructor_Parameterized + " " + _constructor_unParameterized;
        // 0 - Table Name, 
        // 1 - Primary Key C# type
        // 2 - Primart key column name
        // 3 - Select statement (SELECT * FROM tablename);

        private const string _deletor = "\npublic void Delete()\n{{\nstring s=\"{0}\";\n\tdb.NonQuery(String.Format(s,this._primarykey));\n}}\n";
        private const string _existorpublic = "\npublic bool Exists({0} {1})\n{{\n\t string s=\"{2}\";\n\tlong rowsCounted=db.QueryScalar(String.Format(s, {1}));\n \t return (rowsCounted>0)?true:false;\n }}\n";
        private const string _existorprivate = "\nprivate bool Exists({0} {1})\n{{\n\t string s=\"{2}\";\n\tlong rowsCounted=db.QueryScalar(String.Format(s, {1}));\n \t return (rowsCounted>0)?true:false;\n }}\n";
        private const string _insertor = "\npublic long Insert()\n{{\n\tstring s = \"{0}\";\n\t db.NonQuery(String.Format(s,{1}));return 0;\n}}\n";
        private const string _updator = "public void Update()\n{{\n\tstring s = \"{0}\";\n\t db.NonQuery(String.Format(s,{1}));\n \n}}\n";
        private const string _savor = "public void Save()\n{{\n\t if(this.Exists(_primarykey))\n\t{{\n\tthis.Update();\n\t}}\n\telse\n\t{{\n\tthis.Insert();\n\t}}\n}}\n";
        

        public CSharpBuilder( List<Table> b,IQueryBuilder q): base( b,q)
        {
              
        }
        
        protected override void do_build()
        {
           
            string retval;

            retval = this.Core;


            foreach (Table t in base._buildInstructions)
            {
                _queryBuilder.Table = t;
                retval= retval + this.BuildClass(t);
            }
            _GC = retval;
        }
        public override string Core
        {
            get
            {

             // Gets the Core library, including the primitive functions and includes;
               string retval;
               string filename = "C:\\Documents and Settings\\smuns631\\Desktop\\Courses\\Y1\\CUS1159\\Workspace\\DataServiceGenerator\\DataServiceGenerator\\Templates\\CsharpAccessRoot.txt";
               StreamReader R = new StreamReader(filename);
               retval = R.ReadToEnd();
               R.Close();
               string Creators = BuildCreators();
               string Loaders = BuildLoaders();
               string Enums = BuildEnumerator();
               retval = String.Format(retval, Creators, Loaders, Enums);

               return retval;
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
            for (int i = 0; i < t.Fields.Count;i++ )
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

            StringBuilder sb = new StringBuilder("\n/*Begin Public property Declarations */\n\tprivate  DSFactory db;\n\r");
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
                          GetLocalTypeFromFieldName(t.PrimaryKey.ColumnName,t) + 
                          " _primarykey \n{\n\t get{\n\t \t return this." + 
                          t.PrimaryKey.ColumnName+ 
                          ";\n\t}\n}\n";

            if (t.generateConstructor)
            {
                string n = t.Name;
                string kn = t.PrimaryKey.ColumnName;
                string kt = GetLocalTypeFromFieldName(t.PrimaryKey.ColumnName,t);
                string Sql=_queryBuilder.Create();
                string v =  MakeDataTransferToLocalVars("dt",t);
                
                ConstructorTxt = String.Format(_constructor, n, kt, kn, Sql, v); ;
            }
            if (t.generateDelete)
            {
                DeletorTxt = String.Format(_deletor, _queryBuilder.Delete());
            }
            if (t.generateExists)
            {
                ExistorTxt = String.Format(_existorpublic, GetLocalTypeFromFieldName(t.PrimaryKey.ColumnName,t), t.PrimaryKey.ColumnName, _queryBuilder.Exist());
            }
            else
            {
                if (t.generateSave)
                {
                    ExistorTxt = String.Format(_existorprivate, GetLocalTypeFromFieldName(t.PrimaryKey.ColumnName,t), t.PrimaryKey.ColumnName, _queryBuilder.Exist());
                }
            }
            if (t.generateInsert)
            {
                Insertor = String.Format(_insertor,QueryBuilder.Insert(),MakeParameterListFromTable(t));
            }
            if (t.generateSave)
            {
                SavorTxt = String.Format(_savor, t);
            }
            if (t.generateUpdate)
            {
                UpdatorTxt = String.Format(_updator,QueryBuilder.Update(),MakeParameterListFromTable(t) );
            }
            Methods = ConstructorTxt + DeletorTxt + ExistorTxt + Insertor + SavorTxt + UpdatorTxt;
            /// END CODE BUILD 
            // Put the output together here ;
            return  "\n/* BEGIN CLASS " + t.Name + " */\n" + Declarator + "\n" + Properties + "\n" + PrivateVars + "\n" + Methods + "\n}" + "\n/* END CLASS " + t.Name + " */\n";
            
        }
        private string BuildEnumerator()
        {
            string shell = "public enum DSFactoryTypeEnum{{\n{0}\n}}";
            string list = "";
            foreach (Table t in _buildInstructions)
            {
                list = list + t.Name + ", ";
            }
            list = list.Substring(0, list.Length - 2);
            string s  = String.Format(shell, list);
            return s;
        }

        private string BuildCreators()
        {
            string shell = "public {0} Create{0}() {{ return new {0}(this); }}";
            string list = "";
            foreach (Table t in _buildInstructions)
            {
                list = list + String.Format(shell, t.Name) + "\n" ;
            }
            return list;
        }
        private string BuildLoaders() {
            string shell = "public {0} Load{0}({2} {1}) {{ return new {0}({1},this); }}";
            string list = "";
            foreach (Table t in _buildInstructions)
            {
                list = list + String.Format(shell, t.Name,t.PrimaryKey.ColumnName,this.GetLocalTypeFromFieldName(t.PrimaryKey.ColumnName,t)) + "\n";
            }
            return list;
        }

        private string MakeDataTransferToLocalVars(string DataTableName,Table t)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < t.Fields.Count; i++)
            {
                string v; //VariableName
                string u;  //FormatString
                string w;  //
                s.Append ( "\n\t");
                
                u=t.Fields[i].ColumnName;
                v = GetLocalTypeFromFieldName(t.Fields[i].ColumnName, t);
                w = DataTableName + ".Rows[0][\"" + t.Fields[i].ColumnName+ "\"]";
                switch (GetLocalTypeFromFieldName(t.Fields[i].ColumnName, t))
                {
                    case "string": 
                            v = "{1}={0}.ToString();"; 
                            break;
                    case "int": 
                            v = "Int32.TryParse({0}.ToString(),out {1});"; 
                            break;
                    case "long": 
                            v = "Int64.TryParse({0}.ToString(),out {1});"; 
                            break;
                    case "DateTime": 
                            v = "DateTime.TryParse({0}.ToString(),out {1});"; 
                            break;
                    case "bool": 
                            v = "bool.TryParse({0}.ToString(),out {1});"; 
                            break;
                    case "float": 
                            v = "double.TryParse({0}.ToString(),out {1});"; 
                            
                            break;
                }
                s.Append(String.Format(v,w,u));
               
            }
            return s.ToString();
        }
        private string MakeParameterListFromTable(Table t)
        {
            StringBuilder sb = new StringBuilder();
          
            for(int i=0;i<t.Fields.Count;i++)
            {
                sb.Append(t.Fields[i].ColumnName);
                if ((t.Fields.Count - i) > 1) sb.Append(", ");
            }
            return sb.ToString();
        }
        private string GetLocalTypeFromFieldName(string fieldname, Table t)
        {
            for(int i=0;i<t.Fields.Count;i++)
                if (t.Fields[i].ColumnName == fieldname)
                    return GetLocalTypeFromSqlDescription(t.Fields[i].ColumnType, t.Fields[i].ColumnSize);
            return "null";
        }
        private string GetLocalTypeFromSqlDescription(QueryBuilderEncodingType SqlEncodedType, int SizeInBytes)
        {
            switch (SqlEncodedType)
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

