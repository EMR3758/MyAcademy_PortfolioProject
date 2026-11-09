using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;
        public ContactController(PortfolioContext context)
        {
            _context = context;
        }
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("ContactList");
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            var value = _context.Contacts.Find(contact.ContactId);
            value.Title = contact.Title;
            value.Description = contact.Description;
            value.Email = contact.Email;
            value.Location = contact.Location;
            value.PhoneNumber = contact.PhoneNumber;
            _context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}
