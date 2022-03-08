using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.Admin.Util
{
    public interface ILog
    {
        void LogMessage(string area, string type,string message);
       
    }
}
