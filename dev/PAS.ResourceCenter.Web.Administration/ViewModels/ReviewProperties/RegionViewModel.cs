using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.ReviewProperties
{
    public class RegionViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string SubRegions { get; set; }

        public string DivEditId { get; set; }

        public string DivPurgeId { get; set; }
    }
}