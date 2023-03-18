using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Realta.Persistence.Repositories.RepositoryExtensions
{
    public static class RepositoryVenProExtension
    {
        public static IQueryable<VendorProduct> Search(this IQueryable<VendorProduct> venpro, string Keyword)
        {
            if (string.IsNullOrWhiteSpace(Keyword))
                return venpro;

            var lowerCaseSearchTerm = Keyword.Trim().ToLower();

            return venpro.Where(p => p.StockName.ToLower().Contains(lowerCaseSearchTerm));
        }

   
        public static IQueryable<VendorProduct> Sort(this IQueryable<VendorProduct> venpro, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return venpro.OrderBy(e => e.VeproId);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(VendorProduct).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith("desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return venpro.OrderBy(e => e.StockName);

            var abc = venpro.OrderBy(orderQuery);
            return venpro.OrderBy(orderQuery);
        }

    }
}
