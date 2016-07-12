using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.Access;
using Migi.Framework.Helper;

namespace SubscriptionManager.Domain.ComicBookSeriesManagement
{
    public class Publisher
    {
        public Guid PublisherId { get; private set; }
        public string PublisherName { get; private set; }
        public bool HasData { get; private set; }
        
        public Publisher(SubscriptionManager.DataLayer.DataTables.Publisher publisherDl)
        {
            if (publisherDl != null)
            {
                this.HasData = true;
                this.PublisherId = publisherDl.PublisherId;
                this.PublisherName = publisherDl.PublisherName;
            }
            else
            {
                throw new ArgumentException("Invalid Publisher");
            }
        }
    }
}
