using Лабораторные_Windows_Forms.MovementStrategy;

namespace Лабораторные_Windows_Forms.MovementStrategy
{
    public static class TemplateMovementFactory
    {
        public static string[] Values => new[] { "К центру", "В правый нижний угол" };

        public static BaseTemplateMovement? CreateTemplateMovement(string value)
        {
            return value switch
            {
                "К центру" => new MoveToCenter(),
                "В правый нижний угол" => new MoveToRightDownCorner(),
                _ => null
            };
        }
    }
}