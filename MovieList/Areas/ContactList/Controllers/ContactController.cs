using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Areas.ContactList.Models;

namespace MovieList.Areas.ContactList.Controllers
{
    [Area("ContactList")]
    public class ContactController : Controller
    {
        // Context property
        private ContactContext context { get; set; }
        // Assign context object to context property
        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }

        [Route("[area]/Contacts/{id?}")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Action = "Index";
            var contacts = context.Contacts.OrderBy(m => m.Name).ToList();
            return View(contacts);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Contact());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

        [Route("[area]/Contact/Edit/{id?}/{slug?}")]
        // Both Add and Edit will go to the Edit view
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    context.Contacts.Add(contact);
                }
                else
                {
                    context.Contacts.Update(contact);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }
    }
}
