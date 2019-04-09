using System.ComponentModel.DataAnnotations;

namespace Sample.Web.Models
{
    public class SampleViewModel
    {
        public string Result { get; set; }

        [Required]
        public string Date { get; set; }
    }
}