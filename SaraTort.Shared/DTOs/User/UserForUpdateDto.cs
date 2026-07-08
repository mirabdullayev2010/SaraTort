namespace SaraTort.Shared.DTOs.User;

public class UserForUpdateDto
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public int Age { get; set; }
}
