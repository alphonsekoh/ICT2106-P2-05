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

        public IEnumerable<T> GetPageData(IEnumerable<T> data, int page)
        {
            if (data.Any())
            {
                return data.ChunkBy((int)Math.Round(ITEM_PER_PAGE)).ElementAt(page - 1);
            }
            return data;
        }

        public int GetMaxPageCount(IEnumerable<T> data)
        {
            return (int)Math.Ceiling((decimal)(data.Count() / ITEM_PER_PAGE));
        }

        public int ValidateCurrentPage(int currentPage, IEnumerable<T> data)
        {
            int max_page = GetMaxPageCount(data);

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

        public IEnumerable<T> Sort(IEnumerable<T> data, string by, string sortOrder)
        {
            // TODO: Fix for all types.
            if (!String.IsNullOrEmpty(by))
            {
                if (data.GetType().GetGenericArguments()[0] == typeof(Patient))
                {
                    IEnumerable<Patient> patients = (IEnumerable<Patient>)(IEnumerable<T>)data.Cast<Patient>();

                    if (sortOrder == by)
                    {
                        patients = patients.OrderByDescending(i => i.Name);
                    }
                    else { patients = patients.OrderBy(i => i.Name); }

                    return (IEnumerable<T>)patients;
                }
            }

            return data;
        }

        public IEnumerable<T> Search(IEnumerable<T> data, string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                // TODO: Fix for all types.
                if (data.GetType().GetGenericArguments()[0] == typeof(Patient))
                {
                    data = (IEnumerable<T>)data.Cast<Patient>().Where(i => i.Name.ToLower().Contains(search.ToLower()));
                }
            }

            return data;
        }
    }
}
