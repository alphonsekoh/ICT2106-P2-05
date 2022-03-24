using System.Collections.Generic;
using PainAssessment.Areas.Admin.Models;

namespace PainAssessment.Areas.Admin.Services
{
    //public interface ITableUltilityService
    //{
    //    IEnumerable<T> getPageData(IEnumerable<T> patients, int page);
    //    IEnumerable<Patient> getMaxPageCount(IEnumerable<Patient> patients);
    //}
    public interface ITableUltilityService<T>
    {
        IEnumerable<T> getPageData(IEnumerable<T> data, int page);
        IEnumerable<T> getMaxPageCount(IEnumerable<T> data);
    }
}
