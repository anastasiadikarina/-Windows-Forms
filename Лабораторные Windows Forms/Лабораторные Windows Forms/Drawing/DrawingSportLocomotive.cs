using System.Drawing;
using Лабораторные_Windows_Forms.Entities;

namespace Лабораторные_Windows_Forms.Drawing
{
    public class DrawingSportLocomotive : DrawingLocomotive
    {
        public DrawingSportLocomotive(int speed, double weight, Color bodyColor, int wheelsPerTruck,
            Color additionalColor, bool wheelOrnament, bool goldAccents)
            : base(150, 75, speed, weight, bodyColor, wheelsPerTruck)
        {
            _entity = new EntitySportLocomotive(speed, weight, bodyColor, wheelsPerTruck,
                additionalColor, wheelOrnament, goldAccents);
        }

        public override void Draw(Graphics g)
        {
            if (_entity == null || _entity is not EntitySportLocomotive sportLocomotive ||
                !_posX.HasValue || !_posY.HasValue) return;

            int x = _posX.Value;
            int y = _posY.Value;
            Pen blackPen = new Pen(Color.Black, 2);

            int oldX = x;
            int oldY = y;
            _posX = x + 5;
            _posY = y + 3;
            base.Draw(g);
            _posX = oldX;
            _posY = oldY;

            if (sportLocomotive.WheelOrnament)
            {
                Brush ornamentBrush = new SolidBrush(sportLocomotive.AdditionalColor);
                for (int i = 0; i < 3; i++)
                {
                    g.DrawEllipse(new Pen(ornamentBrush, 2), x + 8 + i * 15, y + 48, 12, 12);
                    g.DrawEllipse(new Pen(ornamentBrush, 2), x + 54 + i * 15, y + 48, 12, 12);
                    g.DrawEllipse(new Pen(ornamentBrush, 2), x + 100 + i * 15, y + 48, 12, 12);
                }
            }

            if (sportLocomotive.GoldAccents)
            {
                Brush goldBrush = new SolidBrush(Color.Gold);
                g.DrawLine(new Pen(goldBrush, 3), x + 10, y + 45, x + _width - 10, y + 45);
                g.DrawRectangle(new Pen(goldBrush, 2), x + 35, y + 5, 15, 30);
            }
        }
    }
}