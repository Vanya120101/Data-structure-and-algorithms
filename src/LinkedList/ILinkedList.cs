namespace LinkedListImplementation
{
	public interface ILinkedList<T>
	{
		int Count { get; }

		void Add(T value);
		void Clear();
		bool Contains(T item);
		void CopyTo(T[] array, int arrayIndex);
		IEnumerator<T> GetEnumerator();
		bool Remove(T item);
	}
}