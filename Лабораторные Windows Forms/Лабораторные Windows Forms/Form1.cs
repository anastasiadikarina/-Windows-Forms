using System;
using System.Drawing;
using System.Windows.Forms;
using Лабораторные_Windows_Forms.Drawing;
using Лабораторные_Windows_Forms.Enums;
using Лабораторные_Windows_Forms.MovementStrategy;

namespace Лабораторные_Windows_Forms
{
    public partial class Form1 : Form
    {
        private CanvasForLocomotive _canvas;
        private Random _random;
        private BaseTemplateMovement? _templateMovement;

        public Form1()
        {
            InitializeComponent();
            _canvas = new CanvasForLocomotive();
            _random = new Random();
        }
        public void SetDrawingLocomotive(DrawingLocomotive loco)
        {
            if (_canvas.Insert(loco))
            {
                _canvas.SetPosition(50, 50);
                comboBoxDestination.Enabled = true;
                comboBoxDestination.SelectedIndex = -1;
                buttonStep.Enabled = false;
                Draw();
                Text = "Тепловоз получен из депо";
            }
            else
            {
                MessageBox.Show("Не удалось разместить объект на поле");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                _canvas.SetSize(pictureBox1.Width, pictureBox1.Height);
            }

            comboBoxDestination.Items.Clear();
            comboBoxDestination.Items.Add("К центру");
            comboBoxDestination.Items.Add("В правый нижний угол");
            comboBoxDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDestination.Enabled = false;
            buttonStep.Enabled = false;
        }

        private void Draw()
        {
            Bitmap? bmp = _canvas.Draw();
            if (bmp != null) pictureBox1.Image = bmp;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            int speed = 10;
            double weight = 100;
            Color color = Color.FromArgb(_random.Next(100, 255), _random.Next(100, 255), _random.Next(100, 255));
            int wheels = 3;

            DrawingLocomotive loco = new DrawingLocomotive(speed, weight, color, wheels);

            if (_canvas.Insert(loco))
            {
                _canvas.SetPosition(50, 50);
                comboBoxDestination.Enabled = true;
                comboBoxDestination.SelectedIndex = -1;
                buttonStep.Enabled = false;
                Draw();
                Text = $"Тепловоз (простой) | Скорость: {speed}, Вес: {weight}";
            }
        }

        private void ButtonCreateSport_Click(object sender, EventArgs e)
        {
            int speed = 10;
            double weight = 100;
            Color color = Color.FromArgb(_random.Next(100, 255), _random.Next(100, 255), _random.Next(100, 255));
            int wheels = 3;
            Color additionalColor = Color.FromArgb(_random.Next(100, 255), _random.Next(100, 255), _random.Next(100, 255));
            bool wheelOrnament = _random.Next(0, 2) == 1;
            bool goldAccents = _random.Next(0, 2) == 1;

            DrawingSportLocomotive loco = new DrawingSportLocomotive(speed, weight, color, wheels,
                additionalColor, wheelOrnament, goldAccents);

            if (_canvas.Insert(loco))
            {
                _canvas.SetPosition(50, 50);
                comboBoxDestination.Enabled = true;
                comboBoxDestination.SelectedIndex = -1;
                buttonStep.Enabled = false;
                Draw();
                Text = $"Тепловоз (продвинутый) | Орнамент: {wheelOrnament}, Золото: {goldAccents}";
            }
        }

        private void ButtonMove_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name;
            DirectionType dir = DirectionType.None;

            if (name == "button2") dir = DirectionType.Up;
            else if (name == "button3") dir = DirectionType.Down;
            else if (name == "button4") dir = DirectionType.Left;
            else if (name == "button5") dir = DirectionType.Right;

            if (_canvas.Move(dir)) Draw();
        }

        private void ComboBoxDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_canvas.DrawingLocomotive == null) return;

            _templateMovement = comboBoxDestination.SelectedIndex switch
            {
                0 => new MoveToCenter(),
                1 => new MoveToRightDownCorner(),
                _ => null
            };

            if (_templateMovement != null)
            {
                _templateMovement.SetData(new MoveableAdapterLocomotive(_canvas.DrawingLocomotive),
                    pictureBox1.Width, pictureBox1.Height);
                comboBoxDestination.Enabled = false;
                buttonStep.Enabled = true;
            }
        }

        private void ButtonStep_Click(object sender, EventArgs e)
        {
            if (_templateMovement == null) return;

            _templateMovement.MakeStep();
            Draw();

            if (_templateMovement.IsFinishReached)
            {
                comboBoxDestination.Enabled = true;
                buttonStep.Enabled = false;
                comboBoxDestination.SelectedIndex = -1;
                MessageBox.Show("Цель достигнута!", "Успех");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}