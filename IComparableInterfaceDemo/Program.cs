// IComparable and IComparabl<T> Interface Demo
using System;

namespace IComparableInterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person { FirstName = "Håkan", LastName = "Johansson", BirthYear = 1962 },
                new Person { FirstName = "Pontus", LastName = "Wittenmark", BirthYear = 1979 },
                new Person { FirstName = "Hanna E", LastName = "Andersson", BirthYear = 1991 },
                new Person { FirstName = "Gunnar", LastName = "Andersson", BirthYear = 1993 },
                new Person { FirstName = "Gunnar", LastName = "Andersson", BirthYear = 1939 }
            };

            SelectionSort(people); // IComparable
            SelectionSortGeneric(people); // IComparable<T>

            Address[] addresses = new Address[]
            {
                new Address { Street = "Kvarnskogsvägen 8", City = "Sundsvall", Zip = "19253" },
                new Address { Street = "Kvarnskogsvägen 8", City = "Sollentuna", Zip = "19253" },
                new Address { Street = "Hamngatan 38", City = "Stockholm", Zip = "110 11" },
                new Address { Street = "Borgarfjordsgatan 4", City = "Kista", Zip = "222 22" },
                new Address { Street = "Flottarestigen 1", City = "Sollentuna", Zip = "19253" },
                new Address { Street = "Kvarnskogsvägen 8", City = "Sollentuna", Zip = "19251" },
            };

            SelectionSort(addresses); // IComparable
            SelectionSortGeneric(addresses); // IComparable<T>

            string[] Names = { "David", "Cecila", "Bertil", "Anna", "Erika" };
            SelectionSort(Names); // IComparable
            SelectionSortGeneric(Names); // IComparable<T>

            int[] Numbers = { 5, 3, 2, 1, 4 };
            //SelectionSort(Numbers); // int implements IComparable but won't compile as int is a struct.
            //SelectionSortGeneric(Numbers); // int implements IComparable<int32> but won't compile as int is a struct.
        }

        private static void SelectionSort(IComparable[] anyArray)
        {
            for (int i = 0; i <= anyArray.Length - 2; i++)
            {
                int li = i;

                for (int j = i + 1; j <= anyArray.Length - 1; j++)
                    if (anyArray[j].CompareTo(anyArray[li]) == -1)
                        li = j;

                if (li != i)
                {
                    IComparable tmp = anyArray[i];
                    anyArray[i] = anyArray[li];
                    anyArray[li] = tmp;
                }
            }
        }

        private static void SelectionSortGeneric<T>(T[] anyArray) where T : IComparable<T>
        {
            for (int i = 0; i <= anyArray.Length - 2; i++)
            {
                int li = i;

                for (int j = i + 1; j <= anyArray.Length - 1; j++)
                    if (anyArray[j].CompareTo(anyArray[li]) == -1)
                        li = j;

                if (li != i)
                {
                    T tmp = anyArray[i];
                    anyArray[i] = anyArray[li];
                    anyArray[li] = tmp;
                }
            }
        }

        private static void SelectionSortGenericAlternate<T>(T[] anyArray) where T : IComparable<T>
        {
            for (int i = 0; i < anyArray.Length - 1 ; i++)
            {
                int li = FindIndexOfElementHavingTheLowestValue(anyArray, i);

                if (li != i)
                    SwapElements(anyArray, li, i);
            }

            int FindIndexOfElementHavingTheLowestValue(T[] anyArray, int lowestValueIndex)
            {
                int li = lowestValueIndex;

                for (int i = lowestValueIndex + 1; i < anyArray.Length; i++)
                {
                    if (anyArray[i].CompareTo(anyArray[li]) == -1)
                        li = i;
                }

                return li;
            }

            void SwapElements(T[] anyArray, int li, int i)
            {
                T tmp = anyArray[i];
                anyArray[i] = anyArray[li];
                anyArray[li] = tmp;
            }
        }
    }
}
