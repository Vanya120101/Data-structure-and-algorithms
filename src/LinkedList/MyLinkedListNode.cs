using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList;

public class MyLinkedListNode<T>
{
	[NotNull]
	public T Value { get; set; }
	public MyLinkedListNode<T>? Next { get; set; }


	public MyLinkedListNode(T value)
	{
		Value = value!;
	}
}
