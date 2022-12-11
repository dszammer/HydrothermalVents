// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.BusinessLogic
{
    public interface ICrossingCalculator<U, T> where U : struct where T : class
    {
        public Crossing<U, T>? CalculateCrossing(T elementA, T elementB);
        public bool LineSegmentSatisfiesConstraints(T elementA);
    }

}
