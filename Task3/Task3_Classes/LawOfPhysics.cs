using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_Classes
{
    public class LawOfPhysics
    {
        private List<object> _affectedObjects;
        private int _significance = 0;

        /// <summary>
        /// Creates new law of physics with affected objects and significance
        /// </summary>
        /// <param name="affectedObjects">Objects affected by law of physics</param>
        /// <param name="significance">Significance of the law of physics</param>
        public LawOfPhysics(List<object> affectedObjects, int significance)
        {
            _affectedObjects = affectedObjects;
            if (significance > 0) _significance = significance;
        }

        /// <summary>
        /// Gives access to information about law name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gives access to information about law formula
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// Gives access to information about law formulation
        /// </summary>
        public string Formulation { get; set; }

        /// <summary>
        /// Adds object to affected objects
        /// </summary>
        /// <param name="obj">Adding object</param>
        public void AddToAffectedObjects(object obj)
        {
            _affectedObjects.Add(obj);
        }

        /// <summary>
        /// Removes object from affected objects
        /// </summary>
        /// <param name="obj">Object to remove</param>
        /// <returns>Rezult of the removing.True on success.False of fail</returns>
        public bool RemoveFromAffectedObject(object obj)
        {
            return _affectedObjects.Remove(obj);
        }

        /// <summary>
        /// Gets affected objects count
        /// </summary>
        /// <returns> affected objects count</returns>
        public int GetAffectedObjectsCount()
        {
            return _affectedObjects.Count;
        }

        /// <summary>
        /// Gets law significance
        /// </summary>
        /// <returns>law significance</returns>
        public int GetLawSignificance()
        {
            return _significance;
        }
    }
}
