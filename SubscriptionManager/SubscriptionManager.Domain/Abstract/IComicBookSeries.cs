using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.Domain.ComicBookSeriesManagement;

namespace SubscriptionManager.Domain.Abstract
{
    public interface IComicBookSeries
    {
        List<Publisher> GetAllPublishers();
    }
}
