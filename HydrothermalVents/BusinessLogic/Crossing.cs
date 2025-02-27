// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;

namespace HydrothermalVents.BusinessLogic
{
    /// <summary>
    /// Generic crossing point of n elements of type T. Coordinates are of type U
    /// Depending on the crossing elements and the dimension nature of position can be derived.
    /// I.e. Two Planes in 3D cross in a line segment. Thus T would be a Plane and U a line segment.
    /// Notice: No checks are in place to match U and T.
    /// </summary>
    public class Crossing<U, T> where U : struct
                                where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Crossing{U, T}"/> class with default values.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the position array to an empty array and the elements list to an empty list.
        /// </remarks>
        public Crossing()
        {
            m_position = new U[] { };
            m_elements = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Crossing{U, T}"/> class with specified position and elements.
        /// </summary>
        /// <param name="position">The position of the crossing of the elements.</param>
        /// <param name="elements">The elements that cross at the specified position.</param>
        /// <remarks>
        /// This constructor sets the position and elements of the crossing point.
        /// </remarks>
        public Crossing(U[] position, List<T> elements)
        {
            m_position = position;
            m_elements = elements;
        }

        /// <summary>
        /// Adds an additional element to the list of crossing elements.
        /// </summary>
        /// <param name="element">The element to add to the crossing elements list.</param>
        /// <remarks>
        /// This method is used to add an element that also crosses the current position.
        /// </remarks>
        public void AddElement(T element)
        {
            m_elements.Add(element);
        }

        /// <summary>
        /// Gets or sets the position of the crossing elements.
        /// </summary>
        /// <value>
        /// An array of type <see cref="U"/> representing the position of the crossing elements.
        /// </value>
        public U[] Position { get => m_position; set => m_position = value; }

        /// <summary>
        /// Gets or sets the list of elements that cross at the specified position.
        /// </summary>
        /// <value>
        /// A list of type <see cref="T"/> representing the elements that cross at the specified position.
        /// </value>
        public List<T> Elements { get => m_elements; set => m_elements = value; }

        private U[] m_position;
        private List<T> m_elements;
    }
}
