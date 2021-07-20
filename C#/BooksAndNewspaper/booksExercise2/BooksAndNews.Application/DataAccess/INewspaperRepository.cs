using iQuest.BooksAndNews.Application.Publications;

namespace iQuest.BooksAndNews.Application.DataAccess
{
    public interface INewspaperRepository
    {
        Newspaper GetRandom();
    }
}