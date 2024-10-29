using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_2.Data;
using Assignment_2.Models;
using Assignment_2.Views.Contacts;

namespace Assignment_2.Controllers
{
    public class ContactsController : Controller
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create or Edit
        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            var contact = new Contact();
            if (id.HasValue)
            {
                contact = await _context.Contacts.FindAsync(id);
                if (contact == null)
                {
                    return NotFound();
                }
            }

            var viewModel = new CreateAndEditModel
            {
                Id = contact.Id,
                firstName = contact.firstName,
                lastName = contact.lastName,
                Phone = contact.Phone,
                Email = contact.Email,
                Category = contact.Category,
                Organization = contact.Organization
            };

            return View(viewModel);
        }

        // POST: Contacts/Create or Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(CreateAndEditModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0) // Create
                {
                    var contact = new Contact
                    {
                        firstName = viewModel.firstName,
                        lastName = viewModel.lastName,
                        Phone = viewModel.Phone,
                        Email = viewModel.Email,
                        Category = viewModel.Category,
                        Organization = viewModel.Organization
                    };

                    _context.Add(contact);
                    await _context.SaveChangesAsync();
                }
                else // Edit
                {
                    var contactToUpdate = await _context.Contacts.FindAsync(viewModel.Id);
                    if (contactToUpdate == null)
                    {
                        return NotFound();
                    }

                    contactToUpdate.firstName = viewModel.firstName;
                    contactToUpdate.lastName = viewModel.lastName;
                    contactToUpdate.Phone = viewModel.Phone;
                    contactToUpdate.Email = viewModel.Email;
                    contactToUpdate.Category = viewModel.Category;
                    contactToUpdate.Organization = viewModel.Organization;

                    _context.Update(contactToUpdate);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel); // Return the same view with the model if validation fails
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
