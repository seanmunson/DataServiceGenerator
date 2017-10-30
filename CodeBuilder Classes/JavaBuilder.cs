using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataServiceGenerator.PersistenceClasses;
using DataServiceGenerator.QueryBuilderClasses;

namespace DataServiceGenerator.CodeBuilder_Classes
{
    class JavaBuilder:CodeBuilder
    {
        public JavaBuilder(List<Table> b, IQueryBuilder q)
            :
            base( b, q)
        {

        }

        protected override void do_build()
        {
            throw new NotImplementedException();
        }

        public override string Core
        {
            get
            {
                throw new NotImplementedException();
            }
            
        }
    }
}
