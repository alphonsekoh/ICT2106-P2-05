using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    interface IChecklist
    {
        public int RetrieveIntAttribute(String attribute);
        public String RetrieveStringAttribute(String attribute);
        public Boolean RetrieveBooleanAttribute(String attribute);

        public void InitialiseIntAttribute(String attribute, int value);
        public void InitialiseStringAttribute(String attribute, String value);
        public void InitialiseBooleanAttribute(String attribute, bool value);
    }
}
