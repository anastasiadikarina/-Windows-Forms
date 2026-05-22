using System;

namespace Лабораторные_Windows_Forms.MovementStrategy
{
    public class MoveToCenter : BaseTemplateMovement
    {
        protected override bool IsTargetDestination()
        {
            var obj = GetObjectCoordinates();
            if (obj is null) return false;

            int step = GetStep() ?? 5;
            return Math.Abs(obj.ObjectMiddleHorizontal - FieldWidth / 2) <= step &&
                   Math.Abs(obj.ObjectMiddleVertical - FieldHeight / 2) <= step;
        }

        protected override void MoveToTarget()
        {
            var obj = GetObjectCoordinates();
            if (obj is null) return;

            int diffX = obj.ObjectMiddleHorizontal - FieldWidth / 2;
            if (Math.Abs(diffX) > (GetStep() ?? 5))
            {
                if (diffX > 0) MoveLeft();
                else MoveRight();
            }

            int diffY = obj.ObjectMiddleVertical - FieldHeight / 2;
            if (Math.Abs(diffY) > (GetStep() ?? 5))
            {
                if (diffY > 0) MoveUp();
                else MoveDown();
            }
        }
    }
}