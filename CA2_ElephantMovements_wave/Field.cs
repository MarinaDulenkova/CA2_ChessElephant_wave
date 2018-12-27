using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_ElephantMovements_wave
{
    public class Field
    {
        /// <summary>
        /// поле
        /// </summary>
        private FieldCell[,] field;

        /// <summary>
        /// размер поля
        /// </summary>
        private int fieldSize;

        public FieldCell[,] GetField()
        {
            return field;
        }

        public int FieldSize
        {
            get
            {
                return fieldSize;
            }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="fieldSize">размер поля</param>
        public Field(int fieldSize)
        {
            this.fieldSize = fieldSize;
            field = new FieldCell[fieldSize, fieldSize];
            for (int i = 0; i < fieldSize; ++i)
            {
                for (int j = 0; j < fieldSize; ++j)
                {
                    field[i, j] = new FieldCell();
                }
            }
        }

        /// <summary>
        /// проверка на валидность поля (один слон, одна точка выхода)
        /// </summary>
        public bool IsValid
        {
            get
            {
                int startingCellsCount = 0;
                int finishingCellsCount = 0;
                int i = 0;
                int j = 0;
                while ((i < fieldSize) && (startingCellsCount <= 1) && (finishingCellsCount <= 1))
                {
                    while ((j < fieldSize) && (startingCellsCount <= 1) && (finishingCellsCount <= 1))
                    {
                        if (field[i, j].CellType == FieldCell.FieldCellType.START)
                        {
                            ++startingCellsCount;
                        }
                        if (field[i, j].CellType == FieldCell.FieldCellType.FINISH)
                        {
                            ++finishingCellsCount;
                        }
                        ++j;
                    }
                    ++i;
                    j = 0;
                }
                return i == fieldSize && finishingCellsCount == 1 && startingCellsCount == 1;
            }
        }
    }
}
