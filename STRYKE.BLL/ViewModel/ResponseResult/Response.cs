namespace STRYKE.BLL.ViewModel.ResponseResult;

public record Response<T>(T ResponseResult, string? ErrorMessage, bool IsHaveError) where T : class;
