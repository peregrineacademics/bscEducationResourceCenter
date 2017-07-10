using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties
{
    public class SubRegionsViewModel
    {
        [Required(ErrorMessage = "Region Id is required.")]
        public long RegionId { get; set; }

        [Required(ErrorMessage = " Region Name is required.")]
        public string RegionName { get; set; }

        public List<SubRegionViewModel> SubRegions { get; set; }
    }
}