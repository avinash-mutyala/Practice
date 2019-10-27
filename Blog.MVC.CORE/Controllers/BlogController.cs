using Blog.MVC.CORE.Models;
using Blog.MVC.CORE.Models.DataContexts;
using Blog.MVC.CORE.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blog.MVC.CORE.Controllers
{
    [Route("Blog")]
    public class BlogController : Controller
    {
        private readonly BlogDataContext blogContext;

        public BlogController(BlogDataContext blogContext)
        {
            this.blogContext = blogContext;
        }
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = blogContext.Posts.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                blogContext.Posts
                    .OrderByDescending(x => x.Posted)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToList();

            return View(posts);
        }

        [Route("{year:int}/{month:range(1,12)}/{title}")]
        public IActionResult Post(int year, int month, string title)
        {
            var post = this.blogContext.Posts.FirstOrDefault(x => x.key == title);

            return View(post);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([Bind("Title", "Body")]Post post) //([FromForm]Post details)
        {
            if(!ModelState.IsValid)
            {
                //Log error or return to view
                return View();
            }
            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            this.blogContext.Posts.Add(post);
            this.blogContext.SaveChanges();

            return View();
        }

        [Route("post/{title}")]
        public IActionResult Show(string title, int id)
        {

            //if(!id.HasValue)
            //{
            //    throw new System.Exception();
            //}
            return new ContentResult { Content =  title };
        }
    }
}