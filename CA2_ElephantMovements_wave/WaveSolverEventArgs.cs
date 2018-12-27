using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_ElephantMovements_wave
{
    /// <summary>
    /// класс параметров для события
    /// </summary>
    public class WaveSolverEventArgs
    {
        /// <summary>
        /// найден ли путь и метод аксессор
        /// </summary>
        private bool isPathFound;

        public bool IsPathFound
        {
            get
            {
                return isPathFound;
            }
        }

        /// <summary>
        /// список точек с шагом и метод аксессор
        /// </summary>
        private List<PointWithStep> path = null;

        public List<PointWithStep> Path
        {
            get
            {
                return path;
            }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="path">путь, по которому шли</param>
        public WaveSolverEventArgs(List<PointWithStep> path)
        {
            isPathFound = true;
            this.path = path;
        }

        /// <summary>
        /// конструктор без параметров: нет пути -> не нашли его
        /// </summary>
        public WaveSolverEventArgs()
        {
            isPathFound = false;
        }
    }
}
