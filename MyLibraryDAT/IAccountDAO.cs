using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace PracticeMyLibraryDAT
{
    public interface IAccountDAO
    {
        IEnumerable<Account> GetAccounts();

        void AddAccount(Account account);

        void RemoveAccount(int AccountID);

        IEnumerable<Account> Search(string Login, string Password);
    }
}
