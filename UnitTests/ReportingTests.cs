using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ReportingTests
    {

        [Test]
        public void ShowStatistics()
        {
            Gen.Choose(1, 10).GenerateStatistics().ForEach(Console.WriteLine);
            Console.WriteLine("----");
            Gen.OneOf('a', 'e', 'i', 'o', 'u').GenerateStatistics().ForEach(Console.WriteLine);
            Console.WriteLine("----");
            Gen.OneOf("blue", "indigo", "violet", "green", "yellow", "orange", "red")
                .GenerateStatistics()
                .ForEach(Console.WriteLine);
            Console.WriteLine("----");
            //with frequency provider based on length of string
            Gen.OneOf(x => x.Length, "H", "He", "Hel", "Hell", "Hello").GenerateStatistics().ForEach(Console.WriteLine);
        }



    }
}
