using System.Linq.Expressions;

namespace TeamSalesTrackerApi.Extensions
{
    public static class PaginationExtension
    {
        public static IQueryable<T> OrderByPropertyOrField<T>(
                this IQueryable<T> queryable,
                string propertyOrFieldName,
                bool ascending = true
            )
        {
            var elementType = typeof(T);
            var orderByMethodName = ascending ? "OrderBy" : "OrderByDescending";

            var parameterExpresion = Expression.Parameter(elementType);
            var propertyOrFieldExpresion = Expression.PropertyOrField(parameterExpresion, propertyOrFieldName);
            var selector = Expression.Lambda(propertyOrFieldExpresion, parameterExpresion);

            var orderByExpression = Expression.Call(typeof(Queryable), orderByMethodName,
                new[] { elementType, propertyOrFieldExpresion.Type},
                queryable.Expression, selector);

            return queryable.Provider.CreateQuery<T>(orderByExpression);
        }
    }
}
