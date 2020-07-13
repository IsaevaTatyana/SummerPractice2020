using Entities;
using LibraryBLL;
using PracticeMylibraryBLL;
using System;
using System.Linq;

namespace PracticeMyLibraryPL
{
    class LibraryLogic
    {
        private static IVisitorLogic visitorLogic = new VisitorLogic();
        public static void AddVisitor()
        {
            Console.WriteLine("Имя читателя: ");
            string firstname = Console.ReadLine();
            Console.WriteLine("Фамилия читателя: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("Отчество читателя: ");
            string middlename = Console.ReadLine();
            Console.WriteLine("Номер Аккаунта: ");
            int accountID = int.Parse(Console.ReadLine());
            Console.WriteLine("Номер телефона: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Адрес: ");
            string adress = Console.ReadLine();
            var newVisitor = new Visitor()
            {
                FirstName = firstname,
                LastName = lastname,
                MiddleName = middlename,
                AccountID = accountID,
                Phone = phone,
                Adress = adress
            };
            visitorLogic.AddVisitor(newVisitor);
        }
        public static void GetVisitors()
        {
            var result =visitorLogic.GetVisitors();
            if (result.Any())
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.MiddleName + " " + item.AccountID + " " +  item.Phone + " " + item.Adress);
                }
            }
            else
            {
                Console.WriteLine("Список пуст!");
            }
        }
        public static void RemoveVisitor(int index)
        {
            if (index < 0 && index >= bookLogic.GetBooks().Count())
            {
                Console.WriteLine("Неправильно указан индекс!");

            }
            else
            {
                if (!visitorLogic.GetVisitors().Any())
                {
                    Console.WriteLine("Список пуст, удалять нечего!");
                }
                else
                {

                    visitorLogic.RemoveVisitor(index);
                }

            }
        }


/*******************************************************************************************************************************************************
*******************************************************************************************************************************************************/



        private static IBookLogic bookLogic = new BookLogic();
        public static void AddBook()
        {
            Console.WriteLine("Название книги: ");
            string name = Console.ReadLine();
            Console.WriteLine("Год публикации:");
            int publicYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Издательство: ");
            string publisher = Console.ReadLine();
            Console.WriteLine("Количество страниц:");
            int countOfPages = int.Parse(Console.ReadLine());
            Console.WriteLine("Цена:");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Количество экземпляров:");
            int countCopy = int.Parse(Console.ReadLine());
            Console.WriteLine("Cтатус книги: ");
            string statusBook = Console.ReadLine();
            var newBook = new Book()
            {
                Name = name,
                PublicYear = publicYear,
                Publisher = publisher,
                CountOfPages = countOfPages,
                Price = price,
                CountCopy = countCopy,
                StatusBook = statusBook
            };
            bookLogic.AddBook(newBook);
        }
        public static void GetBooks()
        {
            var result = bookLogic.GetBooks();
            if (result.Any())
            {
              foreach (var item in result)
              {
                  Console.WriteLine(item.Name + " " + item.PublicYear + " " + item.Publisher + " " + item.Price + " " + item.CountOfPages);
              }
            }
            else
            {
                Console.WriteLine("Список пуст!");
            }
        }
        public static void RemoveBook(int index)
        {
            if (index < 0 && index >= bookLogic.GetBooks().Count())
            {
                Console.WriteLine("Неправильно указан индекс!");

            }
            else
            {
                if (!bookLogic.GetBooks().Any())
                {
                    Console.WriteLine("Список пуст, удалять нечего!");
                }
                else
                {

                    bookLogic.RemoveBook(index);
                }

            }
        }

/*******************************************************************************************************************************************************
*******************************************************************************************************************************************************/

        private static IAuthorLogic authorLogic = new AuthorLogic();
        public static void AddAuthor()
        {
            Console.WriteLine("Имя автора: ");
            string firstname = Console.ReadLine();
            Console.WriteLine("Фамилия автора: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("Отчество автора: ");
            string middlename = Console.ReadLine();
            var newAuthor = new Author()
            {
                FirstName = firstname,
                LastName = lastname,
                MiddleName = middlename
            };
            authorLogic.AddAuthor(newAuthor);
        }
        public static void GetAuthors()
        {
            var result =authorLogic.GetAuthors();
            if (result.Any())
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.MiddleName);
                }
            }
            else
            {
                Console.WriteLine("Список пуст!");
            }
        }
        public static void RemoveAuthor(int index)
        {
            if (index < 0 && index >= authorLogic.GetAuthors().Count())
            {
                Console.WriteLine("Неправильно указан индекс!");

            }
            else
            {
                if (!authorLogic.GetAuthors().Any())
                {
                    Console.WriteLine("Список пуст, удалять нечего!");
                }
                else
                {

                    authorLogic.RemoveAuthor(index);
                }

            }
        }


        /*******************************************************************************************************************************************************
        *******************************************************************************************************************************************************/



        private static IAccountLogic accountLogic = new AccountLogic();
        public static void AddAccount()
        {
            Console.WriteLine("Логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Пароль: ");
            string password = Console.ReadLine();
            var newAccount = new Account()
            {
               Login = login,
               Password = password
            };
           accountLogic.AddAccount(newAccount);
        }
        public static void GetAccounts()
        {
            var result = accountLogic.GetAccounts();
            if (result.Any())
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Login + " " + item.Password);
                }
            }
            else
            {
                Console.WriteLine("Список пуст!");
            }
        }
        public static void RemoveAccount(int index)
        {
            if (index < 0 && index >= accountLogic.GetAccounts().Count())
            {
                Console.WriteLine("Неправильно указан индекс!");

            }
            else
            {
                if (!accountLogic.GetAccounts().Any())
                {
                    Console.WriteLine("Список пуст, удалять нечего!");
                }
                else
                {

                    accountLogic.RemoveAccount(index);
                }

            }
        }

        public static void Search(string login, string password)
        {
            var result = accountLogic.Search(login, password).ToList();
            if (!result.Any())
            {
                Console.WriteLine("Пльзователя с таким логином не существует, зарегистрируйтесь!");
                AddAccount();
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Login, item.Password );
                }
            }
        }

    }
}
