using WebApplication2.Models;
using System.Collections.Generic;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services
{
    public class NewsService : INewsService
    {
        private readonly DbTestContext _context;

        public NewsService(DbTestContext context)
        {
            _context = context;
        }

        public int Save(News news)
        {
            _context.NewsList.Add(news);
            _context.SaveChanges();
            return news.Id;
        }

        public News Get(int id)
        {
            var news = _context.NewsList.Find(id);
            return news;
        }

        public List<News> GetAll()
        {
            var newsList = _context.NewsList.ToList();
            return newsList;
        }

        public int Delete(int id)
        {
            var news = _context.NewsList.Find(id);
            if (news != null)
            {
                _context.NewsList.Remove(news);
                _context.SaveChanges();
            }
            return id;
        }
        public List<Comment> GetAllcomment()
        {
            var commentList = _context.Comments.ToList();
            return commentList;
        }
    }
}