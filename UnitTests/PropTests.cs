using System;
using System.Linq;
using CSharpCheck;
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
            var prop = Prop.ThereExists((int x) => x==0);
            prop.Check();
            Console.WriteLine(prop);
        }


        [Test]
        public void ArbitraryString()
        {
            var prop = Prop.ForAll((string s, string t) => (s + t).StartsWith(s));
            prop.Check();
            Console.WriteLine(prop);
        }

    }
}
