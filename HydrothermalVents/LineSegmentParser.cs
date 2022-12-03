using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class LineSegmentParser : ILineSegmentParser<int>
    {
        public LineSegmentParser() { }
        public LineSegment<int> FromString(string input)
        {
            try
            {
                input = input.Replace(" -> ", ","); // "X1,Y1 -> X2,Y2" => "X1,Y1,X2,Y2"
                string[] inputs = input.Split(","); // "X1,Y1,X2,Y2" => ["X1","Y1","X2","Y2"]
                return new LineSegment<int>(new int[] { int.Parse(inputs[0]), int.Parse(inputs[1]) }, new int[] { int.Parse(inputs[2]), int.Parse(inputs[3]) });
            }
            catch(Exception ex) 
            {
                throw new LineSegmentParserException("Bad input format.", ex);
            }
        }

        public  string ToString(LineSegment<int> input)
        {
            throw new LineSegmentParserException("Not implemented");
        }
    }
}
