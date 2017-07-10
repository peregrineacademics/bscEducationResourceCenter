using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties
{
    public class TopicViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public long TopicId { get; set; }

        [Required(ErrorMessage = " Discipline Id is required.")]
        public long DisciplineId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string DivEditId { get; set; }

        public string DivPurgeId { get; set; }
    }
}