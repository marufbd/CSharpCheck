using System;
using System.Linq;
using CSharpCheck;
using CSharpCheck.Specification;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class PropTests
    {
        [Test]
        public void IntGenGeneratesOneOrMinusOneWithPropTrue()
        {
            var propTrue = Prop.ThereExists((int x) => x == 1 || x == -1);
            Assert.DoesNotThrow(propTrue.Check);
        }

        [Test]
        public void IntGenGeneratesOneOrMinusOneWithPropFalse()
        {
            var propFalse = Prop.ForAll((int x) => x != 1 && x != -1);
            Assert.Throws<TestFailedException>(propFalse.Check, "ForAll Int does not generate 1 or -1");
        }


        [Test]
        public void IntGeneratorGeneratesZero()
        {
            var prop = Prop.ThereExists((int x) => x == 0);
            prop.Check();            
        }


        [Test]
        public void ArbitraryString()
        {
            var prop = Prop.ForAll((string s, string t) => (s + t).StartsWith(s));
            prop.Check();            
        }


        [Test]
        public void ComposePropertyWithAnd()
        {
            var prop1 = Prop.ForAll((string s, string t) => (s + t).StartsWith(s));
            var prop2 = Prop.ForAll((string s, string t) => (s + t).EndsWith(t));
            var prop = prop1.And(prop2);

            prop.Check();            
        }

        [Test]
        public void ComposePropertyWithOr()
        {
            var prop1 = Prop.ThereExists((string s, string t) => (s + t).StartsWith(t));
            var prop2 = Prop.ThereExists((string s, string t) => (s + t).EndsWith(s));
            var prop = prop1.Or(prop2);

            prop.Check();            
        }

        [Test]
        public void ComposePropertyWithNot()
        {
            var propFail = Prop.ForAll((string s, string t) => (s + t).StartsWith(s)).Not();
            var propPass = Prop.ForAll((string s, string t) => !(s + t).StartsWith(s)).Not();

            Assert.Throws<TestFailedException>(propFail.Check);
            propPass.Check();
        }
    }
}