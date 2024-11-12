using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.GetlistContact
{
    public interface IGetlistContactService
    {
        List<ContactListDto> Execute(string searchKey=null);
    }
}
