using System;
using System.ComponentModel.DataAnnotations;


namespace PainAssessment.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public string Type { get; set; }
        [Required]
        public int CentralWeight { get; set; }
        [Required]
        public int RegionalWeight { get; set; }
        [Required]
        public int LocalWeight { get; set; }

        public string Prescription { get; set; }

        public string Department { get; set; }

        public string Diagnosis { get; set; }

        public string Stage { get; set; }

        public string Notes { get; set; }


        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int PractitionerId { get; set; }

        public Practitioner Practitioner { get; set; }

        //public ConsultChecklist ConsultChecklist { get; set; }
    }
}