using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics;
using WebApplication2.Migrations;
using WebApplication2.Models;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

		private readonly UserManager<UserModel> _userManager;
		private readonly INewsService _newsService;
        private readonly DbTestContext _Context;

        public HomeController(INewsService newsService,DbTestContext context, UserManager<UserModel> userManager)

        {
			_userManager = userManager;
            _Context = context;
            _newsService = newsService;
           
        }
       
        [HttpGet]
        [Authorize]
        public IActionResult addnews() 
        {
            var USER = _userManager.GetUserAsync(User).Result;
            if (USER.IsAdmin)
            {
                return View();
            }
           
            return RedirectToAction("Index");
            
        }

        public IActionResult Index()
        {

            var USER = _userManager.GetUserAsync(User).Result;
            if (USER != null)
            {
                ViewBag.UserIsAdmin = USER.IsAdmin;
            }
            var newslist = _Context.NewsList.OrderByDescending(x => x.createdate).ToList();
            ViewBag.newslist = newslist;



            var images = _Context.Image.ToList();
            foreach (var News in _Context.NewsList)
            {

                foreach (var image in images)
                {
                    if (image.NewsId == News.Id)
                    {
                        News.Images.Add(image);
                    }
                }
                _Context.SaveChanges();
            }
            return View();
        }
      
        

        public IActionResult Privacy()
        { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult chooseNews()
        {
			var USER = _userManager.GetUserAsync(User).Result;
			if (USER != null)
			{
                ViewBag.UserData = USER;
                ViewBag.UserIsAdmin = USER.IsAdmin;
				var UserReadNews = _Context.UserReads
				.Where(x => x.UserId == USER.Id)
				.Include(x => x.News)
				.ToList();
                ViewBag.ReadNews = UserReadNews;
			}
			var NewsList = _newsService.GetAll();
            var images = _Context.Image.ToList();
            foreach (var News in _Context.NewsList)
            {

                foreach (var image in images)
                {
                    if (image.NewsId == News.Id)
                    {
                        News.Images.Add(image);
                    }
                }
                _Context.SaveChanges();
            }
           

            return View(NewsList);
        }
        [HttpPost]
        public IActionResult chooseNews(int selectedNewsId)
        {
            return RedirectToAction("currentNews", new { newsId = selectedNewsId });
        }


        [HttpGet]
        
        public IActionResult currentNews(int newsId)
        {
            var USER = _userManager.GetUserAsync(User).Result;
            if(USER != null)
            {
                ViewBag.UserIsAdmin = USER.IsAdmin;
                ViewBag.UserData = USER;
            }
            var news = _newsService.Get(newsId);
            //var news = _Context.NewsList.Include(n => n.Comments).FirstOrDefault(n => n.Id == newsId);
            ViewBag.Comments = _Context.Comments.Where(c => c.NewsId == newsId).ToList();
            var images = _Context.Image.Where(i => i.NewsId == newsId).ToList();

            if (User.Identity.IsAuthenticated)
			{
               
				
				var UserReadNews = _Context.UserReads
				.Where(x => x.UserId == USER.Id)
				.Include(x => x.News)
				.ToList();
				
				if (USER != null)
                {

                    var ReadNews = new UserRead
                    {
                        NewsId = newsId,
                        UserId = USER.Id
                    };
                    foreach(var News in UserReadNews)
                    {
                        if(News.NewsId == ReadNews.NewsId)
                        {
                            USER.ReadNews.Remove(News);
                            
                        }
                    }
                    USER.ReadNews.Add(ReadNews);
                    if (UserReadNews.Count == 0)
                    {
                        _Context.SaveChanges();
                    }
                    else
                    {
                        foreach (var userread in UserReadNews)
                        {
                            
                            if (userread.NewsId != newsId && userread != null)
                            {
                                _Context.SaveChanges();
                            }
                        }
                    }
                }
            }
            
            return View(news);
        }
        public IActionResult DisplayImage(int imageId)
        {
            var image = _Context.Image.FirstOrDefault(i => i.id == imageId);

            if (image == null)
            {
                return NotFound();
            }

            return File(image.image, "image/jpeg");
        }
        [HttpPost]
        public IActionResult currentNews() 
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult addnews(Models.News body, [FromForm] List<IFormFile> files)
        {
            var USER = _userManager.GetUserAsync(User).Result;
            if (USER.IsAdmin)
            {
                if (!ModelState.IsValid)
                {
                    return View(body);
                }
              
               
                    body.newCommentText = "";
                    
                if (files != null && files.Count > 0)
                {
                    foreach (var imageFile in HttpContext.Request.Form.Files)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            imageFile.CopyTo(memoryStream);

                            var image = new Image
                            {
                                image = memoryStream.ToArray(),
                                ContentType = imageFile.ContentType,
                                NewsId = body.Id


                            };
                            _Context.Image.Add(image);
                            

                        }
                    }
                }
                var Id = _newsService.Save(body);
                _Context.SaveChanges();
                return RedirectToAction("chooseNews", "Home");
                }
               
            
            return RedirectToAction("index");

        }
        public IActionResult deletenews(int id)
        {
            var USER = _userManager.GetUserAsync(User).Result;
            if (USER.IsAdmin)
            {
                var NewsList = _newsService.GetAll();
                if (!ModelState.IsValid)
                {
                    return View(NewsList);
                }

                _newsService.Delete(id);
                _Context.SaveChanges();
                return RedirectToAction("choosenews", "Home"); 
            }
            else
            {
                return RedirectToAction("choosenews", "Home");
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddComment(Models.News newsModel)
        {
            if(!ModelState.IsValid)
            {
                return View();

            }
            var comment = new Comment
            {
                creator = User.Identity.Name,
                CommentText = newsModel.newCommentText,
                NewsId = newsModel.Id
            };
            //var news = _newsService.Get(newsModel.Id);
            //news.Comments.Add(comment);
            _Context.Comments.Add(comment);
            _Context.SaveChanges();
            return RedirectToAction("choosenews", "Home");

            
        }
        [Authorize]
        public IActionResult EditNews(int id) 
        {
			var images = _Context.Image.Where(i => i.NewsId == id).ToList();
			return View(_newsService.Get(id));
        }
		
		[HttpPost]
        [Authorize]
		public IActionResult EditNews2(Models.News body,[FromForm] List<IFormFile> files) 
        {
            var USER = _userManager.GetUserAsync(User).Result;
			var images = _Context.Image.Where(i => i.NewsId == body.Id).ToList();
			if (USER.IsAdmin)
            {
                
                if (!ModelState.IsValid)
                {

					return RedirectToAction("Editnews", new { id = body.Id});
				}
                
                var newsToUpdate = _newsService.Get(body.Id);
                if (newsToUpdate != null)
                {
                    newsToUpdate.Title = body.Title;
                    newsToUpdate.Category = body.Category;
                    newsToUpdate.Content = body.Content;
                    _Context.SaveChanges();

                }
				if (files != null && files.Count > 0)
				{
					foreach (var imageFile in HttpContext.Request.Form.Files)
					{
						using (var memoryStream = new MemoryStream())
						{
							imageFile.CopyTo(memoryStream);

                            var image = new Image
                            {
                                image = memoryStream.ToArray(),
                                ContentType = imageFile.ContentType,
                                NewsId = body.Id


							};
							_Context.Image.Add(image);

						}
					}
				}
				

                _Context.SaveChanges();
                return RedirectToAction("choosenews");
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult UserReadNews()
        {
            var USER = _userManager.GetUserAsync(User).Result;
            if (USER != null)
            {
               
                var UserReadNews = _Context.UserReads
                .Where(x => x.UserId == USER.Id)
                .Include(x => x.News)
                .ToList();
                return View(UserReadNews);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Authorize]
        public IActionResult DeletePhoto(int imageId, Models.News body)
        {
           var image = _Context.Image.FirstOrDefault(i => i.id == imageId);
			if (image != null)
            {
                ///_newsService.Get(body.Id).Images.Remove(image);
                _Context.Image.Remove(_Context.Image.FirstOrDefault(i => i.id == imageId));
                _Context.SaveChanges();
				return RedirectToAction("EditNews", "Home", new { id = body.Id });
			}

			return RedirectToAction("EditNews", "Home", new { id = body.Id });
		}
    }
    
    
}