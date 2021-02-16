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
        public DbSet<AcademicViewModel> AcademicViewModel { get; set; }
        public DbSet<WorkViewModel> WorkViewModel { get; set; }
        public DbSet<ProjectsViewModel> ProjectsViewModel { get; set; }
    }
}
