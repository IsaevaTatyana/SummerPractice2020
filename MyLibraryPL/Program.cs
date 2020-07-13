using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeMyLibraryPL
{
    class Program
    {
        static void Main(string[] args)
        {

           Console.WriteLine("Введите Логин и пароль: ");

           LibraryLogic.Search(Console.ReadLine(), Console.ReadLine());

            Console.WriteLine("Выберите сущность:" + Environment.NewLine + "1 - Книга" + Environment.NewLine + 
                "2 - Автор" + Environment.NewLine + "3 - Читатель");
            var action = Console.ReadLine();
            int count = 0;

            switch (action)
            {
                case "1":
                Console.WriteLine("Выберите одно из следующих действий:" + Environment.NewLine + "1 - Добавить книгу" + Environment.NewLine +
                   "2 - Просмотреть список книг" + Environment.NewLine + "3 - Удалить книгу");
                        var action1 = Console.ReadLine();
                        switch (action1)
                        {
                            case "1":
                                LibraryLogic.AddBook();
                            count = count + 1;
                                break;
                            case "2":
                                {
                                    Console.WriteLine("Список книг:");
                                    LibraryLogic.GetBooks();
                                count = count + 1;
                            }
                                 break;
                            case "3":
                                {
                                    Console.WriteLine("Укажите индекс книги:");
                                    LibraryLogic.RemoveBook(int.Parse(Console.ReadLine()));
                                count = count + 1;
                            }
                                break;
                            default:
                                Console.WriteLine("Действие не указано!");
                            count = count + 1;
                            break;
                        }
                break;

                case "2":
                    Console.WriteLine("Выберите одно из следующих действий:" + Environment.NewLine + "1 - Добавить Автора" + Environment.NewLine + "2 - Просмотреть список авторов" + Environment.NewLine +
            "3 - Удалить Автора");
                    var action2 = Console.ReadLine();
                    switch (action2)
                    {
                        case "1":
                            LibraryLogic.AddAuthor();
                            break;

                        case "2":
                            {
                                Console.WriteLine("Список книг:");
                                LibraryLogic.GetAuthors();
                            }
                            break;

                        case "3":
                            {
                                Console.WriteLine("Укажите индекс книги:");
                                LibraryLogic.RemoveAuthor(int.Parse(Console.ReadLine()));
                            }
                            break;

                        default:
                            Console.WriteLine("Действие не указано!");
                            break;
                    }
                    break;

                case "3":
                    Console.WriteLine("Выберите одно из следующих действий:" + Environment.NewLine + "1 - Добавить Читателя" + Environment.NewLine + 
                        "2 - Просмотреть список читателей" + Environment.NewLine + "3 - Удалить Читателя");
                    var action3 = Console.ReadLine();
                    switch (action3)
                    {
                        case "1":
                            LibraryLogic.AddVisitor();
                            break;

                        case "2":
                            {
                                Console.WriteLine("Список читателей:");
                                LibraryLogic.GetVisitors();
                            }
                            break;

                        case "3":
                            {
                                Console.WriteLine("Укажите индекс читателя:");
                                LibraryLogic.RemoveVisitor(int.Parse(Console.ReadLine()));
                            }
                            break;

                        default:
                            Console.WriteLine("Действие не указано!");
                            break;
                    }
                    break;

            }
        }
    }
}
