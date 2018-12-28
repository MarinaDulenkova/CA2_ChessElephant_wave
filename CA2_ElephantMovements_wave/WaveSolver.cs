using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_ElephantMovements_wave
{
    /// <summary>
    /// класс для поиска пути для слона волновым алгоритмом 
    /// </summary>
    class WaveSolver
    {
        private Field field;
        private int startX = 0;
        private int startY = 0;
        private int finishX = 0;
        private int finishY = 0;
        private FieldCell finishingCell;
        private Point[,] history;

        public WaveSolver(Field field)
        {
            this.field = new Field(field.FieldSize);
            history = new Point[field.FieldSize, field.FieldSize];
            //клонирование поля, запоминание точки начала и конца
            for (int i = 0; i < field.FieldSize; ++i)
            {
                for (int j = 0; j < field.FieldSize; ++j)
                {
                    FieldCell.FieldCellType cellType = field.GetField()[i, j].CellType;
                    this.field.GetField()[i, j].CellType = cellType;
                    if (cellType == FieldCell.FieldCellType.START)
                    {
                        startX = i;
                        startY = j;
                    }
                    else if (cellType == FieldCell.FieldCellType.FINISH)
                    {
                        finishX = i;
                        finishY = j;
                        finishingCell = this.field.GetField()[i, j];
                    }
                }
            }
        }

        /// <summary>
        /// проверка одного из направлений обхода слона
        /// </summary>
        /// <param name="cellsToVisit">ячейки, которые еще не осмотрели</param>
        /// <param name="step">шаг волнового алгоритма</param>
        /// <param name="startPoint">начальная точка отсчета</param>
        /// <param name="dx">направление по х</param>
        /// <param name="dy">направление по у</param>
        public void CheckDirection(List<Point> cellsToVisit, int step, Point startPoint, int dx, int dy)
        {
            int x = startPoint.X + dx;
            int y = startPoint.Y + dy;
            //пока нет препятствий идем до упора
            while ((x >= 0) && (x < field.FieldSize) && (y >= 0) && (y < field.FieldSize) && (field.GetField()[x, y].CellType != FieldCell.FieldCellType.WALL))
            {
                var cell = field.GetField()[x, y];
                //если ячейку еще не посещали и не собирались посетить
                if (!cell.IsVisited && (cell.Step == 0))
                {
                    cellsToVisit.Add(new Point(x, y));
                    //запоминаем, откуда пришли
                    history[x, y] = startPoint;
                    //пометка о том, что собираемся посетить на следующем шаге
                    cell.Step = step;
                }
                x += dx;
                y += dy;
            }
        }

        public event EventHandler<WaveSolverEventArgs> OnFinished;

        public void Start()
        {
            //непосещенные ячейки
            List<Point> unvisitedCells = new List<Point>{
                new Point(startX, startY)
            };
            int step = 1;
            //пока не посетили все возможные ячейки или не собираемся посетить финишную
            while (unvisitedCells.Count() != 0 && (finishingCell.Step == 0))
            {
                List<Point> tmpList = new List<Point>();
                //для каждой достижимой точки проверяем все направления движения
                foreach (Point p in unvisitedCells)
                {
                    field.GetField()[p.X, p.Y].IsVisited = true;
                    CheckDirection(tmpList, step, p, 1, 1);
                    CheckDirection(tmpList, step, p, -1, 1);
                    CheckDirection(tmpList, step, p, 1, -1);
                    CheckDirection(tmpList, step, p, -1, -1);
                }
                //устанавливаем новую волну
                unvisitedCells = tmpList;
                ++step;
            }
            //если финишную не собирались посещать, то путь не найден
            if (finishingCell.Step == 0)
            {
                OnFinished?.Invoke(this, new WaveSolverEventArgs());
            }
            else
            {
                //иначе получаем историю переходов до финишной клетки
                List<PointWithStep> path = new List<PointWithStep>();
                Point p = history[finishX, finishY];
                path.Add(new PointWithStep(p, field.GetField()[finishX, finishY].Step));
                while ((p.X != startX) || (p.Y != startY))
                {
                    p = history[p.X, p.Y];
                    path.Add(new PointWithStep(p, field.GetField()[p.X, p.Y].Step));
                }
                //путь перевернут
                path.Reverse();
                //убираем первую ячейку из пути
                path.RemoveAt(0);
                OnFinished?.Invoke(this, new WaveSolverEventArgs(path));
            }
        }
    }
}
