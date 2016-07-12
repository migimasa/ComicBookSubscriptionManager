using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubscriptionManager.DataLayer.Abstract;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class Customer : DataTableBase
    {
        public Guid CustomerId { get; set; }
        public Guid StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int SubscriptionCount { get; set; }


        public DynamicParameters GetParametersForCreate()
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@CustomerId", this.CustomerId, dbType: DbType.Guid);
            parameters.Add("@StoreId", this.StoreId, dbType: DbType.Guid);
            parameters.Add("@FirstName", this.FirstName, dbType: DbType.String);
            parameters.Add("@LastName", this.LastName, dbType: DbType.String);
            parameters.Add("@PhoneNumber", this.PhoneNumber, dbType: DbType.String);
            parameters.Add("@EmailAddress", this.EmailAddress, dbType: DbType.String);
            parameters.Add("@City", this.City, dbType: DbType.String);
            parameters.Add("@State", this.State, dbType: DbType.String);
            parameters.Add("@ZipCode", this.ZipCode, dbType: DbType.String);
            parameters.Add("@CreateDate", this.CreateDate, dbType: DbType.DateTime);
            parameters.Add("@UserId", this.CreateUserId, dbType: DbType.Guid);

            return parameters;
        }

        public DynamicParameters GetParametersForUpdate()
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@CustomerId", this.CustomerId, dbType: DbType.Guid);
            parameters.Add("@FirstName", this.FirstName, dbType: DbType.String);
            parameters.Add("@LastName", this.LastName, dbType: DbType.String);
            parameters.Add("@PhoneNumber", this.PhoneNumber, dbType: DbType.String);
            parameters.Add("@EmailAddress", this.EmailAddress, dbType: DbType.String);
            parameters.Add("@City", this.City, dbType: DbType.String);
            parameters.Add("@State", this.State, dbType: DbType.String);
            parameters.Add("@ZipCode", this.ZipCode, dbType: DbType.String);
            parameters.Add("@ChangeDate", this.CreateDate, dbType: DbType.DateTime);
            parameters.Add("@UserId", this.CreateUserId, dbType: DbType.Guid);

            return parameters;
        }
    }
}
