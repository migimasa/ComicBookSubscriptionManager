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
    public class Publishers
    {
        private IPublisherAccess _publisherAccess;

        public Publishers()
        {
            this._publisherAccess = new PublisherAccess();
        }


        public List<Publisher> GetAllPublishers()
        {
            List<Publisher> publishersList = new List<Publisher>();

            var allPublishers = _publisherAccess.LoadPublishers();

            foreach (var publisherDl in allPublishers)
            {
                publishersList.Add(new Publisher(publisherDl));
            }

            return publishersList;
        }

        public Publisher GetPublisherById(Guid publisherId)
        {
            return new Publisher(_publisherAccess.LoadPublisherById(publisherId));
        }
    }


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
