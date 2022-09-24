using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Domains
{
    public enum EGender
    {
        Male,
        Female
    }
    public enum EEmployeeFilterableColumns
    {
        FirstName,
        Gender,
        LastName
    }


    [Table("Employee")]
    public class Employee
    {
        [Required]
        public byte Age { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public EGender Gender;

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }

        public Employee()
        {

        }
    }
}
