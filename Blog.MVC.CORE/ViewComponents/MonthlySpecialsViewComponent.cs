using Blog.MVC.CORE.Models.DataContexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.CORE.ViewComponents
{
    public class MonthlySpecialsViewComponent:ViewComponent
    {
        private readonly BlogDataContext blogData;

        public MonthlySpecialsViewComponent(BlogDataContext blogData)
        {
            this.blogData = blogData;
        }
        public IViewComponentResult Invoke()
        {
            return View(this.blogData.GetMonthlySpecials().ToList());
        }
    }
}
