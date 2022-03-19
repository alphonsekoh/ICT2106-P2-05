using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Models
{
    public class Administrator
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        public Account Account { get; set; }
        [Required]
        public string FullName { get; set; }
        public int Experience { get; set; }
    }
}
