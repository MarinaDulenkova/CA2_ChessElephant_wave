using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_ElephantMovements_wave
{
    /// <summary>
    /// класс ячейки для шахматной доски
    /// </summary>
    public class FieldCell
    {
        /// <summary>
        /// множество состояний ячейки
        /// </summary>
        public enum FieldCellType { EMPTY, START, WALL, FINISH };

        /// <summary>
        /// состояние ячейки и метод аксессор
        /// </summary>
        private FieldCellType cellType;

        public FieldCellType CellType
        {
            get
            {
                return cellType;
            }
            set
            {
                cellType = value;
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
            set
            {
                step = value;
            }
        }

        /// <summary>
        /// посещалась ли ячейка и метод аксессор
        /// </summary>
        private bool isVisited;

        public bool IsVisited
        {
            get
            {
                return isVisited;
            }
            set
            {
                isVisited = value;
            }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        public FieldCell()
        {
            cellType = FieldCellType.EMPTY;
            step = 0;
            isVisited = false;
        }
    }
}
