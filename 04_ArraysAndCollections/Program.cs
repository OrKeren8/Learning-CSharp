/* Guy Ronen (C) 2005 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ArraysAndCollections
{
	class Program
	{
		public static void Main()
		{
			Console.WriteLine("Sorting and reversing simple arrays:");
			SortSimpleArray();

			Console.WriteLine("Reversing a Student array:");
			ArrayOfStudents();

			GenericCollection();
            
            Console.WriteLine("Press any key to continue..");
        }

		/// <summary>
		/// This method simply sorting an array of integers
		/// </summary>
		private static void SortSimpleArray()
		{
			// 4 of the ways to initialize the values in an array:
            int[] numbers = new int[4]; // the ints in the array are initialized to 0;
            numbers[0] = 1;
            numbers[1] = 33;
            numbers[2] = 2;
            numbers[3] = 44;
            int[] numbers2 = new int[4] { 1, 33, 2, 44 };
            int[] numbers3 = new int[] { 1, 33, 2, 44 };
            int[] numbers4 = { 1, 33, 2, 44 };

            // float array which will be allocated later:
            float[] floatNumbers = null;
            Console.WriteLine("Please select the size of the float array:");
            int length = int.Parse(Console.ReadLine());
            // initialzing the array by a user input size:
            floatNumbers = new float[length]; // the floats in the array are initialized to 0;
            floatNumbers[0] = 1.1f;

			Console.WriteLine("The int array:");
			PrintArray(numbers);

            Console.WriteLine("The float array:");
            PrintArray(floatNumbers);

			//using one of the static methods of class System.Array:
            System.Array.Sort(numbers);
            System.Array.Sort(floatNumbers);

            Console.WriteLine("The int array (after sorting):");
            PrintArray(numbers);
            Console.WriteLine("The float array (after sorting):");
            PrintArray(floatNumbers);

            ReverseArray(numbers);
            ReverseArray(floatNumbers);

            Console.WriteLine("The int array (after reversing):");
            PrintArray(numbers);
            Console.WriteLine("The float array (after reversing):");
            PrintArray(floatNumbers);

        }

        /// <summary>
        /// This method demonstrates polymorphic printing of arrays
        /// </summary>
        /// <param name="i_ArrayToReverse">The array to print</param>
        private static void PrintArray(System.Array i_ArrayToPrint)
        {
            Console.Write("[");

            // BOXING when iterating value types:
            foreach (object obj in i_ArrayToPrint)
            {
                Console.Write(obj.ToString() + ", ");
            }

            Console.WriteLine("]");
        }

        /// <summary>
        /// This method demonstrates generic printing of arrays
        /// </summary>
        /// <param name="i_ArrayToReverse">The array to print</param>
        private static void PrintArray<T>(T[] i_ArrayToPrint)
        {
            Console.Write("[");

            // NO BOXING when iterating value types:
            foreach (T obj in i_ArrayToPrint)
            {
                Console.Write(obj.ToString() + ", ");
            }

            Console.WriteLine("]");
        }

		/// <summary>
		/// This method demonstrates polymorphic reversing of arrays
		/// </summary>
		/// <param name="i_ArrayToReverse">The array to reverse</param>
		public static void ReverseArray(System.Array i_ArrayToReverse)
		{
			int length = i_ArrayToReverse.Length;
			for (int i = 0; i < length / 2; ++i)
			{
                // BOXING if the value is a value type:
                object tempValue = i_ArrayToReverse.GetValue(i);
				i_ArrayToReverse.SetValue(i_ArrayToReverse.GetValue(length - 1 - i), i);
				i_ArrayToReverse.SetValue(tempValue, length - 1 - i);
			}
		}

        /// <summary>
        /// This method demonstrates generic reversing of arrays
        /// </summary>
        /// <param name="i_ArrayToReverse">The array to reverse</param>
        public static void ReverseArray<T>(T[] i_ArrayToReverse)
        {
            int length = i_ArrayToReverse.Length;
            for (int i = 0; i < length / 2; ++i)
            {
                // NO BOXING if the value is a value type:
                T tempValue = i_ArrayToReverse[i];
                i_ArrayToReverse[i] = i_ArrayToReverse[length - 1 - i];
                i_ArrayToReverse[length - 1 - i] = tempValue;
            }
        }

		/// <summary>
		/// An example for creating and reversing and array of <see cref="Student"/>s
		/// </summary>
		private static void ArrayOfStudents()
		{
			// Initialzing an array of 4 students, all null:
			Student[] students = new Student[4];

			students[0] = new Student(24, 5467765, 120);
			students[1] = new Student(22, 1233245, 122);
			students[2] = new Student(21, 3432345, 121);
			students[3] = new Student(43, 3453453, 125);

            // or :
            students = new Student[4]
            {
                new Student(24, 5467765, 120),
                new Student(22, 1233245, 122),
                new Student(21, 3432345, 121),
                new Student(43, 3453453, 125)
            };

			Console.WriteLine("The array of students:");
			PrintArray(students);

			// using the same general method to reverse the array of students as well:
			ReverseArray(students);

			Console.WriteLine("After reversing:");
			PrintArray(students);
		}

        private static void PolymorphicCollection()
        {
            //*** ArrayList of Value Types ***//
            int capacity = 3;
            ArrayList arrayListOfInts = new ArrayList(capacity);

            // BOXING when adding value types:
            arrayListOfInts.Add(3);
            arrayListOfInts.Add(18);
            arrayListOfInts.Add(15);

            // CASTING IS NEEDED when using the list's indexer:
            int num = (int)arrayListOfInts[0];

            //*** ArrayList of Refecrence Types ***//
            ArrayList arrayListOfStudents = new ArrayList(/* capacity is not mandatory*/);

            arrayListOfStudents.Add(new Student(2, 2222, 200));
            arrayListOfStudents.Add(new Student(3, 3333, 201));
            arrayListOfStudents.Add(new Student(4, 4444, 202));

            // CASTING IS NEEDED when using the list's indexer:
            Student student = (Student)arrayListOfStudents[0];
        }

		private static void GenericCollection()
		{
            //*** List of Refecrence Types ***//
            int capacity = 3;
            List<int> genericListOfInts = new List<int>(capacity);
            // no BOXING when adding value types:
            genericListOfInts.Add(3);
            genericListOfInts.Add(18);
            genericListOfInts.Add(15);
            // NO CASTING IS NEEDED when using the list's indexer:
            int num = genericListOfInts[0];

            //*** List of Refecrence Types ***//
            List<Student> genericListOfStudents = new List<Student>(/* capacity is not mandatory*/);

			genericListOfStudents.Add(new Student(2, 2222, 200));
			genericListOfStudents.Add(new Student(3, 3333, 201));
			genericListOfStudents.Add(new Student(4, 4444, 202));

			// NO CASTING IS NEEDED when using the list's indexer:
			Student student = genericListOfStudents[0];
		}
	}

    /// <summary>
    /// An example of a Reference Type with an overriden version of ToString
    /// </summary>
	class Student
	{
		public int Age = 0;
		public int ID = 0;
		public int NumOfCourses = 0;
		public string Name = string.Empty;

		public Student(int i_Age, int i_ID, int i_NumOfCourses)
		{
			this.Age = i_Age;
			this.ID = i_ID;
			this.NumOfCourses = i_NumOfCourses;
		}

		public override string ToString()
		{
			return ID.ToString();
		}
	}
}

