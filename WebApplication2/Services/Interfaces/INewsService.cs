using WebApplication2.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface INewsService
    {
        int Save(News news);

        List<News> GetAll();
        News Get(int id);
        int Delete(int id);
        List<Comment> GetAllcomment();

    }
}
