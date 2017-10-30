using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataServiceGenerator.CodeBuilder_Classes
{
    class JavaBuilder:CodeBuilder
    {
        public JavaBuilder(DataTable t,
                      DataServiceGenerator.PersistenceClasses.Table b,
                      DataServiceGenerator.QueryBuilderClasses.IQueryBuilder q)
            :
            base(t, b, q)
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
