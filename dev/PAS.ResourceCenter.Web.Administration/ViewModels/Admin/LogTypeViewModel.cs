using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Admin
{
    public class LogTypeViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(256, ErrorMessage = "Invalid data length.")]
        public string Name { get; set; }
    }
}