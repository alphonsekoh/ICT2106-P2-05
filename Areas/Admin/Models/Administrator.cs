using Microsoft.AspNetCore.Mvc;
using PainAssessment.Areas.Admin.Models.ModelBinder;
using PainAssessment.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.Admin.Models
{
    [ModelBinder(typeof(AdminModelBinder))]
    public class Administrator
    {
        [Key]
        public Guid AdminId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public DateTime DOB { get; set; }
        public int ClinicalAreaID { get; set; }
        public string ClinicalArea { get; set; }
        public string Experience { get; set; }

        public Administrator(string name, string fullName, string role, string experience, int clinicalAreaID, DateTime date, Guid id)
        {
            Name = name;
            FullName = fullName;
            Role = role;
            Experience = experience;
            ClinicalAreaID = clinicalAreaID;
            DOB = date;
            AdminId = id;
        }
        
        public Administrator(string name, string fullName, string role, string experience, int clinicalAreaID, DateTime date)
        {
            FullName = fullName;
            Name = name;
            Role = role;
            Experience = experience;
            ClinicalAreaID = clinicalAreaID;
            DOB = date;
        }
        public Administrator()
        {
        }
    }
}
