using ApplicationPhoneBook.DTO;

namespace ApplicationPhoneBook.Services.AddNewContact
{
    public interface IAddNewService
    {
        ResultDTO Execute(AddNewContactDTO addNewContactDTO);
    }
}
