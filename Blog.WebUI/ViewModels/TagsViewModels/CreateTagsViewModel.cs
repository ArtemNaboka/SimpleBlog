using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.ViewModels.TagsViewModels
{
    public class CreateTagsViewModel
    {
        [Required]
        [StringLength(500, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Tags")]
        public string AllTags { get; set; }
    }
}