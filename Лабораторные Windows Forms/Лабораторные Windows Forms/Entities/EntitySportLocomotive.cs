using System.Drawing;

namespace Лабораторные_Windows_Forms.Entities
{
    public class EntitySportLocomotive : EntityLocomotive
    {
        public Color AdditionalColor { get; init; }  
        public bool WheelOrnament { get; init; }    
        public bool GoldAccents { get; init; }      
        public EntitySportLocomotive(int speed, double weight, Color bodyColor, int wheelsPerTruck,
            Color additionalColor, bool wheelOrnament, bool goldAccents)
            : base(speed, weight, bodyColor, wheelsPerTruck)
        {
            AdditionalColor = additionalColor;
            WheelOrnament = wheelOrnament;
            GoldAccents = goldAccents;
        }
    }
}