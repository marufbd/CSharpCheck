using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCheck.Specification
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T candidate);
    }

    internal class AndSpecification<T>:ISpecification<T>
    {
        private readonly ISpecification<T> _spec1, _spec2;

        public AndSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            _spec1 = spec1;
            _spec2 = spec2;
        }
        
        public bool IsSatisfiedBy(T candidate)
        {
            return _spec1.IsSatisfiedBy(candidate) && _spec2.IsSatisfiedBy(candidate);
        }
    }

    internal class OrSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _spec1, _spec2;

        public OrSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            _spec1 = spec1;
            _spec2 = spec2;
        }

        public bool IsSatisfiedBy(T candidate)
        {
            return _spec1.IsSatisfiedBy(candidate) || _spec2.IsSatisfiedBy(candidate);
        }
    }

    internal class NotSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _spec;

        public NotSpecification(ISpecification<T> spec)
        {
            _spec = spec;            
        }

        public bool IsSatisfiedBy(T candidate)
        {
            return !_spec.IsSatisfiedBy(candidate);
        }
    }



}
