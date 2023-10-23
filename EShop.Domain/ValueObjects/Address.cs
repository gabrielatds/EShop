using EShop.Core.Domain.ValueObjects;

namespace EShop.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public int CountryCode { get; set; }

        public Address(string street, int number, int postalCode, string city, int countryCode)
        {
            Street = string.IsNullOrEmpty(street) ? throw new ArgumentNullException(nameof(Address.Street)) : street;
            Number = number;
            PostalCode = postalCode;
            City = string.IsNullOrEmpty(street) ? throw new ArgumentNullException(nameof(Address.City)) : city;
            CountryCode = countryCode;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<Object>() { Street, Number, PostalCode, City, CountryCode };
        }
    }
}
