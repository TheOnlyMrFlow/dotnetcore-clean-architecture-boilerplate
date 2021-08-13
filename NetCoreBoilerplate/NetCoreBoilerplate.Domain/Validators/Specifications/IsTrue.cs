using DomainValidationCore.Interfaces.Specification;
using System;
using System.Linq.Expressions;

namespace NetCoreBoilerplate.Domain.Validators.Specifications
{
    internal class IsTrue<TEntity> : ISpecification<TEntity>
    {
        private readonly Expression<Func<TEntity, bool>> _expression;

        public IsTrue(Expression<Func<TEntity, bool>> expression)
        {
            _expression = expression;
        }

        public bool IsSatisfiedBy(TEntity entity) => _expression.Compile()(entity);
    }
}
