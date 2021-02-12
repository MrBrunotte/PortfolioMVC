using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StefanBrunotteWebPage.Models;
using PortfolioWebMVC.Models;

namespace PortfolioWebMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StefanBrunotteWebPage.Models.AcademicViewModel> AcademicViewModel { get; set; }
        public DbSet<StefanBrunotteWebPage.Models.WorkViewModel> WorkViewModel { get; set; }
        public DbSet<PortfolioWebMVC.Models.ProjectsViewModel> ProjectsViewModel { get; set; }
    }
}
