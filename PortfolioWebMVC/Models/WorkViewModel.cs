using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StefanBrunotteWebPage.Models
{
    public class WorkViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required, Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Required, Display(Name = "Description")]
        public string WorkDescription { get; set; }

        [Required, Display(Name = "Experience")]
        public string WorkExperienceGainedDescription { get; set; }

        [Required, Display(Name = "Start Date"), DataType(DataType.Date)]
        public DateTime WorkStartDate { get; set; }

        [DefaultValue("Ongoing")]
        [Display(Name = "End Date"), DataType(DataType.Date)]
        public DateTime WorkEndDate { get; set; }

        public WorkViewModel()
        {

        }
    }
}
