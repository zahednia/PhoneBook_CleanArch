using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Dto;
using DomainPhoneBook.Entities;

namespace ApplicationPhoneBook.Services.EditContact
{
    public class EditContactService : iEditContact
    {
        private readonly IDataBaseContext dataBaseContext;

        public EditContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(EditContactDto editContactDto)
        {

            Contact contact = dataBaseContext.Contacts.Find(editContactDto.Id);


            if (contact == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "مخاطب پیدا نشد"
                };
            }

            contact.Update(
                editContactDto.Name,
                editContactDto.LastName,
                editContactDto.Company,
                editContactDto.Description,
                editContactDto.PhoneNumber
            );


            dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "اطلاعات مخاطب با موفقیت ویرایش شد",
            };
        }
    }

}
