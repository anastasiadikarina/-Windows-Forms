using System.Drawing;

namespace Лабораторные_Windows_Forms.MovementStrategy
{
    public interface IMoveableObject
    {
        ObjectCoordinates? ObjectCoordinates { get; }
        int ObjectStep { get; }
        void SetObjectPosition(int x, int y);
        void MoveObject(MovementDirection direction);
        void DrawObject(Graphics graphics);
    }
}