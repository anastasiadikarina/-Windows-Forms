using System;
using System.Drawing;
using System.Windows.Forms;
using Лабораторные_Windows_Forms.Drawing;
using Лабораторные_Windows_Forms.Enums;

namespace Лабораторные_Windows_Forms
{
    public partial class Form1 : Form
    {
        private CanvasForLocomotive _canvas;
        private Random _random;

        public Form1()
        {
            InitializeComponent();
            _canvas = new CanvasForLocomotive();
            _random = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                _canvas.SetSize(pictureBox1.Width, pictureBox1.Height);
            }
        }

        private void Draw()
        {
            Bitmap? bmp = _canvas.Draw();
            if (bmp != null) pictureBox1.Image = bmp;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            int speed =10;
            double weight = 100;
            Color color = Color.FromArgb(_random.Next(100, 255), _random.Next(100, 255), _random.Next(100, 255));
            int wheels = 3;

            DrawingLocomotive loco = new DrawingLocomotive();
            loco.Init(speed, weight, color, wheels);

            if (_canvas.Insert(loco))
            {
                _canvas.SetPosition(50, 50);
                Draw();
                Text = $"Тепловоз | Скорость: {speed}, Вес: {weight}";
            }
            else
            {
                MessageBox.Show("Объект слишком большой для поля!");
            }
        }

        private void ButtonMove_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name;
            DirectionType dir = DirectionType.None;

            if (name == "button2") dir = DirectionType.Up;      // ← ваше имя
            else if (name == "button3") dir = DirectionType.Down;
            else if (name == "button4") dir = DirectionType.Left;
            else if (name == "button5") dir = DirectionType.Right;


            if (_canvas.Move(dir)) Draw();
        }
    }
}