using DNE.Data.Models;
using DNE.Repository.Data;
using DNE.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNE.Services.InterfaceServices
{
    public class LeadService : ILead
    {
        private readonly ApplicationDbContext context;

        public LeadService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Lead Add(Lead lead)
        {
            context.Leads.Add(lead);
            context.SaveChanges();
            return lead;
        }

        public Lead Delete(int Id)
        {
            Lead findLeadById = context.Leads.Find(Id);

            if (findLeadById != null)
            {
                context.Leads.Remove(findLeadById);
                context.SaveChanges();
            }
            return findLeadById;
        }

        public Lead RetriveLead(int Id)
        {
            return context.Leads.Find(Id);
        }

        public IEnumerable<Lead> ToListLeads()
        {
            return context.Leads.Include(m => m.Category).ToList();
        }

        public Lead Update(Lead leadUpdate)
        {
            var lead = context.Leads.Attach(leadUpdate);
            lead.State = EntityState.Modified;
            context.SaveChanges();
            return leadUpdate;
        }
    }
}
