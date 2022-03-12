using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Checklist : IChecklist
    {
        [Key]
        public int ChecklistId { get; set; }
        public string ChecklistName { get; set; }
        public string ChecklistDescription { get; set; }

        public virtual List<CentralDomain> Central { get; set; } = new List<CentralDomain>();//detail very important
        public virtual List<RegionalDomain> Regional { get; set; } = new List<RegionalDomain>();//detail very important
        public virtual List<LocalDomain> Local { get; set; } = new List<LocalDomain>();//detail very important

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
