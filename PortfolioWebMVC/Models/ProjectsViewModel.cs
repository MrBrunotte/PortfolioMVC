using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebMVC.Models
{
    public class ProjectsViewModel
    {
        [Display(Name = "Project ID")]
        public int Id { get; set; }

        [Required, Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required, Display(Name = "Description")]
        public string ProjectDescription { get; set; }

        [Required, Display(Name = "Language/Framework/Tools")]
        public string FrameworkToolsDescription { get; set; }

        [Required, Display(Name = "GitHub Link")]
        public string GitHubLink { get; set; }

        [Required, Display(Name = "Website Link")]
        public string DeployedLink { get; set; }

        [NotMapped]
        [Display(Name ="Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
