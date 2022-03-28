using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public interface ITableUltilityService<T>
    {
        IEnumerable<T> GetPageData(IEnumerable<T> data, int page);
        int GetMaxPageCount(IEnumerable<T> data);
        int ValidateCurrentPage(int currentPage, IEnumerable<T> data);
        IEnumerable<T> Sort(IEnumerable<T> data, string by, string sortOrder);
        IEnumerable<T> Search(IEnumerable<T> data, string search);
    }
}
