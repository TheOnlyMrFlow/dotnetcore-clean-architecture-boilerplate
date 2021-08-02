using System;

namespace NetCoreBoilerplate.Domain.ValueObjects
{
    public interface IValueObject<TSelf>: 
        IComparable,
        IComparable<TSelf>,
        IEquatable<TSelf>
        where TSelf : IValueObject<TSelf>
    {
    }
}
