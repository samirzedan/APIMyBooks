using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace APIMyBooks.Models
{
    public class Book
    {
        public Book(string title, string author, int totalPages, int currentPage, DateTime startedAt)
        {
            Title = title;
            Author = author;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            StartedAt = startedAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime FinishedAt { get; private set; }

        public void UpdateData(string title, string author, int totalPages, DateTime startedAt)
        {
            Title = title ?? string.Empty;
            Author = author ?? string.Empty;
            TotalPages = totalPages;
            StartedAt = startedAt;
        }

        public void finalizeBook() {
            CurrentPage = TotalPages;
            FinishedAt = DateTime.Now;
        }

        public void changeCurrentPage(int currentPage)
        {
            CurrentPage = currentPage;
            if (currentPage == TotalPages)
                FinishedAt = DateTime.Now;
        }
    }
}
