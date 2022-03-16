using System;

namespace PainAssessment.Models
{
    public class Administrator
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public string FullName { get; set; }
        public int Experience { get; set; }
    }
}
