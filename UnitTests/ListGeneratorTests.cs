using System;
using System.Collections.Generic;
using System.Linq;
using CSharpCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ListGeneratorTests
    {
        [TestMethod]
        public void ListOfInt()
        {
            var prop = Prop.ForAll((List<int> s) => s.Count >= 0);

            prop.Check();
            Console.WriteLine(prop);
        }


        [TestMethod]
        public void ArbitraryMultipleList()
        {
            var prop = Prop.ForAll((List<int> x, List<int> y) => x.Concat(y).Count() == x.Count + y.Count);
            prop.Check();
            Console.WriteLine(prop);

            int a = 'a', z = 'z', A = 'A', Z = 'Z';
            Console.WriteLine(a);
            Console.WriteLine(z);
        }
    }
}