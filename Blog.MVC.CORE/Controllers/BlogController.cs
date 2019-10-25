using Blog.MVC.CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blog.MVC.CORE.Controllers
{
    //[Route("Blog")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post(int year, int month, string title)
        {
            var post = new Post()
            {
                Author = "Avinash",
                Posted = DateTime.Now,
                Body = "Rain is pouring in Mumbai",
                Title = "Weather here"
            };


            return View(post);
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