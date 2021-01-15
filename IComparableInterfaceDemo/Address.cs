using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableInterfaceDemo
{
    class Address : IComparable, IComparable<Address>
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public int CompareTo(object obj)
        {
            Address address = null;

            if (obj is Address)
                address = obj as Address;
            else
                throw new InvalidCastException("Invalid cast. obj is not an Address");

            if (string.Compare(Street, address.Street, true) == 0)
            {
                if (string.Compare(City, address.City, true) == 0)
                {
                    return string.Compare(Zip, address.Zip, true);
                }
                else
                    return string.Compare(City, address.City, true);
            }
            else
                return string.Compare(Street, address.Street, true);
        }

        public int CompareTo(Address other)
        {
            if (string.Compare(Street, other.Street, true) == 0)
            {
                if (string.Compare(City, other.City, true) == 0)
                {
                    return string.Compare(Zip, other.Zip, true);
                }
                else
                    return string.Compare(City, other.City, true);
            }
            else
                return string.Compare(Street, other.Street, true);
        }
    }
}