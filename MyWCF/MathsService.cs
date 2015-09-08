using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MathsService : IMaths
    {
        public int Add(Maths obj)
        {
            return obj.Number1 + obj.Number2;
        }

        public int Div(Maths obj)
        {
            return obj.Number2 == 0 ? 0 : obj.Number1 / obj.Number2;
        }

        public int Mul(Maths obj)
        {
            return obj.Number1 * obj.Number2;
        }

        public int Sub(Maths obj)
        {
            return obj.Number1 - obj.Number2;
        }
    }
}
