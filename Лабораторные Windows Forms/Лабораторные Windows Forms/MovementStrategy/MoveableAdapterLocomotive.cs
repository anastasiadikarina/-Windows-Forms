using System.Drawing;
using Лабораторные_Windows_Forms.Drawing;

namespace Лабораторные_Windows_Forms.MovementStrategy
{
    public class MoveableAdapterLocomotive : IMoveableObject
    {
        private readonly DrawingLocomotive _locomotive;

        public MoveableAdapterLocomotive(DrawingLocomotive locomotive)
        {
            _locomotive = locomotive;
        }

        public ObjectCoordinates? ObjectCoordinates
        {
            get
            {
                if (_locomotive == null || !_locomotive.PosX.HasValue || !_locomotive.PosY.HasValue)
                    return null;
                return new ObjectCoordinates(_locomotive.PosX.Value, _locomotive.PosY.Value,
                    _locomotive.Width, _locomotive.Height);
            }
        }

        public int ObjectStep => (int)(_locomotive?.Step ?? 0);

        public void MoveObject(MovementDirection direction)
        {
            switch (direction)
            {
                case MovementDirection.Left: _locomotive?.MoveLeft(); break;
                case MovementDirection.Up: _locomotive?.MoveUp(); break;
                case MovementDirection.Right: _locomotive?.MoveRight(); break;
                case MovementDirection.Down: _locomotive?.MoveDown(); break;
            }
        }

        public void SetObjectPosition(int x, int y) => _locomotive?.SetPosition(x, y);
        public void DrawObject(Graphics graphics) => _locomotive?.Draw(graphics);
    }
}