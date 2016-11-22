using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        CimsContext dbContext;
        CimsContext Init()
        {
            return dbContext ?? (dbContext = new CimsContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        CimsContext IDbFactory.Init()
        {
            throw new NotImplementedException();
        }
    }
}
