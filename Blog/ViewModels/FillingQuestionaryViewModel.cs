﻿using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class FillingQuestionaryViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Your city")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Wishes for the blog")]
        public string Wishes { get; set; }

        public AgeRangeViewModel AgeRange { get; set; } = new AgeRangeViewModel();

        public HowLongReadBlogViewModel HowLongReadBlog { get; set; } = new HowLongReadBlogViewModel();

        public InterestingsViewModel Interestings { get; set; } = new InterestingsViewModel();
    }
}