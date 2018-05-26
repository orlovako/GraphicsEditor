using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseData;
using Microsoft.Practices.Unity;
using GraphicsEditor1;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity;
using DataFigure;


namespace GraphicsEditor1
{    
    public partial class Canva : Form
    {
        /// <summary>
        /// Структура, хранящая основные характеристики фигуры.
        /// </summary>
        public struct Properties
        {
            /// <summary>
            /// Переменная, хранящая цвет линии.
            /// </summary>
            public Color linecolor;

            /// <summary>
            /// Переменная, хранящая цвет заливки.
            /// </summary>
            public Color brushcolor;

            /// <summary>
            /// Переменная, хранящая толщину линии.
            /// </summary>
            public int thickness;

            /// <summary>
            /// Переменная, хранящая стиль линии.
            /// </summary>
            public DashStyle dashstyle;

            /// <summary>
            /// Переменная, хранящая значение заливки.
            /// </summary>
            public bool fill;
        }

        /// <summary>
        /// Структура, хранящая основные характеристики опорных точек.
        /// </summary>
        public struct PropertiesSupport
        {
            /// <summary>
            /// Переменная, хранящая цвет линии.
            /// </summary>
            public Color linecolor;
        }

        /// <summary>
        /// Переменная, хранящая текущую выбранную фигуру.
        /// </summary>
        private static int _currentfigure = 0;

        /// <summary>
        /// Переменная, хранящая предыдущую выбранную фигуру.
        /// </summary>
        private static int _previousfigure = 0;

        /// <summary>
        /// Переменная, хранящая текущее действое.
        /// </summary>       
        private int _currentActions = 0;

        /// <summary>
        /// Переменная, значения для сохранения файла.
        /// </summary>
        private bool _fileSave = false;

        /// <summary>
        /// Структура, хранящая свойства фигур.
        /// </summary>
        private static Properties _figureProperties;        

        private IWorkspace _workspace;

        /// <summary>
        /// Переменная, хранящая булевскское значения для изменения размеров канвы.
        /// </summary>
        private bool allowResize;       

        /// <summary>
        /// Переменная, хранящая класс для инициализации данных.
        /// </summary>
        DataInitialization _initializatioForm;

        /// <summary>
        /// Переменная, хранящая класс для бинарной сериализации.
        /// </summary>
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        public Canva()
        {
            InitializeComponent();

            var UnityContainerInit = new UnityContainer();

            //Характеристика фигуры
            _figureProperties.brushcolor = Color.White;
            _figureProperties.dashstyle = DashStyle.Solid;
            _figureProperties.fill = false;
            _figureProperties.linecolor = Color.Black;            
            
            //BrushType.SelectedIndex = 0;
            //lineStyleBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Метод, выполняемый при нажатии мыши.
        /// </summary>
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _workspace.MouseDown(e, _currentfigure, _currentActions);
            Canvas.Refresh();
        }

        /// <summary>
        /// Метод, выполняемый при перемещении мыши.
        /// </summary>
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            _workspace.MouseMove(e, _currentfigure, _currentActions);
            Canvas.Refresh();
        }

