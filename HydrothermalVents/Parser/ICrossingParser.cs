using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;

namespace HydrothermalVents.Parser
{
    public interface ICrossingParser<T, U> where T : struct where U : class
    {
        public Crossing<T, U> FromString(string input);
        public string ToString(Crossing<T, U> crossing);
    }
}
