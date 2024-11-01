using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.DTO;
using DomainPhoneBook.Entities;

namespace ApplicationPhoneBook.Services.AddNewContact
{
    public class AddNewService : IAddNewService
    {
        private readonly IDataBaseContext dataBaseContext;

        public AddNewService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public ResultDTO Execute(AddNewContactDTO newContact)
        {
            if (string.IsNullOrEmpty(newContact.PhoneNumber))
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "شماره موبایل اجباری می باشد. لطفا شماره موبایل هم وارد کنید"
                };
            }
            Contact contact = new Contact
                (newContact.Name,
                newContact.LastName,
                newContact.PhoneNumber,
                newContact.Description,
                newContact.Company);

            dataBaseContext.Contacts.Add(contact);
            dataBaseContext.SaveChanges();


            return new ResultDTO
            {
                IsSuccess = true,
                Message = $" مخاطب {contact.Name} {contact.LastName} با موفقیت در دیتابیس ذخیره شد",
            };

        }
    }
}
