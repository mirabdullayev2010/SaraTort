using SaraTort.BLL.Interfaces;
using SaraTort.Domain.Entities;
using SaraTort.Shared.DTOs.User;

namespace SaraTort.BLL.Interface;

public interface IUserService : ICroudService<User, UserForCreateDto, UserForUpdateDto, UserForResultDto>
{
    Task<string> LoginAsync(UserForResultDto request);
}
