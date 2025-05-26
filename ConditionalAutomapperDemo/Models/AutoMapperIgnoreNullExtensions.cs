using AutoMapper;
using System.Runtime.CompilerServices;

namespace ConditionalAutomapperDemo.Models
{
    public static class AutoMapperIgnoreNullExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNull<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            expression.ForAllMembers(options =>
            {
                options.Condition((src, dest, srcMember) => srcMember != null);
            });

            return expression;
        }
    }
}
