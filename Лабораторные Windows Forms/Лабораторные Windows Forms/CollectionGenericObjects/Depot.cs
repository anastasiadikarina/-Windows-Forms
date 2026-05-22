using System.Drawing;
using Лабораторные_Windows_Forms.Drawing;

namespace Лабораторные_Windows_Forms.CollectionGenericObjects
{
    public class Depot : AbstractCompany
    {
        public Depot(int pictureWidth, int pictureHeight, ICollectionGenericObjects<DrawingLocomotive> collection)
            : base(pictureWidth, pictureHeight, 150, 80, collection)
        {
        }

        protected override void DrawBackground(Graphics g)
        {
            g.Clear(Color.LightGray);
            Pen linePen = new Pen(Color.DarkGray, 2);
            int cols = _pictureWidth / _placeWidth;
            int rows = _pictureHeight / _placeHeight;

            for (int row = 0; row <= rows; row++)
                g.DrawLine(linePen, 0, row * _placeHeight, _pictureWidth, row * _placeHeight);
            for (int col = 0; col <= cols; col++)
                g.DrawLine(linePen, col * _placeWidth, 0, col * _placeWidth, _pictureHeight);
        }

        protected override void DrawObjects(Graphics g)
        {
            for (int i = 0; i < _collection.MaxCount; i++)
            {
                var loco = _collection.GetObject(i);
                if (loco != null)
                {
                    var (x, y) = GetCellPosition(i);
                    int? oldX = loco.PosX;
                    int? oldY = loco.PosY;
                    loco.SetPosition(x, y);
                    loco.Draw(g);
                    if (oldX.HasValue && oldY.HasValue)
                        loco.SetPosition(oldX.Value, oldY.Value);
                    else
                        loco.SetPosition(0, 0);
                }
            }
        }
    }
}