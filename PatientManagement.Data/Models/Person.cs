using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Data.Models
{
    public class Person : Entity
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50),]
        public string LastName { get; set; }

        [StringLength(500)]
        public string Address { get; set; } = string.Empty;

    }
}
