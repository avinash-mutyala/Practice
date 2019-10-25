using System;

namespace Blog.MVC.CORE.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public DateTime Posted { get; set; }
        public string Body { get; set; }
    }
}
