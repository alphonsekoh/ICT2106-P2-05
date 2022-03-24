using System.Collections.Generic;

namespace PainAssessment.Areas.Admin.Services
{
    public interface ITableUltilityService<T>
    {
        IEnumerable<T> getPageData(IEnumerable<T> data, int page);
        int getMaxPageCount(IEnumerable<T> data);
        int validateCurrentPage(int currentPage, IEnumerable<T> data);
        IEnumerable<T> sort(IEnumerable<T> data, string by);
        IEnumerable<T> search(IEnumerable<T> data, string search);
    }
}
