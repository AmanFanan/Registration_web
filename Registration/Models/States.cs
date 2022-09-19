using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class States
    {
        [Key]
        public int ID { get; set; }
        
        public string Name { get; set; }
       
        
    }
}