        /// <summary>
        /// Метод, выполняемый при отпускании мыши.
        /// </summary>
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            _workspace.MouseUp(e, _currentfigure, _currentActions, _figureProperties.linecolor, _figureProperties.thickness, _figureProperties.dashstyle, _figureProperties.brushcolor, _figureProperties.fill);
            _fileSave = true;
            Canvas.Refresh();
        }

        /// <summary>
        /// Метод, выполняемый для отрисовки фигур на карфе.
        /// </summary>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            RefreshBitmap();
            _workspace.DrawFigure(e, _currentfigure, _figureProperties.linecolor, _figureProperties.thickness, _figureProperties.dashstyle, Color.Black);
        }

        /// <summary>
        /// Метод, выполняющий обновление рабочей области.
        /// </summary>
        public void RefreshBitmap()
        {
            _workspace.RefreshBitmap();
        }

        /// <summary>
        /// Метод, выполняющий выбор фигуры.
        /// </summary>
        /// /// <para name = "Next">Переменная, хранящая выбранную фигуру.</para>
        private void ChangeFigure(int Next)
        {
            _previousfigure = _currentfigure;
            _currentfigure = Next;
        }

        /// <summary>
        /// Метод, принимающий или возвращаюий иниацилизированные данные.
        /// </summary>
        public DataInitialization InitializatioForm
        {
            get { return _initializatioForm; }
            set { _initializatioForm = value; }
        }

        /// <summary>
        /// Метод, принимающий или возвращаюий рабочую область.
        /// </summary>
        public IWorkspace Workspace
        {
            get { return _workspace; }
            set { _workspace = value; }
        }

        /// <summary>
        /// Метод, выполняющий выбор действия.
        /// </summary>
        /// /// <para name = "NextActions">Переменная, хранящая выбранное действие.</para>
        private void ChangeActions(int NextActions)
        {
            _currentActions = NextActions;
        }

        /// <summary>
        /// Метод, выполняющий выбор действия "Рисование".
        /// </summary>       
        private void Draw()
        {
            _currentActions = 0;
            ChangeActions(0);
            ChangeFigure(0);

            _workspace.DeletePivots();
            Canvas.Refresh();
        }          
               
        /// <summary>
        /// Метод, выполняющий действия "Изменение цвета линии".
        /// </summary> 
        private void ColorDialog_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == DialogResult.OK)
            {
                if (_workspace.SelectFigure() == false)
                {
                    _figureProperties.linecolor = colorDialog1.Color;
                    ColorDialog.BackColor = colorDialog1.Color;
                }
                else
                {
                    _workspace.ChangeColorPen(colorDialog1.Color);
                    Canvas.Refresh();
                    _fileSave = true;                    
                }
            }            
        }

        /// <summary>
        /// Метод, выполняющий действия изменение цвета заливки.
        /// </summary>
        private void BrushColor1_Click(object sender, EventArgs e)
        {
            _figureProperties.fill = true;
            DialogResult D = colorDialog2.ShowDialog();
            if (D == DialogResult.OK)
            {
                if (_workspace.SelectFigure() == false)
                {
                    _figureProperties.brushcolor = colorDialog2.Color;
                    BrushColor1.BackColor = colorDialog2.Color;
                }
                else
                {
                    _workspace.СhangeFilled(colorDialog2.Color);
                    Canvas.Refresh();
                    _fileSave = true;                    
                }
            }            
        }

        /// <summary>
        /// Метод, выполняющий действия изменение типа линии.
        /// </summary>
        private void lineStyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_workspace.SelectFigure() == false)
            {
                lineStyleBox.DropDownStyle = ComboBoxStyle.DropDownList;
                if (lineStyleBox.SelectedItem.ToString() == "Solid")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.Solid; }
                if (lineStyleBox.SelectedItem.ToString() == "Dash")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.Dash; }
                if (lineStyleBox.SelectedItem.ToString() == "Dot")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.Dot; }
                if (lineStyleBox.SelectedItem.ToString() == "DashDot")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.DashDot; }
                if (lineStyleBox.SelectedItem.ToString() == "DashDotDot")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.DashDotDot; }
            }
            else if (_workspace.SelectFigure() == true)
            {
                DashStyle StaticThickness = _figureProperties.dashstyle;
                lineStyleBox.DropDownStyle = ComboBoxStyle.DropDownList;
                if (lineStyleBox.SelectedItem.ToString() == "Solid")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.Solid; }
                if (lineStyleBox.SelectedItem.ToString() == "Dash")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.Dash; }
                if (lineStyleBox.SelectedItem.ToString() == "Dot")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.Dot; }
                if (lineStyleBox.SelectedItem.ToString() == "DashDot")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.DashDot; }
                if (lineStyleBox.SelectedItem.ToString() == "DashDotDot")
                { StyleOfLine = System.Drawing.Drawing2D.DashStyle.DashDotDot; }

                _workspace.СhangePenStyleFigure(_figureProperties.dashstyle);
                _fileSave = true;
                Canvas.Refresh();
                _figureProperties.dashstyle = StaticThickness;
            }
        }

        /// <summary>
        /// Метод, выполняющий действия изменение толщины линии.
        /// </summary>
        private void ThicknessTrackBar_Scroll(object sender, EventArgs e)
        {
            int StaticWidth = _figureProperties.thickness;
            ThicknessTrackBar.Minimum = 1;      
            ThicknessTrackBar.Maximum = 15;    
            ThicknessTrackBar.TickFrequency = 1;    //шаг
            ThicknessTrackBar.LargeChange = 2;      //прибавление в случае прокрутки в большую сторону
            ThicknessTrackBar.SmallChange = 2;      //уменьшение в случае прокрутки в меньшую сторону
            ThicknessValue.Text = "" + ThicknessTrackBar.Value.ToString();      
            _figureProperties.thickness = ThicknessTrackBar.Value;           

            if (_workspace.SelectFigure() == true)
            {
                _workspace.СhangePenWidthFigure(_figureProperties.thickness);
                _fileSave = true;
                Canvas.Refresh();
                _figureProperties.thickness = StaticWidth;
            }
        }

        /// <summary>
        /// Метод, принимающий стиль линии.
        /// </summary>
        public static DashStyle StyleOfLine
        {
            get { return _figureProperties.dashstyle; }
            set { _figureProperties.dashstyle = value; }
        }

        /// <summary>
        /// Метод, принимающий толщину линии.
        /// </summary>
        public static int Thickness 
        {
            get { return _figureProperties.thickness; }
            set { _figureProperties.thickness = value; }
        }

        /// <summary>
        /// Метод, возвращающий характеристики фигур.
        /// </summary>
        public static Properties FigureProperties
        {
            get { return _figureProperties; }
            set { _figureProperties = value; }
        }

        /// <summary>
        /// Метод, выполняющий очистку канвы.
        /// </summary>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_workspace.SelectFigure() == false)
            {
                _workspace.DeleteFigure();
                Canvas.Invalidate();
                _fileSave = true;
            }
            else
            {
                _workspace.DeleteSelectFigure();
                Canvas.Refresh();
                _fileSave = true;
            }
        }

        /// <summary>
        /// Метод, выполняющий действия копирование фигуры.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workspace.СopyFigure();
            _fileSave = true;
            Canvas.Refresh();
        }


        /// <summary>
        /// Метод, вырезание выделенных фигур.
        /// </summary>        
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (_activFormMain.SelectFigure() == false)
            {
                _activFormMain.DeleteFigure();
                Canvas.Invalidate();
                _fileSave = true;
            }*/
            if (_workspace.SelectFigure() == true)
            {
                _workspace.DeleteSelectFigure();
                Canvas.Refresh();
                _fileSave = true;
            }
        }

        /// <summary>
        /// Метод, выполняющий вставку вырезанных фигур.
        /// </summary>
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workspace.InsertFigure();
            _fileSave = true;
            Canvas.Refresh();
        }

        /// <summary>
        /// Метод, выполняющий вырезание выделенных фигур.
        /// </summary>
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_workspace.SelectFigure() == true)
            {
                _workspace.CutFigure();
                Canvas.Refresh();
                _fileSave = true;
            }
        }

        /// <summary>
        /// Метод, выполняющий создание нового проекта и сохранение старого.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save previous file??", "Saving", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "dat files (*.dat)|*.dat";                

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                    {                        
                        _workspace.PostStream = stream;
                        _workspace.PostBinarry = binaryFormatter;
                        _workspace.SavingCanvasFigures();
                    }
                }
            }
            NewFile FileDialog = new NewFile();                      
            FileDialog.Text = "New file";                            
            //FileDialog.ShowDialog();                                  

            if (FileDialog.ShowDialog() == DialogResult.OK)                                         
            {
                var UnityContainerInit = new UnityContainer();                                                       
                _workspace.DeleteFigure();
                _workspace.DeleteListActions();
                IndexCommand = -1;
                Canvas.Invalidate();                
                Canvas.Width = FileDialog.ImageWidth;
                Canvas.Height = FileDialog.ImageHeight;                
                Canvas.Refresh();
            }
        }

        /// <summary>
        /// Метод, выполняющийся при нажатии мышки на изменение на кнопку изменения размера канвы.
        /// </summary>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            allowResize = true;
        }

        /// <summary>
        /// Метод, выполняющийся при перемещении мышки на изменение на кнопку изменения размера канвы.
        /// </summary>
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowResize)
            {
                this.Canvas.Height = panel1.Top + e.Y - Canvas.Top;
                this.Canvas.Width = panel1.Left + e.X - Canvas.Left;
                panel1.Location = new Point(Canvas.Location.X + panel1.Width, panel1.Location.Y + panel1.Height);
            }
        }

        /// <summary>
        /// Метод, выполняющийся при отпускании мышки на изменение на кнопку изменения размера канвы.
        /// </summary>
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            allowResize = false;
            panel1.Location = new Point(Canvas.Location.X + Canvas.Width, Canvas.Location.Y + Canvas.Height);
        }

        /// <summary>
        /// Метод, выполняющий сохранение проекта в ыормате JPG, PNG, GIF.
        /// </summary>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDial = new SaveFileDialog();
            //Запрашивает у пользователя местоположение для сохранения файла
            saveFileDial.Filter = "GraphicEditor (*.Png|*.Png";
            //Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*
            saveFileDial.Filter = "Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            saveFileDial.FilterIndex = 0;
            if (saveFileDial.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _workspace.SaveProject().Image.Save(saveFileDial.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch
                {
                    MessageBox.Show("You can't save  file!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Метод, возвращающий индекс действия.
        /// </summary>
        public int IndexCommand
        {
            get
            {
                return _workspace.NumberAction;
            }
            set
            {
                _workspace.NumberAction = value;
            }
        }

        /// <summary>
        /// Метод, выполняющий создание нового проекта.
        /// </summary>
        private void newEXsaveToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "dat files (*.dat)|*.dat";
            //.FilterIndex = 2;
            //saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {   
                using (FileStream stream = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    //binaryFormatter.Serialize(stream, _workspace.ReturnFiguresList());
                    //binaryFormatter.Serialize(stream, _workspace.SavingCanvasFigures());
                    _workspace.PostStream = stream;
                    _workspace.PostBinarry = binaryFormatter;
                    _workspace.SavingCanvasFigures();
                }
            }                
        }

        /// <summary>
        /// Метод, выполняющийся открытие созданного проекта.
        /// </summary>
        private void newEXopenToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "dat files (*.dat)|*.dat";
            //openFileDialog1.FilterIndex = 2;
            // openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                {
                    //if ((myyStream = openFileDialog1.OpenFile()) != null)
                    {
                        //using (myStream)                    
                         using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate))
                         {
                            try
                            {
                                //myyStream.Close();
                                //List<Figure> listDeserialize = (List<Figure>)binaryFormatter.Deserialize(fs);
                                //_workspace.SaveFilee(listDeserialize);
                                _workspace.PostStream = fs;
                                _workspace.PostBinarry = binaryFormatter;
                                _workspace.LoadingCanvasFigures();


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий выбор действия выделение мышью.
        /// </summary>
        private void btnMouseClick_Click(object sender, EventArgs e)
        {
            _currentActions = 2;
            ChangeActions(2);
        }

        /// <summary>
        /// Метод, выполняющий выбор действия выделение областью.
        /// </summary>
        private void btnRectangularBox_Click(object sender, EventArgs e)
        {
            _currentActions = 1;
            ChangeActions(1);
            ChangeFigure(5);
        }

        /// <summary>
        /// Метод, выполняющий выбор действия рисование линии.
        /// </summary>
        private void btnLine_Click(object sender, EventArgs e)
        {
            Draw();

            if (_currentActions == 0)
            {
                ChangeFigure(2);
            }
        }

        /// <summary>
        /// Метод, выполняющий выбор действия рисование прямоугольника.
        /// </summary> 
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            Draw();

            if (_currentActions == 0)
            {
                ChangeFigure(0);
            }
        }

        /// <summary>
        /// Метод, выполняющий выбор действия рисование эллипса.
        /// </summary> 
        private void btnEllipse_Click(object sender, EventArgs e)
        {
            Draw();

            if (_currentActions == 0)
            {
                ChangeFigure(1);
            }
        }

        /// <summary>
        /// Метод, выполняющий выбор действия рисование полилинии.
        /// </summary> 
        private void btnPolyline_Click(object sender, EventArgs e)
        {
            Draw();

            if (_currentActions == 0)
            {
                ChangeFigure(3);
            }
        }

        /// <summary>
        /// Метод, выполняющий выбор действия рисование многоугольника.
        /// </summary> 
        private void btnPolygon_Click(object sender, EventArgs e)
        {
            Draw();

            if (_currentActions == 0)
            {
                ChangeFigure(4);
            }
        }

        /// <summary>
        /// Метод, выполняющий действие "Отменить".
        /// </summary>
        /// <para name = "sender">Переменная, хранящая объект.</para>
        /// <para name = "e">Переменная, хранящая список событий.</para>
        private void btnUnDo_Click(object sender, EventArgs e)
        {
            _workspace.UndoFigure();
            Canvas.Refresh();
            _fileSave = true;
        }

        /// <summary>
        /// Метод, выполняющий действие "Повторить".
        /// </summary>
        /// <para name = "sender">Переменная, хранящая объект.</para>
        /// <para name = "e">Переменная, хранящая список событий.</para>
        private void btnReDo_Click(object sender, EventArgs e)
        {
            _workspace.RedoFigure();
            Canvas.Refresh();
            _fileSave = true;
        }

        /// <summary>
        /// Метод, убирающий заливку у фигуры..
        /// </summary>
        private void btnWithoutFill_Click(object sender, EventArgs e)
        {
            _figureProperties.fill = false;
            if (_workspace.SelectFigure() == true)
            {
                _workspace.DeleteFilled();
                Canvas.Refresh();
                _fileSave = true;
            }
        }

        /// <summary>
        /// Метод, выполняющий действия изменение размера канвы.
        /// </summary>
        private void pbHistory_Click(object sender, EventArgs e)
        {
            HistoryActions HistoryForm = new HistoryActions();
            HistoryForm.Text = "History actions";            
            HistoryForm.DisplayListActions(_workspace.ReturnListActions());
            HistoryForm.ShowDialog();
            HistoryForm.Dispose();
        }
    }
}
