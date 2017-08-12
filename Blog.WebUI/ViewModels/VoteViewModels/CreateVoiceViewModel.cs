using System.Collections.Generic;
using Blog.Business.Infrastructure;

namespace Blog.WebUI.ViewModels.VoteViewModels
{
    public class CreateVoiceViewModel
    {
        public NetTechnologies Answer { get; set; }
        public Dictionary<NetTechnologies, string> RadioAnswersAndLabels { get; set; }
    }
}