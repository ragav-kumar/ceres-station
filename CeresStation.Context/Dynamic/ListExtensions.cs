using System.Linq.Expressions;
using System.Reflection;

namespace CeresStation.Core;

public static class ListExtensions
{
    /// <summary>
    /// Return IQueryable&lt;dynamic&gt; where each row only includes those fields which are in fieldNames.
    /// Throws an exception if given field name is not in q.
    /// </summary>
    /// <param name="q">The active query</param>
    /// <param name="fieldNames">Column fields to filter by</param>
    /// <returns></returns>
    public static IQueryable ColumnSelect(this IQueryable q, IList<string> fieldNames)
    {
        Type elementType = q.ElementType;

        // Fetch the set of properties
        List<PropertyInfo> selectedProperties = elementType
            .GetProperties()
            .Where(p => fieldNames.Contains(p.Name))
            .ToList();

        if (selectedProperties.Count != fieldNames.Count)
        {
            throw new InvalidOperationException($"fields don't correspond to properties in {elementType.Name}");
        }

        // Construct the Select lambda
        ParameterExpression parameter = Expression.Parameter(elementType, "o");
        
        // the body of the RHS of the Select
        List<MemberAssignment> bindings = selectedProperties
            .Select(p => Expression.Bind(p, Expression.Property(parameter, p.Name)))
            .ToList();
        
        // the whole of the RHS of the Select
        MemberInitExpression newExpression = Expression.MemberInit(Expression.New(elementType), bindings);
        
        // o => new { o.Prop1, o.Prop2 }
        LambdaExpression lambda = Expression.Lambda(newExpression, parameter);
        
        object? result = typeof(IQueryable)
            .GetMethods()
            .First(m => m.Name == "Select" && m.GetParameters().Length == 2)
            .MakeGenericMethod(elementType)
            .Invoke(null, [q, lambda]);

        if (result is null)
        {
            throw new InvalidOperationException($"Can't create an instance of {elementType.Name}.");
        }
        
        return (IQueryable)result;
    }
}
