#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

namespace CSharpCheck.Specification
{
    public static class Extensions
    {
        public static IPropertySpec And(this IPropertySpec thisSpec, IPropertySpec otherSpec)
        {
            return new AndPropertySpec(thisSpec, otherSpec);
        }


        public static IPropertySpec Or(this IPropertySpec thisSpec, IPropertySpec otherSpec)
        {
            return new OrPropertySpec(thisSpec, otherSpec);
        }

        public static IPropertySpec Not(this IPropertySpec thisSpec)
        {
            return new NotPropertySpec(thisSpec);
        } 
    }
}