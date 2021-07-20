using iQuest.BooksAndNews.Application.Publications;

namespace iQuest.BooksAndNews.Application.DataAccess
{
    public interface IBookRepository
    {
        Book GetRandom();
    }
}