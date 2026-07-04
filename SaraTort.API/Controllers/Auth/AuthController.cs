using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Restourant.WebApi.Controllers.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController(
    IUserService service) : ControllerBase
{
    private readonly IUserService _service = service;

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto request)
    {
        try
        {
            string result = await _service.LoginAsync(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (CustomException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}