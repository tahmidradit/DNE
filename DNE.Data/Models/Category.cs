using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNE.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
    }
}
