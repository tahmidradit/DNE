using DNE.Data.Models;
using DNE.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DNE.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> _userManager;

        public CategoryController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            Category category = new Category()
            {
                CreatedByUserId = userId,
                UpdatedByUserId = userId,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            return View(category);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category Category)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            if (ModelState.IsValid)
            {
                await context.Categories.AddAsync(Category);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            Category category = new Category()
            {
                CreatedByUserId = userId,
                UpdatedByUserId = userId,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var findById = await context.Categories.FindAsync(id);

            Category category = new Category()
            {
                Name = findById.Name,
                CreatedByUserId = findById.CreatedByUserId,
                UpdatedByUserId = findById.UpdatedByUserId,
                DateCreated= findById.DateCreated,
                DateUpdated= findById.DateUpdated,
            };
            
            return View(category);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category, int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;
            var findById = await context.Categories.FindAsync(id);

            if (ModelState.IsValid)
            {
                findById.Name = category.Name;
                findById.UpdatedByUserId = category.UpdatedByUserId;
                findById.DateUpdated = category.DateUpdated;
                
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            Category categoryDomainModel = new Category()
            {
                Name = findById.Name,
                CreatedByUserId = findById.CreatedByUserId,
                UpdatedByUserId = findById.UpdatedByUserId,
                DateCreated = findById.DateCreated,
                DateUpdated = findById.DateUpdated,
            };

            return View(categoryDomainModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            var findById = await context.Categories.FindAsync(id);

            Category categoryDomainModel = new Category()
            {
                Name = findById.Name,
                CreatedByUserId = findById.CreatedByUserId,
                UpdatedByUserId = findById.UpdatedByUserId,
                DateCreated = findById.DateCreated,
                DateUpdated = findById.DateUpdated,
            };

            return View(categoryDomainModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Category category, int id)
        {
            
            var findById = await context.Categories.FindAsync(id);

            if (ModelState.IsValid)
            {
                context.Categories.Remove(findById);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            

            return View();
        }
    }
}
