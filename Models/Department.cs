using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Models
{
    public class Department
    {
        [Required]
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
