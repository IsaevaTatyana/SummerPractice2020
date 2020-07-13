using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace PracticeMyLibraryDAT
{
   public interface IPublisherDAO
    {

        IEnumerable<Publisher> GetPublishers();

        void AddPublisher(Publisher publisher);

        void RemovePublisher( int PublisherID);
    }
}
