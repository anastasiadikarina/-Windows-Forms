using System;
using System.Drawing;
using Лабораторные_Windows_Forms.Drawing;
using Лабораторные_Windows_Forms.Enums;

namespace Лабораторные_Windows_Forms
{
    public class CanvasForLocomotive
    {
        private DrawingLocomotive? _drawing;
        private int? _canvasWidth;
        private int? _canvasHeight;

        public void SetSize(int width, int height)
        {
            _canvasWidth = width;
            _canvasHeight = height;
        }

        public bool Insert(DrawingLocomotive locomotive)
        {
            if (!_canvasWidth.HasValue || !_canvasHeight.HasValue) return false;
            if (locomotive.Width > _canvasWidth.Value || locomotive.Height > _canvasHeight.Value) return false;

            _drawing = locomotive;
            return true;
        }
        public void SetPosition(int x, int y)
        {
            if (_drawing == null || !_canvasWidth.HasValue || !_canvasHeight.HasValue) return;

            int newX = x;
            int newY = y;

            if (newX < 0) newX = 0;

            if (newY < 0) newY = 0;

            if (newX + _drawing.Width > _canvasWidth.Value)
                newX = _canvasWidth.Value - _drawing.Width;

            if (newY + _drawing.Height > _canvasHeight.Value)
                newY = _canvasHeight.Value - _drawing.Height;

            _drawing.SetPosition(newX, newY);
        }

        public bool Move(DirectionType direction)
        {
            if (_drawing == null || !_drawing.PosX.HasValue || !_drawing.PosY.HasValue || !_drawing.Step.HasValue)
                return false;

            int step = (int)_drawing.Step.Value;
            if (step < 1) step = 5; 

            int newX = _drawing.PosX.Value;
            int newY = _drawing.PosY.Value;

            
            switch (direction)
            {
                case DirectionType.Left: newX -= step; break;
                case DirectionType.Right: newX += step; break;
                case DirectionType.Up: newY -= step; break;
                case DirectionType.Down: newY += step; break;
                default: return false;
            }

            
            if (newX < 0) return false;

            if (newY < 0) return false;

            
            if (_canvasWidth.HasValue && newX + _drawing.Width > _canvasWidth.Value)
                return false;

            
            if (_canvasHeight.HasValue && newY + _drawing.Height > _canvasHeight.Value)
                return false;

            
            switch (direction)
            {
                case DirectionType.Left: _drawing.MoveLeft(); break;
                case DirectionType.Right: _drawing.MoveRight(); break;
                case DirectionType.Up: _drawing.MoveUp(); break;
                case DirectionType.Down: _drawing.MoveDown(); break;
            }
            return true;
        }

        public Bitmap? Draw()
        {
            if (!_canvasWidth.HasValue || !_canvasHeight.HasValue) return null;

            Bitmap bmp = new Bitmap(_canvasWidth.Value, _canvasHeight.Value);
            using Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.LightBlue);

            _drawing?.Draw(g);
            return bmp;
        }

        public DrawingLocomotive? DrawingLocomotive => _drawing;
    }
}