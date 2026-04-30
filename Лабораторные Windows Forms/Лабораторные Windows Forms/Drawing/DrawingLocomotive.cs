using System;
using System.Drawing;
using Лабораторные_Windows_Forms.Entities;

namespace Лабораторные_Windows_Forms.Drawing
{
    public class DrawingLocomotive
    {
        private EntityLocomotive? _entity;
        private int? _posX;
        private int? _posY;

        private readonly int _width = 140;
        private readonly int _height = 70;

        public int? PosX => _posX;
        public int? PosY => _posY;
        public double? Step => _entity?.Step;
        public int Width => _width;
        public int Height => _height;

        public void Init(int speed, double weight, Color bodyColor, int wheelsPerTruck)
        {
            _entity = new EntityLocomotive();
            _entity.Init(speed, weight, bodyColor, wheelsPerTruck);
            _posX = null;
            _posY = null;
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

        public void Draw(Graphics g)
        {
            if (_entity == null || !_posX.HasValue || !_posY.HasValue) return;

            int x = _posX.Value;
            int y = _posY.Value;

            Pen blackPen = new Pen(Color.Black, 2);
            Brush bodyBrush = new SolidBrush(_entity.BodyColor);

            // КОРПУС
            g.FillRectangle(bodyBrush, x, y + 30, 140, 35);
            g.DrawRectangle(blackPen, x, y + 30, 140, 35);

            // КАБИНА
            g.FillRectangle(bodyBrush, x + 100, y + 15, 40, 25);
            g.DrawRectangle(blackPen, x + 100, y + 15, 40, 25);

            // Окошки
            g.FillRectangle(Brushes.White, x + 108, y + 22, 10, 8);
            g.DrawRectangle(blackPen, x + 108, y + 22, 10, 8);
            g.FillRectangle(Brushes.White, x + 122, y + 22, 10, 8);
            g.DrawRectangle(blackPen, x + 122, y + 22, 10, 8);

            // ТРУБА
            g.FillRectangle(Brushes.DarkGray, x + 35, y + 5, 15, 30);
            g.DrawRectangle(blackPen, x + 35, y + 5, 15, 30);
            g.FillRectangle(Brushes.Red, x + 37, y + 2, 11, 5);

            // ДЫМ
            g.FillEllipse(Brushes.LightGray, x + 32, y - 5, 10, 10);
            g.FillEllipse(Brushes.LightGray, x + 28, y - 15, 12, 12);
            g.FillEllipse(Brushes.LightGray, x + 35, y - 25, 14, 14);

            // БАК С ТОПЛИВОМ
            g.FillRectangle(Brushes.DarkOliveGreen, x + 5, y + 20, 30, 20);
            g.DrawRectangle(blackPen, x + 5, y + 20, 30, 20);

            // ФАРА
            g.FillEllipse(Brushes.Yellow, x + 135, y + 42, 8, 8);
            g.DrawEllipse(blackPen, x + 135, y + 42, 8, 8);

            // КОЛЕСА
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
    }
}