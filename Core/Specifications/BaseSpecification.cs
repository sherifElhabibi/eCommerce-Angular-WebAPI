//using System.Linq.Expressions;

//namespace eCommerce.Specifications
//{
//    public class BaseSpecification<T> : ISpecification<T>
//    {
//        public BaseSpecification()
//        {
            
//        }
//        public Expression<Func<T, object>> OrderBy { get; private set; }

//        public Expression<Func<T, object>> OrderByDescending { get; private set; }

//        public Expression<Func<T, object>> Criteria { get; }

//        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
//        public void AddIncludes(Expression<Func<T, object>> includeExpression)
//        {
//            Includes.Add(includeExpression);
//        }
//        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
//        {
//            OrderBy = orderByExpression;
//        }
//        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
//        {
//            OrderByDescending = orderByDescExpression;
//        }
//    }
//}
