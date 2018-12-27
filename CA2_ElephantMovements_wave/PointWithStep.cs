using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CA2_ElephantMovements_wave
{
    /// <summary>
    /// класс для хранения точки для посещения и шага
    /// </summary>
    class PointWithStep
    {
        /// <summary>
        /// точка и методы аксессоры для координат
        /// </summary>
        private Point point;

        public int X
        {
            get
            {
                return point.X;
            }
        }

        public int Y
        {
            get
            {
                return point.Y;
            }
        }

        /// <summary>
        /// шаг для посещения и метод аксессор
        /// </summary>
        private int step;

        public int Step
        {
            get
            {
                return step;
            }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="point">точка</param>
        /// <param name="step">шаг для посещения точки</param>
        public PointWithStep(Point point, int step)
        {
            this.point = point;
            this.step = step;
        }
    }
}
