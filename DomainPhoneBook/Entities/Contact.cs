using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainPhoneBook.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Company { get; private set; }
        public string Description { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime CreateAt { get; private set; }

        public Contact()
        {

        }

        public Contact(string name, string lastName, string company, string phoneNumber ,string description )
        {
            Name = name;
            LastName = lastName;
            Company = company;
            PhoneNumber = phoneNumber;
            Description= description;
            CreateAt = DateTime.Now;
            
        }

       public void Update(string name, string lastName, string company, string phoneNumber ,string description)
        {
            Name = name;
            LastName = lastName;
            Company = company;
            PhoneNumber = phoneNumber;
            Description = description;
        }
    }
}
