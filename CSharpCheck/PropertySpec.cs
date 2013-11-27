using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCheck
{
    public class PropertySpec
    {
        private readonly IPropArg _propArg;
        private string _report = "Not yet checked, to see result call 'Check' method";

        internal PropertySpec(IPropArg propArg)
        {
            _propArg = propArg;
        }

        public void Check()
        {
            var type = _propArg.GetType();
            var paramCount = type.GetGenericArguments().Count();

            int cnt = 0;
            bool passed = false;
            foreach (var v in _propArg.GetValues())
            {
                switch (paramCount)
                {
                    case 1:
                        passed = _propArg.Prop.Invoke(v.Item1);
                        break;
                    case 2:
                        passed = _propArg.Prop.Invoke(v.Item1, v.Item2);
                        break;
                    default:
                        throw new TestFailedException("Not supported these many params");
                }
                if (!passed && _propArg.Quntifier==Quantifier.ForAll)
                {
                    _report = String.Format("! Failed after {0} tests, for value: {1}", cnt, v);
                    throw new TestFailedException(_report);
                }
                if (passed && _propArg.Quntifier == Quantifier.ThereExists)
                {
                    break;                    
                }
                
                cnt++;
            }
            if (!passed && _propArg.Quntifier == Quantifier.ThereExists)
            {
                _report = String.Format("! Failed after trying with {0} values, there exists no such value", cnt);
                throw new TestFailedException(_report);
            }

            _report = String.Format("OK, passed {0} tests.", cnt);
        }

        public override string ToString()
        {
            return _report;
        }
    }

    interface IPropArg
    {
        IEnumerable<dynamic> GetValues();
        dynamic Prop { get; }
        void SetPredicate(dynamic predicate);

        Quantifier Quntifier { get; set; }
    }

    class PropArg<T, T1>:IPropArg
    {
        public IEnumerable<T> Gen1 { get; set; }
        public IEnumerable<T1> Gen2 { get; set; }

        public Func<T, T1, bool> Predicate { get; set; }
        public IEnumerable<dynamic> GetValues()
        {
            return (from t1 in Gen1
                       from t2 in Gen2
                       select new { Item1=t1, Item2=t2 });
        }

        public dynamic Prop { get { return Predicate; } }
        public void SetPredicate(dynamic predicate)
        {
            Predicate = predicate;
        }

        public Quantifier Quntifier { get; set; }
    }

    class PropArg<T> : IPropArg
    {
        public IEnumerable<T> Gen1 { get; set; }
        public Func<T, bool> Predicate { get; set; }

        public IEnumerable<dynamic> GetValues()
        {
            return (from t1 in Gen1
                    select new { Item1 = t1});
        }
        public dynamic Prop { get { return Predicate; } }
        public void SetPredicate(dynamic predicate)
        {
            Predicate = predicate;
        }

        public Quantifier Quntifier { get; set; }
    }

    enum Quantifier
    {
        None,
        ForAll,
        ThereExists
    }
}
