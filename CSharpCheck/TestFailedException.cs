#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System;

namespace CSharpCheck
{
    public class TestFailedException : Exception
    {
        public TestFailedException(string msg) : base(msg)
        {
        }
    }
}