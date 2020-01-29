using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApp.Models
{
    public class Developer
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Developer Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Developer Age")]
        [Range(18,50, ErrorMessage = "Developer's Age can be between 18 and 50")]
        public int Age { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
    }
}
