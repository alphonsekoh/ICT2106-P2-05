using System;
using System.Linq;
using System.Collections.Generic;
using PainAssessment.Areas.Admin.Util;
using PainAssessment.Areas.Admin.Models;

namespace PainAssessment.Areas.Admin.Services
{
    public sealed class TableUltilityService<T> : ITableUltilityService<T>
    {
        private static double ITEM_PER_PAGE = 8.0;
        private TableUltilityService() { }

        private static readonly Lazy<TableUltilityService<T>> instance = new(() => new TableUltilityService<T>());

        public static TableUltilityService<T> GetInstance => instance.Value;

        public IEnumerable<T> getPageData(IEnumerable<T> data, int page)
        {
            if (data.Any())
            {
                return data.ChunkBy((int)Math.Round(ITEM_PER_PAGE)).ElementAt(page - 1);
            }
            return data;
        }

        public int getMaxPageCount(IEnumerable<T> data)
        {
            return (int)Math.Ceiling((decimal)(data.Count() / ITEM_PER_PAGE));
        }

        public int validateCurrentPage(int currentPage, IEnumerable<T> data)
        {
            int max_page = getMaxPageCount(data);

            if (currentPage > max_page)
            {
                currentPage = max_page;
            }

            if (currentPage < 1)
            {
                currentPage = 1;
            }

            return currentPage;
        }

        public IEnumerable<T> sort(IEnumerable<T> data, string by)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> search(IEnumerable<T> data, string search)
        {
            Type type = data.GetType().GetGenericArguments()[0];
            if (!String.IsNullOrEmpty(search))
            {
                // TODO: Fix for all types.
                if (type == typeof(Patient))
                {
                    data = (IEnumerable<T>)data.Cast<Patient>().Where(i => i.Name.ToLower().Contains(search.ToLower()));
                }
            }

            return data;
        }
    }
}
