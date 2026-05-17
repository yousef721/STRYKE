namespace STRYKE.BLL.Services.Interface;

public interface IHomeServices
{
    public Task<Response<HomeVM>> GetHomeDataAsync();
}
