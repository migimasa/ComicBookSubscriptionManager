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

        private TransactionScopeWrapper _wrapper;
        public TransactionScopeWrapper TransactionScopeWrapper
        {
            get
            {
                //if (this._wrapper == null)
                //{
                //    this._wrapper = new TransactionScopeWrapper(this._transactionScope);
                //}
                //return this._wrapper;

                return new TransactionScopeWrapper(new TransactionScope());
            }
        }
        public TransactionBase()
        {
            this._transactionScope = new TransactionScope();
        }

    }
}
