using Blazor.IndexedDB;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace IndexDB_Demo.Model
{
    public class ExampleDb : IndexedDb
    {
        public ExampleDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<Person> People { get; set; }
    }

    public class Person
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>(); // Navigation property
    }

    public class Address
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }
        public long PersonId { get; set; } // Foreign key to Person
        public string Street { get; set; }
        public string City { get; set; }
    }

}
