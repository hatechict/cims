﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Data.Infrastructure
{
    interface IUnitOfWork
    {
        void Commit();
    }
}
