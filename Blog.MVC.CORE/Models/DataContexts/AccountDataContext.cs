using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.MVC.CORE.Models.DataContexts
{
    public class AccountDataContext:IdentityDbContext<IdentityUser>
    {
        public AccountDataContext(DbContextOptions<AccountDataContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
