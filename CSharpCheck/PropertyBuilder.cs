using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCheck
{
    public class PropertyBuilder<T>
    {
        private readonly PropertySpec _prop;
        private readonly IPropArg _arg;

        internal PropertyBuilder(IPropArg arg)
        {            
            _arg = arg;
            _prop=new PropertySpec(_arg);
        }

        public PropertySpec SuchThat(Func<T, bool> spec)
        {
            _arg.SetPredicate(spec);
            return _prop;
        }
    }
}
