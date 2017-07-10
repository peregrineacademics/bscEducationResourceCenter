using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties
{
    public class SubRegionViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public long SubRegionId { get; set; }

        [Required(ErrorMessage = "Region Id is required.")]
        public long RegionId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string DivEditId { get; set; }

        public string DivPurgeId { get; set; }
    }
}