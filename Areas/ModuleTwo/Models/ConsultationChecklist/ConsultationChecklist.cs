using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PainAssessment.Areas.ModuleTwo.Services;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class ConsultationChecklist
    {
        [Key]
        public int ChecklistId { get; set; }
        public int SessionId { get; set; }
        public string ChecklistName { get; set; }
        public string ChecklistDescription { get; set; }
        public double Weightage { get; set; }
        public bool UserEdit { get; set; }
        public double UserWeightage { get; set; }
        public virtual List<ConsultationCentralDomain> Central { get; set; } = new List<ConsultationCentralDomain>();//detail very important
        public virtual List<ConsultationRegionalDomain> Regional { get; set; } = new List<ConsultationRegionalDomain>();//detail very important
        public virtual List<ConsultationLocalDomain> Local { get; set; } = new List<ConsultationLocalDomain>();//detail very important
        public double InitialCentralWeight { get; set; }
        public double InitialRegionalWeight { get; set; }
        public double InitialLocalWeight { get; set; }
        public Boolean Overriden { get; set; }
        public double NewCentralWeight { get; set; }
        public double NewRegionalWeight { get; set; }
        public double NewLocalWeight { get; set; }

public void InitialiseBooleanAttribute(string attribute, bool value)
        {
            
        }

        public void InitialiseIntAttribute(string attribute, int value)
        {
            throw new NotImplementedException();
        }

        public void InitialiseStringAttribute(string attribute, string value)
        {
            if (attribute.Equals("ChecklistName"))
            {
                ChecklistName = value;
            }
        }

        public bool RetrieveBooleanAttribute(string attribute)
        {
            throw new NotImplementedException();
        }

        public int RetrieveIntAttribute(String attribute)
        {
            if (attribute.Equals("ChecklistId"))
            {
                return ChecklistId;
            }

            return 0;

        }

        public String RetrieveStringAttribute(String attribute)
        {
            if (attribute.Equals("ChecklistName"))
            {
                return ChecklistName;
            }

            else if (attribute.Equals("ChecklistDescription"))
            {
                return ChecklistDescription;

            }

            return "invalid attribute";
        }


    }
}
