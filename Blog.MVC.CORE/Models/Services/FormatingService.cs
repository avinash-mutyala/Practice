using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.CORE.Models.Services
{
    public class FormatingService
    {

        public string AsShortDate(DateTime date)
        {
            return date.ToString("d");
        }
    }
}
