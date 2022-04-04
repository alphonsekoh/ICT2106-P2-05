using System;
using System.Linq;
using System.Collections.Generic;
using PainAssessment.Areas.Admin.Util;
using PainAssessment.Areas.Admin.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace PainAssessment.Areas.Admin.Services
{
    public sealed class TableUtilityService<T> : ITableUtilityService<T>
    {
        private readonly static double ITEM_PER_PAGE = 8.0;
        private readonly static string ORDER_BY = "OrderBy";
        private readonly static string ORDER_BY_DESC = "OrderByDescending";
        private TableUtilityService() { }

        private static readonly Lazy<TableUtilityService<T>> instance = new(() => new TableUtilityService<T>());

        public static TableUtilityService<T> GetInstance => instance.Value;

        string ITableUtilityService<T>.ORDER_BY_DESC => ORDER_BY_DESC;

        string ITableUtilityService<T>.ORDER_BY => ORDER_BY;

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
            string[] props = by.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);


            object result = typeof(Enumerable).GetMethods().Single(
              method => method.Name == sortOrder
                      && method.IsGenericMethodDefinition
                      && method.GetGenericArguments().Length == 2
                      && method.GetParameters().Length == 2)
              .MakeGenericMethod(typeof(T), type)
              .Invoke(null, new object[] { data, lambda.Compile() });

            return (IEnumerable<T>)result;
        }

        public IEnumerable<T> Search(IEnumerable<T> data, string search)
        {
            Type type = typeof(T);
            if (!String.IsNullOrEmpty(search))
            {
                if (type == typeof(Patient))
                {
                    data = (IEnumerable<T>)data.Cast<Patient>().Where(i => i.Name.ToLower().Contains(search.ToLower()));
                }
                else if (type == typeof(PracticeType))
                {
                    data = (IEnumerable<T>)data.Cast<PracticeType>().Where(i => i.Name.ToLower().Contains(search.ToLower()));
                }
                else if (type == typeof(Practitioner))
                {
                    data = (IEnumerable<T>)data.Cast<Practitioner>().Where(i => i.Name.ToLower().Contains(search.ToLower()));
                }
                else if (type == typeof(PainEducation))
                {
                    data = (IEnumerable<T>)data.Cast<PainEducation>().Where(i => i.Name.ToLower().Contains(search.ToLower()));
                }
                else if (type == typeof(ClinicalArea))
                {
                    data = (IEnumerable<T>)data.Cast<ClinicalArea>().Where(i => i.Name.ToLower().Contains(search.ToLower()));
                }
            }

            return data;
        }
    }
}
