#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using CSharpCheck.Specification;

namespace CSharpCheck
{
    class Property : PropertySpec
    {
        private readonly IPropArg _propArg;
        
        internal Property(IPropArg propArg)
        {
            _propArg = propArg;
        }

        public override void Check()
        {
            var type = _propArg.GetType();
            var paramCount = type.GetGenericArguments().Count();

            var testCount = 0;
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
                if (!passed && _propArg.Quntifier == Quantifier.ForAll)
                {
                    //Reporter.Report(String.Format("! Failed after {0} tests, for value: {1}", cnt, v));
                    throw new TestFailedException(String.Format("! Failed after {0} tests, for value: {1}", testCount, v));
                }
                if (passed && _propArg.Quntifier == Quantifier.ThereExists)
                {
                    break;
                }

                testCount++;
            }
            if (!passed && _propArg.Quntifier == Quantifier.ThereExists)
            {
                throw new TestFailedException(String.Format("! Failed after trying with {0} values, there exists no such value", testCount));
            }

            Reporter.Report(String.Format("+ OK, passed after {0} tests.", testCount));
        }        
    }

    internal interface IPropArg
    {
        dynamic Prop { get; }

        Quantifier Quntifier { get; set; }
        IEnumerable<dynamic> GetValues();
        void SetPredicate(dynamic predicate);
    }

    internal class PropArg<T, T1> : IPropArg
    {
        public IEnumerable<T> Gen1 { get; set; }
        public IEnumerable<T1> Gen2 { get; set; }

        public Func<T, T1, bool> Predicate { get; set; }

        public IEnumerable<dynamic> GetValues()
        {
            return (from t1 in Gen1
                from t2 in Gen2
                select new {Item1 = t1, Item2 = t2});
        }

        public dynamic Prop
        {
            get { return Predicate; }
        }

        public void SetPredicate(dynamic predicate)
        {
            Predicate = (Func<T, T1, bool>)predicate;
        }

        public Quantifier Quntifier { get; set; }
    }

    internal class PropArg<T> : IPropArg
    {
        public IEnumerable<T> Gen1 { get; set; }
        public Func<T, bool> Predicate { get; set; }

        public IEnumerable<dynamic> GetValues()
        {
            return (from t1 in Gen1
                select new {Item1 = t1});
        }

        public dynamic Prop
        {
            get { return Predicate; }
        }

        public void SetPredicate(dynamic predicate)
        {
            Predicate = (Func<T, bool>)predicate;
        }

        public Quantifier Quntifier { get; set; }
    }

    internal enum Quantifier
    {
        None,
        ForAll,
        ThereExists
    }
}