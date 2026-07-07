using SaraTort.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities;

[Table("Users")]
public class User : BaseEntity
{
    [Column("firstName")]
    public required string FirstName { get; set; }

    [Column("lastName")]
    public required string LastName { get; set; }

    [Column("phoneNumber"), MaxLength(13)]
    public required string PhoneNumber { get; set; }

    [Column("age")]
    public required int Age { get; set; }

    [Column("password"), MaxLength(100)]
    public required string Password { get; set; }

}
