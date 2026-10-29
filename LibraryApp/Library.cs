using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
namespace LibraryApp
{
    public class Library
    {
        private readonly List<Book> _books = new List<Book>();
        public IReadOnlyList<Book> GetBooks()
        {
            return _books.AsReadOnly();
        }
        public void AddBook(Book book)
        {
            ArgumentNullException.ThrowIfNull(book);
            if (FindBook(book.Id) != null)
            {
                throw new InvalidOperationException($"Книга с ID {book.Id} уже есть в библиотеке.");
            }
            _books.Add(book);
        }
        public void BorrowBook(int id)
        {
            if (!TryGetBook(id, out var book))
            {
                return;
            }
            if (!book.IsAvailable)
            {
                Console.WriteLine($"Ошибка: книга '{book.Title}' уже выдана.");
                return;
            }
            book.IsAvailable = false;
            Console.WriteLine($"Книга '{book.Title}' выдана.");
        }
        public void ReturnBook(int id)
        {
            if (!TryGetBook(id, out var book))
            {
                return;
            }
            if (book.IsAvailable)
            {
                Console.WriteLine($"Ошибка: книга '{book.Title}' не была выдана.");
                return;
            }
            book.IsAvailable = true;
            Console.WriteLine($"Книга '{book.Title}' возвращена.");
        }
        public Book? FindBook(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }
        private bool TryGetBook(int id, [NotNullWhen(true)] out Book? book)
        {
            book = FindBook(id);
            if (book == null)
            {
                Console.WriteLine($"Ошибка: книга с ID {id} не найдена.");
                return false;
            }
            return true;
        }
    }
}
