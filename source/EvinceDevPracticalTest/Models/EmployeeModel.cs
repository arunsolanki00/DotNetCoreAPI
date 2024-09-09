using System.ComponentModel.DataAnnotations;

namespace EvinceDevPracticalTest.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(128), MinLength(2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Valid email required")]
        public string Email { get; set; }

        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphabets and number allowed")]
        public string EmployeeID { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression("^([0]|\\+91)?\\d{10}", ErrorMessage ="Only valid Indian mobile number allowed")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Range(18, 60, ErrorMessage = "Enter age between 18 to 60")]
        public int Age { get; set; }

        public string OtherPhoneNumber { get; set; }
    }
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Valid email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
