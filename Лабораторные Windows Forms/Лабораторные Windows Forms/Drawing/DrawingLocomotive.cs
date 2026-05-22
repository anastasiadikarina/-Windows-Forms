using System;
using System.Drawing;
using Лабораторные_Windows_Forms.Entities;

namespace Лабораторные_Windows_Forms.Drawing
{
    public class DrawingLocomotive
    {
        protected EntityLocomotive? _entity;
        protected int? _posX;
        protected int? _posY;
        protected int _width = 140;
        protected int _height = 70;

        public int? PosX => _posX;
        public int? PosY => _posY;
        public double? Step => _entity?.Step;
        public int Width => _width;
        public int Height => _height;

        private DrawingLocomotive()
        {
            _posX = null;
            _posY = null;
        }

        public DrawingLocomotive(int speed, double weight, Color bodyColor, int wheelsPerTruck)
            : this()
        {
            _entity = new EntityLocomotive(speed, weight, bodyColor, wheelsPerTruck);
        }

        protected DrawingLocomotive(int width, int height, int speed, double weight, Color bodyColor, int wheelsPerTruck)
            : this(speed, weight, bodyColor, wheelsPerTruck)
        {
            _width = width;
            _height = height;
        }

        public void SetPosition(int x, int y)
        {
            _posX = x;
            _posY = y;
        }

        public void MoveLeft() { if (_entity != null && _posX.HasValue) _posX -= (int)_entity.Step; }
        public void MoveRight() { if (_entity != null && _posX.HasValue) _posX += (int)_entity.Step; }
        public void MoveUp() { if (_entity != null && _posY.HasValue) _posY -= (int)_entity.Step; }
        public void MoveDown() { if (_entity != null && _posY.HasValue) _posY += (int)_entity.Step; }

        public virtual void Draw(Graphics g)
        {
            if (_entity == null || !_posX.HasValue || !_posY.HasValue) return;

            int x = _posX.Value;
            int y = _posY.Value;

            Pen blackPen = new Pen(Color.Black, 2);
            Brush bodyBrush = new SolidBrush(_entity.BodyColor);

            g.FillRectangle(bodyBrush, x, y + 30, _width, 35);
            g.DrawRectangle(blackPen, x, y + 30, _width, 35);

            g.FillRectangle(bodyBrush, x + _width - 40, y + 15, 40, 25);
            g.DrawRectangle(blackPen, x + _width - 40, y + 15, 40, 25);

            g.FillRectangle(Brushes.LightBlue, x + _width - 32, y + 22, 10, 8);
            g.FillRectangle(Brushes.LightBlue, x + _width - 18, y + 22, 10, 8);

            g.FillRectangle(Brushes.DarkGray, x + 35, y + 5, 15, 30);
            g.DrawRectangle(blackPen, x + 35, y + 5, 15, 30);
            g.FillRectangle(Brushes.Red, x + 37, y + 2, 11, 5);

            g.FillEllipse(Brushes.LightGray, x + 32, y - 5, 10, 10);
            g.FillEllipse(Brushes.LightGray, x + 28, y - 15, 12, 12);
            g.FillEllipse(Brushes.LightGray, x + 35, y - 25, 14, 14);

            g.FillRectangle(Brushes.DarkOliveGreen, x + 5, y + 20, 30, 20);
            g.DrawRectangle(blackPen, x + 5, y + 20, 30, 20);

            g.FillEllipse(Brushes.Yellow, x + _width - 5, y + 42, 8, 8);

            for (int i = 0; i < 3; i++)
            {
                g.FillEllipse(Brushes.Black, x + 8 + i * 15, y + 48, 12, 12);
                g.FillEllipse(Brushes.Black, x + 54 + i * 15, y + 48, 12, 12);
                g.FillEllipse(Brushes.Black, x + 100 + i * 15, y + 48, 12, 12);
                g.DrawEllipse(blackPen, x + 8 + i * 15, y + 48, 12, 12);
                g.DrawEllipse(blackPen, x + 54 + i * 15, y + 48, 12, 12);
                g.DrawEllipse(blackPen, x + 100 + i * 15, y + 48, 12, 12);
            }
        }
        public int RealWidth => _width + 15;
        public int RealHeight => _height + 35;
        public int RealOffsetX => -5;
        public int RealOffsetY => -25;
    }
}