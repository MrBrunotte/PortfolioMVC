using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StefanBrunotteWebPage.Models
{
    public class AcademicViewModel
    {
        [Display(Name = "User ID")]
        public int Id { get; set; }
        [Required, Display(Name ="University")]
        public string UniversityName { get; set; }
        [Required, Display(Name ="Course")]
        public string CourseName { get; set; }
        [Required, Display(Name ="Description")]
        public string CourseCoversDescription { get; set; }
        [Required, Display(Name ="Experience Gained")]
        public string ExperienceGainedDescription { get; set; }
        [Required, Display(Name ="Start Date"), DataType(DataType.Date)]
        public DateTime CourseStartDate { get; set; }
        [Required, Display(Name ="End Date"), DataType(DataType.Date)]
        public DateTime CourseEndDate { get; set; }

        public AcademicViewModel()
        {

        }
    }
}
