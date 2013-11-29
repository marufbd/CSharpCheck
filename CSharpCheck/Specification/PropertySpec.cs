#region Copyright

// CSharpCheck
// Copyright (c) 2013, Maruf Rahman. All rights reserved.                	
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 	
// There is NO WARRANTY. See the file LICENSE for the full text.

#endregion

using System;

namespace CSharpCheck.Specification
{
    public interface IPropertySpec
    {
        void Check();
    }

    abstract class PropertySpec : IPropertySpec
    {        
        protected IReporter Reporter=new ConsoleReporter();

        public abstract void Check();
    }

    class AndPropertySpec : PropertySpec
    {
        private readonly IPropertySpec _prop1, _prop2;

        public AndPropertySpec(IPropertySpec prop1, IPropertySpec prop2)
        {
            _prop1 = prop1;
            _prop2 = prop2;
        }


        public override void Check()
        {
            //both properties to be executed without exception
            //otherwise TestFaileException raised from Check()
            _prop1.Check();
            _prop2.Check();            
        }
    }

    class OrPropertySpec : PropertySpec
    {
        private readonly IPropertySpec _prop1, _prop2;

        public OrPropertySpec(IPropertySpec prop1, IPropertySpec prop2)
        {
            _prop1 = prop1;
            _prop2 = prop2;
        }


        public override void Check()
        {
            //at least one property needs to be executed without exception
            //otherwise TestFailedException
            try
            {
                _prop1.Check();                
            }
            catch (TestFailedException exc)
            {                
                try
                {
                    _prop2.Check();
                }
                catch (TestFailedException exc2)
                {
                    string report = "! Failed, as Both propperty spec failed, see reasons:";
                    report += "\n\t" + exc.Message + "\n\t" + exc2.Message;
                    throw new TestFailedException(report);
                }
            }
        }
    }

    class NotPropertySpec : PropertySpec
    {
        private readonly IPropertySpec _prop;

        public NotPropertySpec(IPropertySpec prop)
        {
            _prop = prop;
        }


        public override void Check()
        {
            //property check should throw a TestFailedException
            try
            {
                _prop.Check();
            }
            catch (TestFailedException)
            {
                //todo: report number of tests done
                Reporter.Report(String.Format("+ OK, Passed after {0} tests", "Can't determine"));
                return;
            }
            //if we come here means all passed, so Not all pass means Fail
            //todo: report number of tests done in exception message
            throw new TestFailedException(String.Format("! Failed after passing {0} tests", "Can't determine"));
        }
    }

    
}