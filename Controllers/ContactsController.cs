using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_2.Data;
using Assignment_2.Models;

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
        public async Task<IActionResult> Details(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            if (slug != contact.Slug)
            {
                return RedirectToAction("Details", new { id = contact.Id, slug = contact.Slug });
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            ViewBag.CategoryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Family", Text = "Family" },
                new SelectListItem { Value = "Friend", Text = "Friend" },
                new SelectListItem { Value = "Work", Text = "Work" },
                new SelectListItem { Value = "Other", Text = "Other" },
            };

            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,Phone,Email,Category,Organization")] Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Organization))
            {
                contact.Organization = "N/A"; // Set default to N/A if blank
            }

            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Repopulate category list if model state is invalid
            ViewBag.CategoryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Family", Text = "Family" },
                new SelectListItem { Value = "Friend", Text = "Friend" },
                new SelectListItem { Value = "Work", Text = "Work" },
                new SelectListItem { Value = "Other", Text = "Other" },
            };

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            if (slug != contact.Slug)
            {
                return RedirectToAction("Edit", new { id = contact.Id, slug = contact.Slug });
            }

            // Populate the category list
            ViewBag.CategoryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Family", Text = "Family" },
                new SelectListItem { Value = "Friend", Text = "Friend" },
                new SelectListItem { Value = "Work", Text = "Work" },
                new SelectListItem { Value = "Other", Text = "Other" },
            };

            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string slug, [Bind("Id,firstName,lastName,Phone,Email,Category,Organization")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(contact.Organization))
            {
                contact.Organization = "N/A"; // Set default to N/A if blank
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = contact.Id, slug = contact.Slug });
            }

            // Repopulate category list if model state is invalid
            ViewBag.CategoryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Family", Text = "Family" },
                new SelectListItem { Value = "Friend", Text = "Friend" },
                new SelectListItem { Value = "Work", Text = "Work" },
                new SelectListItem { Value = "Other", Text = "Other" },
            };

            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            if (slug != contact.Slug)
            {
                return RedirectToAction("Delete", new { id = contact.Id, slug = contact.Slug });
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string slug)
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

        public IActionResult SaveContact(int? id)
        {
            // Populate category list
            ViewBag.CategoryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Family", Text = "Family" },
                new SelectListItem { Value = "Friend", Text = "Friend" },
                new SelectListItem { Value = "Work", Text = "Work" },
                new SelectListItem { Value = "Other", Text = "Other" },
            };

            if (id == null) // If no ID, it's a create action
            {
                return View(new Contact()); // Empty model for new contact
            }
            else // If ID is provided, it's an edit action
            {
                var contact = _context.Contacts.Find(id);
                if (contact == null)
                {
                    return NotFound();
                }
                return View(contact); // Populate form with existing data
            }
        }

        [HttpPost]
        public IActionResult SaveContact(Contact contact)
        {
            // Re-populate category list for validation
            ViewBag.CategoryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Family", Text = "Family" },
                new SelectListItem { Value = "Friend", Text = "Friend" },
                new SelectListItem { Value = "Work", Text = "Work" },
                new SelectListItem { Value = "Other", Text = "Other" },
            };

            if (ModelState.IsValid)
            {
                if (contact.Id == 0) // If no ID, add new contact
                {
                    contact.DateAdded = DateTime.Now; // Set date added for new contact
                    _context.Add(contact); // Add the contact to the context
                }
                else // If ID exists, update the existing contact
                {
                    _context.Update(contact); // Update the contact in the context
                }
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("Index"); // Redirect to the index page or another appropriate action
            }

            return View(contact); // Return the same view with the model if validation fails
        }
    }
}
