using Blazor.IndexedDB;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace IndexDB_Demo.Model
{
    public class PersonDB : IndexedDb
    {
        public PersonDB(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<Person> People { get; set; }
    }

    public class Person
    {
        public long Id { get; set; } // Primary Key (Auto-increment in IndexedDB)
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>(); // Navigation property
    }

    public class Address
    {
        public long Id { get; set; } // Primary Key for Address
        public long PersonId { get; set; } // Foreign Key (Manual Reference)
        public string? Street { get; set; }
        public string? City { get; set; }
    }
}
