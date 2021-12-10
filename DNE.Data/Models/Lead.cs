using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNE.Data.Models
{
    public class Lead
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByUserId { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedByUserId { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Updated")]
        public DateTime DateUpdated { get; set; }
    }
}
