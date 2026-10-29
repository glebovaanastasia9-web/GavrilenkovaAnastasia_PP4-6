using System;
namespace LibraryApp
{
    internal static class Program
    {
        private static void Main()
        {
            var library = new Library();
            FillLibrary(library);
            RunBasicScenario(library);
            RunRepeatedBorrowScenario(library);
            RunReturnNotBorrowedScenario(library);
            RunMissingBookScenario(library);
            RunDuplicateIdScenario(library);
            PrintBooks(library);
        }
        private static void FillLibrary(Library library)
        {
            library.AddBook(new Book { Id = 1, Title = "Война и мир", Author = "Л. Н. Толстой" });
            library.AddBook(new Book { Id = 2, Title = "Преступление и наказание", Author = "Ф. М. Достоевский" });
            library.AddBook(new Book { Id = 3, Title = "Мастер и Маргарита", Author = "М. А. Булгаков" });
        }
        private static void RunBasicScenario(Library library)
        {
            Console.WriteLine("Базовый сценарий: выдача и возврат");
            library.BorrowBook(1);
            library.ReturnBook(1);
        }
        private static void RunRepeatedBorrowScenario(Library library)
        {
            Console.WriteLine("Сценарий 2: повторная выдача книги 2");
            library.BorrowBook(2);
            library.BorrowBook(2);
        }
        private static void RunReturnNotBorrowedScenario(Library library)
        {
            Console.WriteLine("Сценарий 3: возврат книги 3, которая не выдавалась");
            library.ReturnBook(3);
        }
        private static void RunMissingBookScenario(Library library)
        {
            Console.WriteLine("Сценарий 1: выдача книги 99, которой нет в библиотеке");
            library.BorrowBook(99);
        }
        private static void RunDuplicateIdScenario(Library library)
        {
            Console.WriteLine("Дополнительно: добавление книги с уже существующим ID");
            try
            {
                library.AddBook(new Book { Id = 1, Title = "Дубликат", Author = "Неизвестен" });
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        private static void PrintBooks(Library library)
        {
            Console.WriteLine("Состояние книг:");
            foreach (var book in library.GetBooks())
            {
                Console.WriteLine($"{book.Id}. {book.Title} - {(book.IsAvailable ? "доступна" : "выдана")}");
            }
        }
    }
}
