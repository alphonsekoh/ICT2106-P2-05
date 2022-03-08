using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Util
{
    public static class Utility
    {
        // Helper to mask names
        public static string MaskName(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3)
                return value;
            else if (value.Length <= 4)
                return value.Substring(0, 2) +
                       new string('*', value.Length - 2);
            else
                return value.Substring(0, 2) +
                       new string('*', value.Length - 3) +
                       value.Substring(value.Length - 1);
        }
    }
}
