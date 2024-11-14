using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Dto;
using ApplicationPhoneBook.Services.ShowDetail;

namespace ApplicationPhoneBook.Services.ShowDetail
{
    public class ShowDetailService : iShowDetailService
    {
        private readonly IDataBaseContext dataBaseContext;

        public ShowDetailService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ResultDto<ShowDetailDto> ShowDetail(ShowDetailDto showDetailDto, int Id)
        {
            var contact = dataBaseContext.Contacts.Find(Id);
            if (contact == null)
            {
                return new ResultDto<ShowDetailDto>
                {
                    IsSuccess = false,
                    Message = "مخاطب پیدا نشد",
                    Data = null,
                };
            }

            var data = new ShowDetailDto
            {
                Company = contact.Company,
                CreateAt = contact.CreateAt,
                Description = contact.Description,
                Id = contact.Id,
                LastName = contact.LastName,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber
            };

            return new ResultDto<ShowDetailDto>
            {
                Data = data,
                IsSuccess = true,
            };
        }
    }
}
