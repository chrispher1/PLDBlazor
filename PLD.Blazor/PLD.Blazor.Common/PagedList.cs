using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Microsoft.e

namespace PLD.Blazor.Common
{
    public class PagedList<T>: List<T>
    {
        public int TotalCount { get; set; } = 0;

        public PagedList()
        {

        }
        public PagedList(List<T> items)
        {
            this.AddRange(items);
            TotalCount = items.Count();
        }
        public PagedList(List<T> items, int count)
        {
            TotalCount = count;            
            this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, totalCount);
        }
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source)
        {
            var items = await source.ToListAsync();
            return new PagedList<T>(items);
        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, totalCount);
        }

        public static PagedList<T> Create(IQueryable<T> source)
        {
            var items = source.ToList();
            return new PagedList<T>(items);
        }

        

        public static IEnumerable<T> OrderBy<T>(IEnumerable<T> input, string sortString)
        {
            if (string.IsNullOrEmpty(sortString))
                return input;

            int i = 0;
            foreach (string propName in sortString.Split(','))
            {
                var subContent = propName.Split('|');
                if (Convert.ToInt32(subContent[1].Trim()) == 0)
                {
                    if (i == 0)
                        input = input.OrderBy(x => GetPropertyValue(x, subContent[0].Trim()));
                    else
                        input = ((IOrderedEnumerable<T>)input).ThenBy(x => GetPropertyValue(x, subContent[0].Trim()));
                }
                else
                {
                    if (i == 0)
                        input = input.OrderByDescending(x => GetPropertyValue(x, subContent[0].Trim()));
                    else
                        input = ((IOrderedEnumerable<T>)input).ThenByDescending(x => GetPropertyValue(x, subContent[0].Trim()));
                }
                i++;
            }

            return input;
        }

        private static object GetPropertyValue(object obj, string property)
        {
            System.Reflection.PropertyInfo? propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo?.GetValue(obj ?? new object(), null) ?? new object();
        }
    }
}
