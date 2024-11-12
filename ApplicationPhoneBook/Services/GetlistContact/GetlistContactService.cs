using ApplicationPhoneBook.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationPhoneBook.Services.GetlistContact
{
    public class GetlistContactService : IGetlistContactService
    {
        private readonly IDataBaseContext dataBaseContext;

        public GetlistContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public List<ContactListDto> Execute(string searchKey=null)
        {
            var ContactQuery = dataBaseContext.Contacts.AsQueryable();
          
            if (!string.IsNullOrEmpty(searchKey))
            {
                ContactQuery = ContactQuery.Where(
                    p =>
                    p.Name.Contains(searchKey)
                    ||
                    p.LastName.Contains(searchKey)
                    ||
                    p.PhoneNumber.Contains(searchKey)
                    ||
                    p.Company.Contains(searchKey)
                    );
            }

            var contacts = ContactQuery.Select(p => new ContactListDto
            {
                FullName = $"{p.Name} {p.LastName}",
                PhoneNumber = p.PhoneNumber,
                Id = p.Id,
            }).ToList();
            return contacts;
        }
    }
}
