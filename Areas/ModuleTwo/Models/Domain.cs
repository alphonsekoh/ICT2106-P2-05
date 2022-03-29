using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public abstract class Domain : IDomain
    {
        public string SubDomain { get; set; }
        public string Determinant { get; set; }
        public String Comment { get; set; }
        public int MaxValue { get; set; }
        public int ActualValue { get; set; }

        public int RetrieveIntAttribute(string attribute)
        {
            if (attribute.Equals("MaxValue"))
            {
                return MaxValue;
            }

            else if (attribute.Equals("ActualValue"))
            {
                return MaxValue;
            }
            else
            {
                return 0;
            }
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
            else if (attribute.Equals("Comment"))
            {
                return Comment;
            }
            else
            {
                return "Invalid";
            }
        }
    }
}
