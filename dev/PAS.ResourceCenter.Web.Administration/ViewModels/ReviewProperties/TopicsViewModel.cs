using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties
{
    public class TopicsViewModel
    {
        [Required(ErrorMessage = " Discipline Id is required.")]
        public long DisciplineId { get; set; }

        [Required(ErrorMessage = " Discipline Name is required.")]
        public string DisciplineName { get; set; }

        public List<TopicViewModel> Topics { get; set; }
    }
}