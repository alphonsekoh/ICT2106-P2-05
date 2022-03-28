using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class RegionalDomain : Domain, IChecklist, IRegionalDomain
    {
        [Key]
        public int RowId { get; set; }

        [ForeignKey("Checklist")]//very important
        public int ChecklistId { get; set; }
        public virtual Checklist Checklist { get; private set; } //very important 

        //public string SubDomain { get; set; }
        //public string Determinant { get; set; }

        [NotMapped]
        public bool IsRegionalDeleted { get; set; } = false;

        public void InitialiseBooleanAttribute(string attribute, bool value)
        {
            throw new NotImplementedException();
        }

        //

        //public void InitialiseBooleanAttribute(string attribute, bool value)
        //{
        //    throw new NotImplementedException();
        //}

        public void InitialiseIntAttribute(string attribute, int value)
        {
            throw new NotImplementedException();
        }

        public void InitialiseStringAttribute(string attribute, string value)
        {
            throw new NotImplementedException();
        }

        public bool RetrieveBooleanAttribute(string attribute)
        {
            if (attribute.Equals("IsRegionalDeleted"))
            {
                return IsRegionalDeleted;
            }

            return false;
        }

        public int RetrieveIntAttribute(string attribute)
        {
            if (attribute.Equals("ChecklistId"))
            {
                return ChecklistId;
            }

            return 0;
        }

        public string RetrieveStringAttribute(string attribute)
        {
            if (attribute.Equals("SubDomain"))
            {
                return SubDomain;
            }

            else if (attribute.Equals("Determinant"))
            {
                return Determinant;
            }

            return "invalid attribute";
        }
    }
}
