using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Infrastructure;

namespace Blog.ViewModels
{
    public class InterestingsViewModel
    {
        [Display(Name = "Many code examples")]
        public bool ManyCodeExamples { get; set; }

        [Display(Name = "The most relevant technologies")]
        public bool RelevantTechnologies { get; set; }

        [Display(Name = "Expirienced authors")]
        public bool ExpiriencedAuthors { get; set; }

        [Display(Name = "Other")]
        public bool Other { get; set; }
    }
}