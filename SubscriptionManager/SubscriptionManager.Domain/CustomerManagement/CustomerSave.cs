using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class CustomerSave
    {
        public Guid? CustomerId { get; set; }
        public Guid StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Guid UserId { get; set; }

        internal DataLayer.DataTables.Customer GetDataTable()
        {
            return new DataLayer.DataTables.Customer()
            {
                ChangeDate = DateTime.UtcNow,
                ChangeUserId = UserId,
                City = Migi.Framework.Helper.StringHelper.TrimStringForSaving(City),
                CreateDate = DateTime.UtcNow,
                CreateUserId = UserId,
                CustomerId = CustomerId.HasValue ? CustomerId.Value : Guid.NewGuid(),
                DeleteDate = null,
                EmailAddress = Migi.Framework.Helper.StringHelper.TrimStringForSaving(EmailAddress),
                FirstName = Migi.Framework.Helper.StringHelper.TrimStringForSaving(FirstName),
                LastName = Migi.Framework.Helper.StringHelper.TrimStringForSaving(LastName),
                PhoneNumber = Migi.Framework.Helper.StringHelper.TrimStringForSaving(PhoneNumber),
                State = Migi.Framework.Helper.StringHelper.TrimStringForSaving(State),
                StoreId = StoreId,
                ZipCode = Migi.Framework.Helper.StringHelper.TrimStringForSaving(ZipCode)
            };
        }
    }
}
