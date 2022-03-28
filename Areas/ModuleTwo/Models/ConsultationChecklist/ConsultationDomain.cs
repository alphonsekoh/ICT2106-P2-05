using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public abstract class ConsultationDomain
    {
        public string SubDomain { get; set; }
        public string Determinant { get; set; }
        public string Comment { get; set; }
        public int MaxValue { get; set; }
        public int ActualValue { get; set; }
    }
}
