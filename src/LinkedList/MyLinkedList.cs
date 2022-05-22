using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation;

public class MyLinkedList<T> : ILinkedList<T>, IEnumerable<T>
{
	private MyLinkedListNode<T>? _head;
	private MyLinkedListNode<T>? _tail;

	public int Count { get; private set; }

	public void Add(T value)
	{
		if(_head == null)
		{
			_head = new MyLinkedListNode<T>(value);
			_tail = _head;
		}
		else
		{
			_tail!.Next = new MyLinkedListNode<T>(value);
			_tail = _tail.Next;
		}

		Count++;
	}

	public void Clear()
	{
		_head = null;
		_tail = null;
		Count = 0;
	}

	public bool Contains(T item)
	{
		var current = _head;
		while(current != null)
		{
			if(current!.Value!.Equals(item))
			{
				return true;
			}
			current = current.Next;
		}

		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		var current = _head;

		while(current != null)
		{
			array[arrayIndex++] = current.Value;
			current = current.Next;
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		var current = _head;
		while(current != null)
		{
			yield return current.Value;
			current = current.Next;
		}
	}

	public bool Remove(T item)
	{
		MyLinkedListNode<T>? previous = null;
		var current = _head;

		while(current != null)
		{
			if(current!.Value!.Equals(item))
			{
				if(current == _head)
				{
					_head = _head.Next;
					if(_head == null)
					{
						_tail = null;
					}
				}

				if(previous != null)
				{
					previous.Next = current.Next;

					if(previous.Next == null)
					{
						_tail = previous;
					}
				}
				Count--;
				return true;
			}
			previous = current;
			current = current.Next;
		}
		return false;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<T>)this).GetEnumerator();
	}
}
