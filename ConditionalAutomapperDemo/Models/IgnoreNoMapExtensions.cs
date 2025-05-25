using AutoMapper;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConditionalAutomapperDemo.Models
{
    public static class IgnoreNoMapExtensions
    {
        //Method is Generic and Hence we can use with any TSource and TDestination Type
        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            //Fetching type of the TSource
            var sourceType = typeof(TSource);

            foreach (var property in sourceType.GetProperties())
            {
                //Get the property name
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];

                //Check if property is decorated with NoMapAttribute
                NoMapAttribute attribute = (NoMapAttribute)descriptor.Attributes[typeof(NoMapAttribute)];

                if (attribute != null)
                {
                    //If Property is Decorated with NoMap Attribute, call the Ignore Method
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }

            }

            return expression;
        }
    }
}
