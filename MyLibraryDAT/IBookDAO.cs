using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace PracticeMyLibraryDAT
{
   public interface IBookDAO
    {
        IEnumerable<Book> GetBooks();

        void AddBook(Book book);

        void RemoveBook(int BookID);

    }
}
