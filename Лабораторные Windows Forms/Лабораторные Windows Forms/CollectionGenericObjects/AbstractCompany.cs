using System;
using System.Drawing;
using Лабораторные_Windows_Forms.Drawing;

namespace Лабораторные_Windows_Forms.CollectionGenericObjects
{
    public abstract class AbstractCompany
    {
        protected readonly int _placeWidth;      
        protected readonly int _placeHeight;     
        protected readonly int _pictureWidth;
        protected readonly int _pictureHeight;
        protected ICollectionGenericObjects<DrawingLocomotive> _collection;

        protected AbstractCompany(int pictureWidth, int pictureHeight,
            int placeWidth, int placeHeight,
            ICollectionGenericObjects<DrawingLocomotive> collection)
        {
            _pictureWidth = pictureWidth;
            _pictureHeight = pictureHeight;
            _placeWidth = placeWidth;
            _placeHeight = placeHeight;
            _collection = collection;
            _collection.MaxCount = CalcMaxCount();
        }

        public static bool operator +(AbstractCompany company, DrawingLocomotive car)
        {
            return company._collection.InsertObject(car);
        }

        public static bool operator -(AbstractCompany company, int position)
        {
            return company._collection.RemoveObject(position);
        }

        public DrawingLocomotive? GetRandomObject()
        {
            Random rnd = new Random();
            int max = _collection.CountObjects;
            if (max == 0) return null;

            for (int attempt = 0; attempt < 20; attempt++)
            {
                int index = rnd.Next(_collection.MaxCount);
                var obj = _collection.GetObject(index);
                if (obj != null) return obj;
            }
            return null;
        }

        public Bitmap? Show()
        {
            Bitmap bmp = new Bitmap(_pictureWidth, _pictureHeight);
            using Graphics g = Graphics.FromImage(bmp);
            DrawBackground(g);
            DrawObjects(g);
            return bmp;
        }

        protected abstract void DrawBackground(Graphics g);
        protected abstract void DrawObjects(Graphics g);

        private int CalcMaxCount()
        {
            int cols = _pictureWidth / _placeWidth;
            int rows = _pictureHeight / _placeHeight;
            return cols * rows;
        }

        protected (int x, int y) GetCellPosition(int index)
        {
            int cols = _pictureWidth / _placeWidth;
            int row = index / cols;
            int col = index % cols;
            int x = col * _placeWidth;
            int y = row * _placeHeight;
            return (x, y);
        }
    }
}