using AutoMapper;
using FluentValidation;
using SaraTort.BLL.Interface;
using SaraTort.DAL.Interfaces;
using SaraTort.Domain.Entities;
using SaraTort.Shared.DTOs.User;

namespace SaraTort.BLL.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<UserForCreateDto> _createValidator;
    private readonly IValidator<UserForUpdateDto> _updateValidator;

    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<UserForCreateDto> createValidator,
        IValidator<UserForUpdateDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<long> CreateAsync(UserForCreateDto dto)
    {
        var validation = await _createValidator.ValidateAsync(dto);

        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = _mapper.Map<User>(dto);

        await _unitOfWork.Repository<User>().AddAsync(user);

        await _unitOfWork.SaveAsync();

        return user.Id;
    }

    public async Task<bool> UpdateAsync(long id, UserForUpdateDto dto)
    {
        var validation = await _updateValidator.ValidateAsync(dto);

        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = await _unitOfWork.Repository<User>()
            .GetAsync(x => x.Id == id);

        if (user is null)
            return false;

        _mapper.Map(dto, user);

        _unitOfWork.Repository<User>().Update(user);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _unitOfWork.Repository<User>()
            .GetAsync(x => x.Id == id);

        if (user is null)
            return false;

        _unitOfWork.Repository<User>().Delete(user);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var user = await _unitOfWork.Repository<User>()
            .GetAsync(x => x.Id == id);

        if (user is null)
            throw new Exception("User topilmadi.");

        return _mapper.Map<UserForResultDto>(user);
    }

    public async Task<string> LoginAsync(UserForResultDto request)
    {
        var user = await _unitOfWork.Repository<User>()
            .GetAsync(x =>
                x.PhoneNumber == request.PhoneNumber &&
                x.Password == request.Password);

        if (user is null)
            throw new Exception("Telefon raqam yoki parol noto'g'ri.");

        return "Login muvaffaqiyatli.";
    }
}