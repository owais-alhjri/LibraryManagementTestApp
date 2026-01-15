
using LMS.Domain.Enums;

namespace LMS.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }

        public BookState BookState { get; private set; } = BookState.Available;

        private Book() { }

        public Book(string title, string author)
        {
            title = title.Trim();
            author = author.Trim();

            ValidateTitle(title);
            ValidateAuthor(author);

            Id = Guid.NewGuid();
            Title = title;
            Author = author;
        }

        private static void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty");
            }

            if (title.Length < 3 || title.Length > 50)
            {
                throw new ArgumentException("Title must be in range of 3 to 50 characters");
            }
        }

        private static void ValidateAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be empty");
            }

            if (author.Length < 3 || author.Length > 50)
            {
                throw new ArgumentException("Author must be in range of 3 to 50 characters");
            }
        }

        public void Borrow()
        {
            if (BookState == BookState.Borrowed)
               throw new InvalidOperationException("Book is already borrowed");
            
            BookState = BookState.Borrowed;
        }

        public void Return()
        {
            if (BookState == BookState.Available)
                throw new InvalidOperationException("Book is not borrowed");

            BookState = BookState.Available;
        }
        public void UpdateBook(string? title, string? author, BookState? state)
        {
            if (title != null)
                Title = title;

            if (author != null)
                Author = author;

            if (state.HasValue)
                BookState = state.Value;

        }

    }

}
