using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCheck
{
    interface IReporter
    {
        void Report(string msg);
    }

    class ConsoleReporter:IReporter
    {
        public void Report(string msg)
        {
            Console.WriteLine(msg);
        }
    }

}
