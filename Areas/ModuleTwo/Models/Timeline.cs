using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Timeline
    {
        
        public int Id { get; set; } 
        //*** Consultation Entity Dummy Init ***//
        [Display(Name = "consultationId")]
        public int consultationId { get; set; } 
        [Display(Name = "status")]
        public string status { get; set; }
        [Display(Name = "description")]
        public string description { get; set; }
        [Display(Name = "createdAt")]
        [DataType(DataType.Date)]
        public DateTime createdAt { get; set; }
        [Display(Name = "closedAt")]
        [DataType(DataType.Date)]
        public DateTime closedAt { get; set; }
        [Display(Name = "practitionerId")]
        public int practitionerId{ get; set; }
        
        //Practitioner: practitioner object TBC

        [Display(Name = "patientId")]
        public int patientId { get; set; }
        //patient: Patient object TBC
        [Display(Name = "clinicalArea")]
        public string clinicalArea { get; set; }
        // ICollection<ConsultationSession> : sessionList
        // Consultation: Constructor

        //*** Session Entity Dummy Init//
        [Display(Name = "sessionId")]
        public int sessionId { get; set; }
        //[Display(Name = "consultationId")]
        //public int consultationId { get; set; }
        //dateTime createdAt
        //consultation: Consultation
        public string memo { get; set; }
        //Session: Constructor



    }
}