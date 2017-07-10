using System.ComponentModel.DataAnnotations;

namespace PAS.ResourceCenter.Web.Administration.ViewModels.Admin
{
    public class SettingViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value1 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value2 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value3 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value4 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value5 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value6 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value7 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value8 { get; set; }

        public string DisplayName { get; set; }

        public string Notes { get; set; }

        public bool Password { get; set; }

        public bool Boolean { get; set; }

        public bool Collection { get; set; }

        public string CollectionValue { get; set; }

        public string DivEditId { get; set; }
    }
}