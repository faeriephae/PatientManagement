using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Data.Models
{
    public class Treatment : Entity
    {
        [Required]
        public int PersonId { get; set; }
        public Person People { get; set; }

        public int? LoginId { get; set; }
        public Login? Login { get; set; }

        public string Memo { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
