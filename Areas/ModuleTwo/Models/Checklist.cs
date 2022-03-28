using PainAssessment.Areas.ModuleTwo.Iterator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public class Checklist : IChecklist
    {
        [Key]
        public int ChecklistId { get; set; }
        public int PractitionerId { get; set; }
        public int SessionId { get; set; }
        public string ChecklistName { get; set; }
        public string ChecklistDescription { get; set; }

        public virtual List<CentralDomain> Central { get; set; }
        //public virtual List<ICentralDomain> Central { get; set; }
        public virtual List<RegionalDomain> Regional { get; set; }
        public virtual List<LocalDomain> Local { get; set; }
        //public virtual Aggregate<CentralDomain> Central { get; set; } = new Aggregate<CentralDomain>();//detail very important
        //public virtual Aggregate<RegionalDomain> Regional { get; set; } = new Aggregate<RegionalDomain>();//detail very important
        //public virtual Aggregate<LocalDomain> Local { get; set; } = new Aggregate<LocalDomain>();//detail very important
        public double InitialCentralWeight { get; set; }
        public double InitialRegionalWeight { get; set; }
        public double InitialLocalWeight { get; set; }
        public Boolean Overriden { get; set; }
        public double NewCentralWeight { get; set; }
        public double NewRegionalWeight { get; set; }
        public double NewLocalWeight { get; set; }
        public Boolean Active { get; set; }

        public Checklist()
        {
            //this.PractitionerId = 0;
            //this.SessionId = 0;
            this.Overriden = false;
            this.NewCentralWeight = 0;
            this.NewRegionalWeight = 0;
            this.NewLocalWeight = 0;
            this.Active = true;

            BuildCentral();
            BuildRegional();
            BuildLocal();

        }

        public void BuildCentral()
        {
            Central = new List<CentralDomain>();
        }
        public void BuildRegional()
        {
            Regional = new List<RegionalDomain>();
        }
        public void BuildLocal()
        {
            Local = new List<LocalDomain>();
        }


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
