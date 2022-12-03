// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;


namespace HydrothermalVents
{
    /// <summary>
    /// Generic crossing point of n elements of type T. Coordinates are of type U
    /// Depending on the crossing elements and the dimension nature of position can be derived.
    /// I.e. Two Planes in 3D cross in a line segment. Thus T would be a Plane and U a line segment.
    /// Notice: No checks are in place to match U and T.
    /// </summary>
    public class Crossing<U,T>  where U : struct
                                where T : class 
    {
        /// <summary>
        /// Default CTOR
        /// </summary>
        public Crossing()
        {
            m_position = new U[] { };
            m_elements = new List<T>();
        }

        /// <summary>
        /// CTOR
        /// param position: Position of the crossing of the elements.
        /// param elements: Points that cross in position.
        /// </summary>
        public Crossing(U[] position, List<T> elements)
        {
            m_position = position;
            m_elements = elements;
        }

        public U[] Position { get => m_position; set => m_position = value; }
        public List<T> Elements { get => m_elements; set => m_elements = value; }

        /// <summary>
        /// In case an additional element is found that also crosses the position it can be added here.
        /// param element: element to add.
        /// </summary>
        public void AddElement(T element)
        {
            m_elements.Add(element);
        }

        private U[] m_position;
        private List<T> m_elements;
    }
}
