using DNE.Data.Models;
using DNE.Data.ViewModels;
using DNE.Repository.Data;
using DNE.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DNE.Web.Controllers
{
    public class LeadController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> _userManager;

        public LeadController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var leads = ilead.ToListLeads();
            var leads = context.Leads.Include(m => m.Category).ToList();
            return View(leads);
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            Lead lead = new Lead()
            {
                CreatedByUserId = userId,
                UpdatedByUserId = userId,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            CategoryLeadViewModel categoryLeadViewModel = new CategoryLeadViewModel()
            {
                Lead = lead,
                Categories = await context.Categories.ToListAsync()
            };

            return View(categoryLeadViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
        public async Task<IActionResult> Create(Lead lead)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            Lead leadDomainModel = new Lead()
            {
                CreatedByUserId = userId,
                UpdatedByUserId = userId,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            CategoryLeadViewModel categoryLeadViewModel = new CategoryLeadViewModel()
            {
                Lead = leadDomainModel,
                Categories = await context.Categories.ToListAsync()
            };
            if (ModelState.IsValid)
            {
                await context.Leads.AddAsync(lead);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryLeadViewModel);
        }
    }
}
