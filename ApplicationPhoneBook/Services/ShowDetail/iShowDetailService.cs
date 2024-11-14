using ApplicationPhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.ShowDetail
{
    public interface iShowDetailService
    {
        ResultDto<ShowDetailDto> ShowDetail(ShowDetailDto showDetailDto, int Id);
    }

}
