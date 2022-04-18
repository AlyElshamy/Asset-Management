using System.ComponentModel.DataAnnotations;

namespace AssetProject.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Is Required"),RegularExpression("^[0-9]+$", ErrorMessage = " Accept Number Only")]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "Is Required"), RegularExpression(@"^[a-zA-z]+([\s][a-zA-Z]+)*$", ErrorMessage = " Not Valid"), MinLength(5, ErrorMessage = "Minimum Length Is 5")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Is Required"),RegularExpression(@"^[a-zA-z]+([\s][a-zA-Z]+)*$", ErrorMessage = " Not Valid"), MinLength(5, ErrorMessage = "Minimum Length Is 5")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Is Required"), RegularExpression("^[0-9]+$", ErrorMessage = " Accept Number Only")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Is Required"), RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage ="Not Valid")]
        public string Email { get; set; }
        [RegularExpression(@"^[a-zA-z]+([\s][a-zA-Z]+)*$", ErrorMessage = " Not Valid"), MinLength(5, ErrorMessage = "Minimum Length Is 5")]
        public string Notes { get; set; }
        [RegularExpression(@"^[a-zA-z]+([\s][a-zA-Z]+)*$", ErrorMessage = " Not Valid"), MinLength(5, ErrorMessage = "Minimum Length Is 5")]
        public string Remark { get; set; }
    }
}
