using System;
using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Admin
{
    public class LogViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public long Id { get; set; }

        public long LogSourceId { get; set; }

        public string LogSourceName { get; set; }

        public long LogTypeId { get; set; }

        public string LogTypeName { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Message { get; set; }

        public string CreatedByUserId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnString { get; set; }

        public string LinkURL { get; set; }
    }
}