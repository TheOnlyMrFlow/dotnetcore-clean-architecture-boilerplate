using DomainValidationCore.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBoilerplate.Domain.Validators.Specifications
{
    internal class IsNotNullish<TEntity> : ISpecification<TEntity>
    {
        private readonly Expression<Func<TEntity, object>> _expression;

        public IsNotNullish(Expression<Func<TEntity, object>> expression)
        {
            _expression = expression;
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            var value = _expression.Compile()(entity);
            var type = value.GetType();

            if (type.Equals(typeof(string)))
                return !string.IsNullOrEmpty(value as string);
            else if (type.Equals(typeof(int)))
                return ((int)value) > 0;
            else if (type.Equals(typeof(DateTime)))
                return !((DateTime)value).Equals(DateTime.MinValue);

            return value != null;
        }
    }
}
