using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Data.Models
{
    public class Login : Entity
    {
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        //Nullable for no onDeleteCascade behaviour
        //Required --> Default OndeleteCascade
        public int? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
