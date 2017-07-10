using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public static class Transaction
    {
        public static ercContext GlobalContext {
            get;
            set;
        }

        public static Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction Begin()
        {
            GlobalContext = new ercContext();
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

    public static ercContext GetContext(bool localContext = false)
        {
            if (localContext)
            {
                return new ercContext();
            }
            return Transaction.GlobalContext != null ? Transaction.GlobalContext : new ercContext();
        }

        public static void DisposeContext( ercContext context)
        {
            if (Transaction.GlobalContext == null)
                context.Dispose();
        }
    }
}



