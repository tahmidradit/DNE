using DNE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNE.Repository.Interfaces
{
    public interface ILead
    {
        Lead RetriveLead(int Id);
        IEnumerable<Lead> ToListLeads();
        Lead Add(Lead lead);
        Lead Update(Lead leadUpdate);
        Lead Delete(int Id);
    }
}
