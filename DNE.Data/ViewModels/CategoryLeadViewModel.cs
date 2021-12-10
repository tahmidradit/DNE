using DNE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNE.Data.ViewModels
{
    public class CategoryLeadViewModel 
    {
        public IEnumerable<Category> Categories { get; set; }
        public Lead Lead { get; set; }
    }
}
