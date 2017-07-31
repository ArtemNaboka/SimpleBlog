using System.ComponentModel.DataAnnotations;

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

        [Required]
        [Display(Name = "Your age")]
        public string AgeRange { get; set; }

        [Required]
        [Display(Name = "How long have you been reading a blog")]
        public string HowLongReadBlog { get; set; }


    }
}