using DAL.Respository;
using Demo1_ASP_MVC.Context;
using Demo1_ASP_MVC.Models.ContactModels;
using Demo1_ASP_MVC.Models.ViewModels.ContactVM;
using Demo1_ASP_MVC.Service;
using Microsoft.AspNetCore.Mvc;
using D = DAL.Entities; 

namespace Demo1_ASP_MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly SessionManager _sessionManager;
        private readonly ContactRepository _contactRepository;

        public ContactController(SessionManager sessionManager, ContactRepository contactRepository)
        {
            _sessionManager = sessionManager;
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(ListContact));
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
            D.Contact contact = new D.Contact
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                SurName = form.SurName, 
                Birthdate = form.Birthdate,
                Phone = form.Phone,

            };

            int id = _contactRepository.AddContact(contact);

            //FakeDB.Contacts.Add(new Contact
            //{
            //    Id = FakeDB.Contacts.Count <= 0 ? 1 : FakeDB.Contacts.Last().Id + 1,
            //    FirstName = form.FirstName,
            //    LastName = form.LastName,
            //    SurName = form.SurName,
            //    Email = form.Email,
            //    Phone = form.Phone,
            //    Birthdate = form.Birthdate,
            //}) ;

            return RedirectToAction(nameof(ListContact));
        }

        public IActionResult ListContact()
        {

            //ListContactVM listContact = new ListContactVM(FakeDB.Contacts
            //    .OrderBy(c => c.Id).ToList()
            //    );

            //List<Contact>  followers = new List<Contact>(FakeDB.Contacts
            //    .Join(FakeDB.Followers, c => c.Id, f => f.FollowedId, (c, f)
            //       => new Contact
            //       {
            //           Id = c.Id,
            //           FirstName = c.FirstName,
            //           LastName = c.LastName,
            //           Email = c.Email,
            //           Phone = c.Phone,
            //           Birthdate = c.Birthdate,
            //           SurName = c.SurName,
            //           FollowerId = f.FollowerId,
            //           FollowedId = f.FollowerId,
            //       })
            //    //.Where(c => c.FollowedId == _sessionManager.Id)
            //    ); 

            //if(!(followers.Count <= 0))
            //{
            //      listContact.Followers = followers;
            //}

            ListContactVM listContacts = new ListContactVM(_contactRepository.getAllContact().ToList());

            return View(listContacts);
        }

       
        public IActionResult DeleteContact(int id)
        {
            //FakeDB.Contacts.RemoveAll(c => c.Id == id);
            //ListContactVM listViewModel = new ListContactVM(FakeDB.Contacts);

            bool isdeleted = _contactRepository.DeleteContact(id);
            if (isdeleted)
                return RedirectToAction(nameof(ListContact));
            return RedirectToAction(nameof(ListContact));
        }

        public IActionResult ModifyContact(int id)
        {
            //Contact? contact = FakeDB.Contacts.SingleOrDefault(c => c.Id == id, null);

            //if (contact == null)
            //{
            //    throw new Exception("le contact n'existe pas !!");
            //}

            D.Contact contact = _contactRepository.GetContactById(id);

            AddContactVM contactVM = new AddContactVM
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                SurName = contact.SurName,
                Email = contact.Email,
                Phone = contact.Phone,
                Birthdate = (DateTime)contact.Birthdate,

            };

            return View(contactVM);
        }

        [HttpPost]
        public IActionResult ModifyContact(AddContactVM form)
        {
            if(!ModelState.IsValid) return View(form);

            //Contact? contact = FakeDB.Contacts.SingleOrDefault(c => c.Id == form.Id, null);

            //if (contact == null) throw new Exception("le contact n'existe pas !!");

            //FakeDB.Contacts.RemoveAll(c => c.Id ==form.Id);



            //contact.Id = form.Id;
            //contact.FirstName = form.FirstName;
            //contact.LastName = form.LastName;
            //contact.SurName = form.SurName;
            //contact.Email = form.Email;
            //contact.Phone = form.Phone;
            //contact.Birthdate = form.Birthdate;

            //FakeDB.Contacts.Add(contact);

            //ListContactVM listViewModel = new ListContactVM(FakeDB.Contacts);

            D.Contact contact = new D.Contact
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Id = form.Id,
                SurName = form.SurName,
                Phone = form.Phone,
                Birthdate = form.Birthdate,
            };

            bool isUpdated = _contactRepository.UpdateContact(form.Id, contact);

            return RedirectToAction(nameof(ListContact));
        }

       
        //public IActionResult LoveContact(int id)
        //{

        //    FakeDB.Followers.Add( new MtmFollower
        //    {
        //        FollowerId = id,
        //        FollowedId = _sessionManager.Id,
        //    });

        //    return RedirectToAction(nameof(ListContact));
        //}



        //public IActionResult UnLoveContact(int id)
        //{
        //    //Contact? contact = FakeDB.Contacts.SingleOrDefault(c => c.Id == id, null);

        //    //contact.Follower = 0;

        //    //if (contact == null)
        //    //{
        //    //    throw new Exception("le contact n'existe pas !!");
        //    //}

        //    //FakeDB.Contacts.RemoveAll(c => c.Id == id);

        //    //FakeDB.Contacts.Add(contact);

        //    //ListContactVM listViewModel = new ListContactVM(FakeDB.Contacts);

        //    return RedirectToAction(nameof(ListContact));
        //}
       
    }
}
