using System;

namespace Лабораторные_Windows_Forms.CollectionGenericObjects
{
    public class MassiveGenericObjects<T> : ICollectionGenericObjects<T> where T : class
    {
        private T?[] _collection = Array.Empty<T>();

        public int CountObjects
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _collection.Length; i++)
                    if (_collection[i] != null) count++;
                return count;
            }
        }

        public int MaxCount
        {
            get => _collection.Length;
            set { if (value > 0) Array.Resize(ref _collection, value); }
        }

        public T? GetObject(int position)
        {
            if (position < 0 || position >= _collection.Length)
                return null;
            return _collection[position];
        }

        public bool InsertObject(T obj)
        {
            return InsertObject(obj, 0);
        }

        public bool InsertObject(T obj, int position)
        {
            MessageBox.Show($"InsertObject вызван: position={position}, длина массива={_collection.Length}");

            if (obj == null) { MessageBox.Show("obj == null"); return false; }
            if (_collection.Length == 0) { MessageBox.Show("_collection.Length == 0"); return false; }
            if (position < 0 || position >= _collection.Length) { MessageBox.Show("position вне диапазона"); return false; }

            if (_collection[position] == null)
            {
                _collection[position] = obj;
                MessageBox.Show("Вставлено на позицию " + position);
                return true;
            }

            // поиск справа...
            for (int i = position + 1; i < _collection.Length; i++)
            {
                if (_collection[i] == null)
                {
                    _collection[i] = obj;
                    MessageBox.Show("Вставлено справа на позицию " + i);
                    return true;
                }
            }

            // поиск слева...
            for (int i = 0; i < position; i++)
            {
                if (_collection[i] == null)
                {
                    _collection[i] = obj;
                    MessageBox.Show("Вставлено слева на позицию " + i);
                    return true;
                }
            }

            MessageBox.Show("Свободных мест нет");
            return false;
        }

        public bool RemoveObject(int position)
        {
            if (position < 0 || position >= _collection.Length)
                return false;
            if (_collection[position] == null)
                return false; // уже пусто

            _collection[position] = null;
            return true;
        }
    }
}