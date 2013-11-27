using System;
using System.Collections.Generic;
using System.Linq;
using CSharpCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void GenChoose()
        {
            var prop = Prop.ForAll(Gen.Choose(1, 10))
                           .SuchThat(x => x >= 1 && x <= 10);
            
            prop.Check();
            Console.WriteLine(prop);
        }

        [TestMethod]
        public void ArbitraryIntGeneratesOneOrMinusOne()
        {
            var arbInt = (new Arbitrary<int>()).SuchThat(x=>x==1 || x==-1);            
            Assert.IsTrue(arbInt.Any());            
        }

        [TestMethod]
        public void ArbitraryIntGeneratesZero()
        {
            var arbInt = (new Arbitrary<int>()).SuchThat(x => x == 0);
            Assert.IsTrue(arbInt.Any());
        }

        [TestMethod]
        public void TupleGenerator()
        {
            //generate tuple<int, int> where second int is at least twice as the first one
            var myGen = (from m in Gen.Choose(1, 10)
                from n in Gen.Choose(2*m, 25)
                select new Tuple<int, int>(m, n));

            var prop=Prop.ForAll(myGen).SuchThat(t => t.Item2 >= t.Item1*2);
            prop.Check();
            Console.WriteLine(prop);
        }


        [TestMethod]
        public void OneOfGeneratorGenratesOneFromTheGivenList()
        {
            var vowels = new char[] {'a', 'e', 'i', 'o', 'u'};
            var vowelGen = Gen.OneOf(vowels);
            var prop = Prop.ForAll(vowelGen).SuchThat(vowels.Contains);            
            prop.Check();

            Console.WriteLine(prop);
        }

        [TestMethod]
        public void OneOfGeneratorGenratesOneValueAtLeastOnce()
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var vowelGen = Gen.OneOf(vowels);
            foreach (var vowel in vowels)
            {
                var prop = Prop.ThereExists(vowelGen).SuchThat(x => x == vowel);
                prop.Check();
                Console.WriteLine(prop);
            }            
        }

        [TestMethod]
        public void ShowStatistics()
        {
            Gen.Choose(1, 10).GenerateStatistics().ForEach(Console.WriteLine);
            Console.WriteLine();
            Gen.OneOf('a', 'e', 'i', 'o', 'u').GenerateStatistics().ForEach(Console.WriteLine);
            Console.WriteLine();
            Gen.OneOf("blue", "indigo", "violet", "green", "yellow", "orange", "red").GenerateStatistics().ForEach(Console.WriteLine);
            Console.WriteLine();
            //with frequency provider based on length of string
            Gen.OneOf(x => x.Length, "H", "He", "Hel", "Hell", "Hello").GenerateStatistics().ForEach(Console.WriteLine);
        }

        
    }
}
