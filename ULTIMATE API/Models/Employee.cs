using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ULTIMATE_API.Models
{
    public class Employee
    {
        /*We can see several attributes in our entities. The [Column] attribute will
            specify that the Id property is going to be mapped with a different name
            in the database.*/
        [Column("EmployeeId")]
        public Guid Id { get; set; }
        /* The [Required] and [MaxLength] properties are here
            for validation purposes. The first one declares the property as mandatory
            and the second one defines its maximum length. */
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string Position { get; set; }
        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
