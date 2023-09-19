using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Data.Models
{
    public class TreatmentArticle : Entity
    {
        [Required]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        [Required]
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

        [Required]
        public int Quantity { get; set; } 
    }
}
