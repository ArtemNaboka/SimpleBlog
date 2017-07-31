using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class AgeRangeViewModel
    {
        [Required]
        [Display(Name = "Your age")]
        public string Value { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ValuesAndLabels { get; set; }
    }
}