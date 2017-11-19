// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="My company">
//   free to copy
// </copyright>
// <summary>
//   The container for dependencies.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Epam_9
{
    /// <summary>
    /// The container for dependencies.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Gets or sets the interface type.
        /// </summary>
        public Type Interface { get; set; }

        /// <summary>
        /// Gets or sets the class type.
        /// </summary>
        public Type Class { get; set; }

        /// <summary>
        /// Gets or sets the key for access.
        /// </summary>
        public string Key { get; set; }
    }
}