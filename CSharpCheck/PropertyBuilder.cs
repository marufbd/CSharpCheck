#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System;
using CSharpCheck.Specification;

namespace CSharpCheck
{
    public class PropertyBuilder<T>
    {
        private readonly IPropArg _arg;
        private readonly Property _prop;

        internal PropertyBuilder(IPropArg arg)
        {
            _arg = arg;
            _prop = new Property(_arg);
        }

        public IPropertySpec SuchThat(Func<T, bool> spec)
        {
            _arg.SetPredicate(spec);
            return _prop;
        }
    }
}