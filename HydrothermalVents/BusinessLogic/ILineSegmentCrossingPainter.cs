using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.BusinessLogic
{
    public interface ILineSegmentCrossingPainter<U, T> where U : struct where T : class
    {
        public void draw(List<T> lineSegments, List<Crossing<U, T>> crossing);
    }
}
