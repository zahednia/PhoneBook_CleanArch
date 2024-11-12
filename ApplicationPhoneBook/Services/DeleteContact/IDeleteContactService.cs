using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.DeleteContact
{
    public interface IDeleteContactService
    {
        ResultDto Execute(int ContactId);
    }

    public class DeleteContactService : IDeleteContactService
    {
        private readonly IDataBaseContext database;

        public DeleteContactService(IDataBaseContext dataBaseContext)
        {
            this.database = dataBaseContext;
        }
        public ResultDto Execute(int ContactId)
        {
            var contact = database.Contacts.Find(ContactId);
            if (contact != null)
            {
                database.Contacts.Remove(contact);
                database.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "مخاطب با موفقیت حذف شد."
                };
            }
            return new ResultDto
            {
                IsSuccess = false,
                Message = "مخاطب یافت نشد"
            };
        }
    }
}
