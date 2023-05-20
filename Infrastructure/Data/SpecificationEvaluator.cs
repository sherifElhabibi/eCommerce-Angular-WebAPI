//using Core.Entities;
//using eCommerce.Specifications;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Data
//{
//    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
//    {
//        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
//        {
//            var query = inputQuery;
//            if (spec.OrderBy != null)
//            {
//                query = query.OrderBy(spec.OrderBy);
//            }
//            if (spec.OrderByDescending != null)
//            {
//                query = query.OrderBy(spec.OrderByDescending);
//            }
//            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
//            return query;
//        }
//    }
//}
