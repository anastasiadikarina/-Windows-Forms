using System.Drawing;

namespace Лабораторные_Windows_Forms.Entities
{
    public class EntityLocomotive
    {
        public int Speed { get; private set; }
        public double Weight { get; private set; }
        public Color BodyColor { get; private set; }
        public int WheelsPerTruck { get; private set; }

        public double Step => Speed * 5 + 5;

        public void Init(int speed, double weight, Color bodyColor, int wheelsPerTruck)
        {
            Speed = speed;
            Weight = weight;
            BodyColor = bodyColor;
            WheelsPerTruck = wheelsPerTruck;
        }
    }
}