using EShop.Core.Domain.ValueObjects;

namespace EShop.Domain.ValueObjects
{
    public class RequestUser : ValueObject<RequestUser>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public RequestUser(string name, string email, Address address)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(RequestUser.Name)) : name;
            Email = string.IsNullOrEmpty(email) ? throw new ArgumentNullException(nameof(RequestUser.Email)) : email;
            Address = address;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<Object>() { Name, Email, Address };
        }
    }
}
