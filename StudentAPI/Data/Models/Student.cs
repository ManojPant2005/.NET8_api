using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Data.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        [Required]
        public string Standard { get; set; }
        public string Address { get; set; } 
    }
}
