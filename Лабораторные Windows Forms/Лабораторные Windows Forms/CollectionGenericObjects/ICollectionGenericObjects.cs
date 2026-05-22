namespace Лабораторные_Windows_Forms.CollectionGenericObjects
{
    public interface ICollectionGenericObjects<T> where T : class
    {
        int CountObjects { get; }

        int MaxCount { get; set; }

        T? GetObject(int position);

        bool InsertObject(T obj);
        bool InsertObject(T obj, int position);
        bool RemoveObject(int position);
    }
}