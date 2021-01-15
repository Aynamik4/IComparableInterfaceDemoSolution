using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableInterfaceDemo
{
    class Person : IComparable, IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }

        public int CompareTo(object obj)
        {
            Person person = null;

            if (obj is Person)
                person = obj as Person;
            else
                throw new InvalidCastException("Invalid cast. obj is not a Person");

            if (string.Compare(LastName, person.LastName, true) == 0)
            {
                if (string.Compare(FirstName, person.FirstName, true) == 0)
                {
                    return BirthYear.CompareTo(person.BirthYear);
                }
                else
                    return string.Compare(FirstName, person.FirstName, true);
            }
            else
                return string.Compare(LastName, person.LastName, true);
        }

        public int CompareTo(Person other)
        {
            if (string.Compare(LastName, other.LastName, true) == 0)
            {
                if (string.Compare(FirstName, other.FirstName, true) == 0)
                {
                    return BirthYear.CompareTo(other.BirthYear);
                }
                else
                    return string.Compare(FirstName, other.FirstName, true);
            }
            else
                return string.Compare(LastName, other.LastName, true);
        }
    }
}
