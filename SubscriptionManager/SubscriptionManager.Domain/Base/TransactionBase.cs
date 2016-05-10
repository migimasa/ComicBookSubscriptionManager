using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Transactions;

using DapperWrapper;

namespace SubscriptionManager.Domain.Base
{
    public class TransactionBase
    {
        private TransactionScope _transactionScope;

        public TransactionScopeWrapper TransactionScopeWrapper
        {
            get
            {
                return new TransactionScopeWrapper(this._transactionScope);
            }
        }
        public TransactionBase()
        {
            this._transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

    }
}
