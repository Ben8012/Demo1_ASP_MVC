using Demo1_ASP_MVC.Context;
using Demo1_ASP_MVC.Models.ContactModels;
using Demo1_ASP_MVC.Models.ViewModels.ContactVM;
using Microsoft.AspNetCore.Mvc;

namespace Demo1_ASP_MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(AddContact));
        }

        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(AddContactVM form)
        {

            if (!ModelState.IsValid)
                return View();

            FakeDB.Contacts.Add(new Contact(
                FakeDB.Contacts.Count <= 0 ? 1 : FakeDB.Contacts.Last().Id +1 ,
                form.FirstName, 
                form.LastName, 
                form.SurName, 
                form.Email, 
                form.Phone, 
                form.Birthdate)) ;

            return RedirectToAction(nameof(ListContact));
        }

        public IActionResult ListContact()
        {

            ListContactVM listContact = new ListContactVM(FakeDB.Contacts.OrderBy(c => c.Id).ToList());
            
            return View(listContact);
        }

       
        public IActionResult DeleteContact(int id)
        {
            FakeDB.Contacts.RemoveAll(c => c.Id == id);
            ListContactVM listViewModel = new ListContactVM(FakeDB.Contacts);
            return RedirectToAction(nameof(ListContact),listViewModel);
        }

        public IActionResult ModifyContact(int id)
        {
            Contact? contact = FakeDB.Contacts.SingleOrDefault(c => c.Id == id, null);

            if (contact == null)
            {
                throw new Exception("le contact n'existe pas !!");
            }

            AddContactVM contactVM = new AddContactVM
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                SurName = contact.SurName,
                Email = contact.Email,
                Phone = contact.Phone,
                Birthdate = contact.Birthdate,

            };

            return View(contactVM);
        }

        [HttpPost]
        public IActionResult ModifyContact(AddContactVM form)
        {
            Contact? contact = FakeDB.Contacts.SingleOrDefault(c => c.Id == form.Id, null);
            if (contact == null)
            {
                throw new Exception("le contact n'existe pas !!");
            }

            FakeDB.Contacts.RemoveAll(c => c.Id ==form.Id);

            contact.Id = form.Id;
            contact.FirstName = form.FirstName;
            contact.LastName = form.LastName;
            contact.SurName = form.SurName;
            contact.Email = form.Email;
            contact.Phone = form.Phone;
            contact.Birthdate = form.Birthdate;

            FakeDB.Contacts.Add(contact);
           
            ListContactVM listViewModel = new ListContactVM(FakeDB.Contacts);
            return RedirectToAction(nameof(ListContact), listViewModel);
        }

       
        public IActionResult LoveContact(int id)
        {
            Contact? contact = FakeDB.Contacts.SingleOrDefault(c => c.Id == id, null);

            contact.Love = true;

            if (contact == null)
            {
                throw new Exception("le contact n'existe pas !!");
            }

            FakeDB.Contacts.RemoveAll(c => c.Id == id);

            FakeDB.Contacts.Add(contact);

            ListContactVM listViewModel = new ListContactVM(FakeDB.Contacts);

            return RedirectToAction(nameof(ListContact));
        }



        public IActionResult UnLoveContact(int id)
        {
            Contact? contact = FakeDB.Contacts.SingleOrDefault(c => c.Id == id, null);

            contact.Love = false;

            if (contact == null)
            {
                throw new Exception("le contact n'existe pas !!");
            }

            FakeDB.Contacts.RemoveAll(c => c.Id == id);

            FakeDB.Contacts.Add(contact);

            ListContactVM listViewModel = new ListContactVM(FakeDB.Contacts);

            return RedirectToAction(nameof(ListContact));
        }
       
    }
}
