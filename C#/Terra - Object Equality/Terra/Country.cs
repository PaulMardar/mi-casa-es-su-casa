using System;
using System.Diagnostics.CodeAnalysis;

namespace iQuest.Terra
{
    public class Country : IComparable<Country>
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Country))
                return false;

            var country = obj as Country;
            return this.Name == country.Name;
        }

        public int CompareTo(object other)
        {
            if (!(other is Country))
            {
                throw new ArgumentException("dict goo BUM");
            }
            var country = other as Country;
            return this.CompareTo(country);
        }

        public int CompareTo([AllowNull] Country country)
        {
            if (country == null)
            {
                return 1;
            }
            return Name.CompareTo(country.Name);
        }
    }
}