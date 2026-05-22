using System.Drawing;

namespace Лабораторные_Windows_Forms.Entities
{
    public class EntityLocomotive
    {
        public int Speed { get; init; }
        public double Weight { get; init; }
        public Color BodyColor { get; init; }
        public int WheelsPerTruck { get; init; }

        public double Step => Speed * 100 / Weight;

        // Конструктор вместо Init
        public EntityLocomotive(int speed, double weight, Color bodyColor, int wheelsPerTruck)
        {
            Speed = speed;
            Weight = weight;
            BodyColor = bodyColor;
            WheelsPerTruck = wheelsPerTruck;
        }
    }
}