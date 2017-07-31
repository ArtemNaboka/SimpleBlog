using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class HowLongReadBlogViewModel
    {
        [Required]
        [Display(Name = "How long have you been reading a blog")]
        public string Value { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ValuesAndLabels { get; set; }
    }
}