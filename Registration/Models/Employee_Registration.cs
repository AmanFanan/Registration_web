using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class Employee_Registration
    {
        [Key]
        public int Employee_ID { get; set; }
        [Required]
        public string Employee_Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? Employee_Dob { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string State { get; set; }
        
        [Required]
        public string Hobbies { get; set; }
    }

  
}
