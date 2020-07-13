using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace PracticeMyLibraryDAT
{
    public interface IConnectAuthorBookDAO
    {
        IEnumerable<ConnectAuthorBook> GetConnectAuthorBooks();

        void AddAuthorConnectAuthorBook(ConnectAuthorBook connectAuthorBook);

        void RemoveConnectBook(int BookID);


    }
}
