using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace dbNameSpace.Models
{
    public static class Transaction
    {
        public static /* insert contextName */ GlobalContext {
            get;
            set;
        }

        public static Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction Begin()
        {
            GlobalContext = new /* insert contextName */();
            return GlobalContext.Database.BeginTransaction();
        }

        public static void Commit()
        {
            GlobalContext.Database.CommitTransaction();
        }

        public static void RollBack()
        {
            GlobalContext.Database.RollbackTransaction();
        }

        public static void EndTransaction()
        {
            if (GlobalContext != null)
            {
                GlobalContext.Dispose();
                GlobalContext = null;
            }
        }

    public static /* insert contextName */ GetContext(bool localContext = false)
        {
            if (localContext)
            {
                return new /* insert contextName */();
            }
            return Transaction.GlobalContext != null ? Transaction.GlobalContext : new /* insert contextName */();
        }

        public static void DisposeContext( /* insert contextName */ context)
        {
            if (Transaction.GlobalContext == null)
                context.Dispose();
        }
    }
}



