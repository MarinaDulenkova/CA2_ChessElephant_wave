using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA2_ElephantMovements_wave
{
    public partial class fmMain : Form
    {
        //константы
        public const int FIELD_SIZE = 8;
        public const int FIELD_CELL_WIDTH = 40;
        public const int FIELD_CELL_BORDER_WIDTH = 5;
        public Color FIELD_CELL_BORDER_COLOR = Color.Black;
        public Color FIELD_CELL_WALL_COLOR = Color.Red;
        public Color FIELD_CELL_EMPTY_COLOR = Color.White;
        public Color FIELD_CELL_START_COLOR = Color.Blue;
        public Color FIELD_CELL_FINISH_COLOR = Color.Green;
        public Color FIELD_CELL_PATH_COLOR = Color.Aqua;
        /// <summary>
        /// поле
        /// </summary>
        public Field field = new Field(FIELD_SIZE);
        /// <summary>
        /// поток выполнения под волновой алгоритм
        /// </summary>
        private Thread solverThread;
        /// <summary>
        /// путь для отображения
        /// </summary>
        private List<PointWithStep> path;

        /// <summary>
        /// конструктор
        /// </summary>
        public fmMain()
        {
            InitializeComponent();
            cbCellType.SelectedIndex = 0;
        }

        /// <summary>
        /// обработчик нажатия на поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbField_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            //определяемся с ячейкой и вообще ячейка ли это
            int cellX = mea.X / (FIELD_CELL_WIDTH + FIELD_CELL_BORDER_WIDTH);
            int cellY = mea.Y / (FIELD_CELL_WIDTH + FIELD_CELL_BORDER_WIDTH);
            int x = mea.X % (FIELD_CELL_WIDTH + FIELD_CELL_BORDER_WIDTH);
            int y = mea.Y % (FIELD_CELL_WIDTH + FIELD_CELL_BORDER_WIDTH);
            if (x < FIELD_CELL_BORDER_WIDTH)
            {
                return;
            }
            if (y < FIELD_CELL_BORDER_WIDTH)
            {
                return;
            }

            //разбираемся с кнопкой мыши и устанавливаем нужный тип ячейки
            if (mea.Button == MouseButtons.Right)
            {
                field.GetField()[cellX, cellY].CellType = FieldCell.FieldCellType.EMPTY;
            }
            else if (mea.Button == MouseButtons.Left)
            {
                field.GetField()[cellX, cellY].CellType = (FieldCell.FieldCellType)(cbCellType.SelectedIndex + 1);
            }
            path = null;
            pbField.Invalidate();
        }

        /// <summary>
        /// перерисовка поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbField_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(FIELD_CELL_BORDER_COLOR);
            FieldCell[,] field = this.field.GetField();
            //рисуем поле нужными цветами
            for (int i = 0; i < FIELD_SIZE; ++i)
            {
                for (int j = 0; j < FIELD_SIZE; ++j)
                {
                    Color color = Color.White;
                    switch (field[i, j].CellType)
                    {
                        case FieldCell.FieldCellType.START:
                            {
                                color = FIELD_CELL_START_COLOR;
                                break;
                            }
                        case FieldCell.FieldCellType.EMPTY:
                            {
                                color = FIELD_CELL_EMPTY_COLOR;
                                break;
                            }
                        case FieldCell.FieldCellType.WALL:
                            {
                                color = FIELD_CELL_WALL_COLOR;
                                break;
                            }
                        case FieldCell.FieldCellType.FINISH:
                            {
                                color = FIELD_CELL_FINISH_COLOR;
                                break;
                            }
                    }
                    graphics.FillRectangle(new SolidBrush(color), new Rectangle((i + 1) * FIELD_CELL_BORDER_WIDTH + i * FIELD_CELL_WIDTH, (j + 1) * FIELD_CELL_BORDER_WIDTH + j * FIELD_CELL_WIDTH, FIELD_CELL_WIDTH, FIELD_CELL_WIDTH));
                }
            }
            //рисуем путь, если имеется
            if (path != null)
            {
                foreach (PointWithStep p in path)
                {
                    graphics.FillRectangle(new SolidBrush(FIELD_CELL_PATH_COLOR), new Rectangle((p.X + 1) * FIELD_CELL_BORDER_WIDTH + p.X * FIELD_CELL_WIDTH, (p.Y + 1) * FIELD_CELL_BORDER_WIDTH + p.Y * FIELD_CELL_WIDTH, FIELD_CELL_WIDTH, FIELD_CELL_WIDTH));
                }
            }
        }

        /// <summary>
        /// запуск волнового алгоритма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!field.IsValid)
            {
                MessageBox.Show("На поле должен быть ровно один слон и ровно одна точка выхода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                WaveSolver solver = new WaveSolver(field);
                solver.OnFinished += OnSolverFinishedHandler;
                solverThread = new Thread(solver.Start);
                solverThread.Start();
                btnRun.Enabled = false;
                btnStop.Enabled = true;
                Thread.Sleep(0);
            }
        }

        /// <summary>
        /// остановка волнового алгоритма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            solverThread?.Abort();
            btnRun.Enabled = true;
            btnStop.Enabled = false;
        }

        private delegate void OnSolverFinishedHandlerDelegate(object sender, WaveSolverEventArgs e);

        /// <summary>
        /// обработка завершения работы волнового алгоритма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSolverFinishedHandler(object sender, WaveSolverEventArgs e)
        {
            //если не в потоке формы, то разбудить его
            if (this.InvokeRequired)
            {
                Delegate d = new OnSolverFinishedHandlerDelegate(OnSolverFinishedHandler);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                //иначе выводим сообщения, чистим потоки, выводим путь, перезапускаем кнопки
                String message = e.IsPathFound ? "Путь найден!" : "Найти путь не удалось!";
                MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (e.IsPathFound)
                {
                    path = e.Path;
                    pbField.Invalidate();
                }
                solverThread = null;
                btnRun.Enabled = true;
                btnStop.Enabled = false;
            }
        }
    }
}
