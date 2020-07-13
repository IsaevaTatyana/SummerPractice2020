using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace PracticeMyLibraryDAT
{
    public interface IGivenBookDAO
    {
        IEnumerable <GivenBook> GetGivenBooks();

        void AddGivenBook(GivenBook givenBook);

        void RemoveGivenBook(int GiveID);


    }
}
