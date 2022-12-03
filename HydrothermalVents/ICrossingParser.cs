using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public interface ICrossingParser<T,U> where T : struct where U : class
    {
        public Crossing<T, U> FromString(string input);
        public string ToString(Crossing<T, U> crossing);
    }
}
