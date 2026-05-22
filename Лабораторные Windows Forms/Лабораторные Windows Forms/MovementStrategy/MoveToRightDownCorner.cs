using System;

namespace Лабораторные_Windows_Forms.MovementStrategy
{
    public class MoveToRightDownCorner : BaseTemplateMovement
    {
        protected override bool IsTargetDestination()
        {
            var obj = GetObjectCoordinates();
            if (obj is null) return false;

            int step = GetStep() ?? 5;
            return Math.Abs(obj.RightBorder - FieldWidth) <= step &&
                   Math.Abs(obj.DownBorder - FieldHeight) <= step;
        }

        protected override void MoveToTarget()
        {
            var obj = GetObjectCoordinates();
            if (obj is null) return;

            int diffX = obj.RightBorder - FieldWidth;
            if (Math.Abs(diffX) > (GetStep() ?? 5))
            {
                if (diffX > 0) MoveLeft();
                else MoveRight();
            }

            int diffY = obj.DownBorder - FieldHeight;
            if (Math.Abs(diffY) > (GetStep() ?? 5))
            {
                if (diffY > 0) MoveUp();
                else MoveDown();
            }
        }
    }
}