using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;

namespace DataAccessLayer
{
    public class ConnectionDB
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        }
        public static TransactionScope CreateTransactionScope()
        {
            TransactionOptions to = new TransactionOptions();
            to.IsolationLevel = IsolationLevel.RepeatableRead;
            return new TransactionScope(TransactionScopeOption.Required, to);
        }
    }
}
