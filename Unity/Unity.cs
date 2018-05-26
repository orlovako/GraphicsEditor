using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
namespace Unity
{
    /// <summary>
    /// Класс с DI-контейнером
    /// </summary>
    public class OrderedParametersOverride : ResolverOverride
    {
        private readonly Queue<InjectionParameterValue> parameterValues;

        public OrderedParametersOverride(IEnumerable<object> parameterValues)
        {
            this.parameterValues = new Queue<InjectionParameterValue>();
            foreach (var parameterValue in parameterValues)
            {
                this.parameterValues.Enqueue(InjectionParameterValue.ToParameter(parameterValue));
            }
        }

        /// <summary>
        /// Метод, упрощающий поиск служб и разрешение зависимостей.
        /// </summary>        
        public override IDependencyResolverPolicy GetResolver(IBuilderContext context, Type dependencyType)
        {
            if (parameterValues.Count < 1)
                return null;

            var value = this.parameterValues.Dequeue();
            return value.GetResolverPolicy(dependencyType);
        }
    }
}
