using DapperEstate.Areas.Admin.Dtos.PictureDtos;

namespace DapperEstate.Areas.Admin.Service.AdminPictureService
{
    public interface IPictureService
    {
      Task<List<ResultPictureDto>> GetPictureAsync(int id);
    }
}
