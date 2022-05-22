using LinkedListImplementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructureAndAlgorithms.Tests
{
	public class LinkedListTests
	{
		private MyLinkedList<int> _linkedList;

		[SetUp]
		public void Setup()
		{
			_linkedList = new MyLinkedList<int>();
		}

		#region AddTest

		[TestCase(5)]
		[TestCase(10)]
		[TestCase(15)]
		[TestCase(20)]
		[TestCase(25)]
		[TestCase(30)]
		[TestCase(100)]
		[TestCase(500)]
		[TestCase(600)]
		public void AddTest_AddedSome_ReturnedTheSameCount(int countOfValue)
		{
			//Arrange
			var expetctedCount = countOfValue;
			var random = new Random();

			//Act
			for(int i = 0; i < countOfValue; i++)
			{
				_linkedList.Add(random.Next(int.MinValue, int.MaxValue));
			}

			//Assert
			Assert.That(_linkedList.Count, Is.EqualTo(expetctedCount));
		}

		#endregion

		[TestCase(5)]
		[TestCase(10)]
		[TestCase(15)]
		[TestCase(20)]
		[TestCase(25)]
		[TestCase(30)]
		[TestCase(100)]
		[TestCase(500)]
		[TestCase(600)]
		public void AddTest_AddedElement_ContainsReturnedTrue(int countOfValue)
		{
			//Arrange
			var expectedElements = new List<int>();

			var random = new Random();
			for(int i = 0; i < countOfValue; i++)
			{
				expectedElements.Add(random.Next(int.MinValue, int.MaxValue));
			}


			//Act

			foreach(var element in expectedElements)
			{
				_linkedList.Add(element);
			}

			foreach(var elements in expectedElements)
			{
				var result = _linkedList.Contains(elements);
				Assert.IsTrue(result);
			}
		}

		[TestCase(5)]
		[TestCase(10)]
		[TestCase(15)]
		[TestCase(20)]
		[TestCase(25)]
		[TestCase(30)]
		[TestCase(100)]
		[TestCase(500)]
		[TestCase(600)]
		public void RemoveTest_AddedElementThenRemoveElement_ContainsReturnedFalse(int elementsCount)
		{
			//Arrange
			var random  = new Random();

			var expectedRemovedElement = random.Next(int.MinValue, int.MaxValue);

			for(int i = 0; i < elementsCount-1; i++)
			{
				var number = random.Next(int.MinValue, int.MaxValue);
				while(number == expectedRemovedElement)
				{
					random.Next(int.MinValue, int.MaxValue);
				}
				_linkedList.Add(number);
			}

			//Act
			_linkedList.Remove(expectedRemovedElement);
			var result = _linkedList.Contains(expectedRemovedElement);

			//Assert
			Assert.IsFalse(result);
			Assert.That(_linkedList.Count, Is.EqualTo(elementsCount - 1));
		}

		[TestCase(5)]
		[TestCase(10)]
		[TestCase(15)]
		[TestCase(20)]
		[TestCase(25)]
		[TestCase(30)]
		[TestCase(100)]
		[TestCase(500)]
		[TestCase(600)]
		public void ClearTest_AddedElementThenClearElement_ThereIsNotElement(int elementsCount)
		{
			//Arrange
			var random = new Random();
			for(int i = 0; i < elementsCount; i++)
			{
				var number = random.Next(int.MinValue, int.MaxValue);
				_linkedList.Add(number);
			}

			for(int i = 0; i < 10; i++)
			{
				_linkedList.Add(i);
			}
			//Act
			_linkedList.Clear();

			for(int i = 0; i < 10; i++)
			{
				var result = _linkedList.Contains(i);
				Assert.IsFalse(result);
			}

			//Assert
			Assert.That(_linkedList.Count, Is.EqualTo(0));
		}

		[TestCase(5)]
		[TestCase(10)]
		[TestCase(15)]
		[TestCase(20)]
		[TestCase(25)]
		[TestCase(30)]
		[TestCase(100)]
		[TestCase(500)]
		[TestCase(600)]
		public void GetEnumeratorTest_AddedElement_ReturnedTheSameElements(int elementsCount)
		{
			//Arrange
			var random = new Random();

			var elementsList = new List<int>();
			for(int i = 0; i < elementsCount; i++)
			{
				var number = random.Next(int.MinValue, int.MaxValue);
				elementsList.Add(number);
			}

			foreach(var element in elementsList)
			{
				_linkedList.Add(element);
			}

			//Act
			int count = 0;
			foreach(var element in _linkedList)
			{
				Assert.That(element, Is.EqualTo(elementsList[count]));
				count++;
			}
		}

		[TestCase(5)]
		[TestCase(10)]
		[TestCase(15)]
		[TestCase(20)]
		[TestCase(25)]
		[TestCase(30)]
		[TestCase(100)]
		[TestCase(500)]
		[TestCase(600)]
		public void CopyToTest_AddedElement_CopyToArray(int elementsCount)
		{
			//Arrange
			var random = new Random();

			var elementsList = new List<int>();
			for(int i = 0; i < elementsCount; i++)
			{
				var number = random.Next(int.MinValue, int.MaxValue);
				elementsList.Add(number);
			}

			foreach(var element in elementsList)
			{
				_linkedList.Add(element);
			}

			int[] array = new int[_linkedList.Count];
			//Act

			_linkedList.CopyTo(array, 0);

			//Assert
			CollectionAssert.AreEqual(array, elementsList);
		}

	}
}