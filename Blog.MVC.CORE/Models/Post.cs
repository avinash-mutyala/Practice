using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Blog.MVC.CORE.Models
{
    public class Post
    {
        public int Id { get; set; }

        private string _key;    
        public string key
        {
            get
            {
                if(_key ==null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

        [Display(Name = "Post Title")]
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Enter text from 5 to 100 characters")]
        public string Title { get; set; }
        public string Author { get; set; }

        public DateTime Posted { get; set; }

        [Display(Name = "Content")]
        [Required]
        [MinLength(100, ErrorMessage = "Enter atleast 100 characters")]
        [DataType(DataType.MultilineText)] //This will help HTMLEditor to decide on type of html control to render in UI
        public string Body { get; set; }
    }
}
