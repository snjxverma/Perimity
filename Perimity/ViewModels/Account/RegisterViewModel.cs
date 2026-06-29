using System.ComponentModel.DataAnnotations;

namespace Perimity.ViewModels.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Full Name is required.")]
    [StringLength(100, MinimumLength = 3)]
    [RegularExpression(@"^[A-Za-z ]+$",
        ErrorMessage = "Full Name should contain only letters and spaces.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mobile Number is required.")]
    [RegularExpression(@"^[6-9]\d{9}$",
        ErrorMessage = "Enter a valid 10-digit Indian mobile number.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [StringLength(20, MinimumLength = 8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirm Password is required.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password),
        ErrorMessage = "Password and Confirm Password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}