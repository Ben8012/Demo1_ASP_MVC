using Demo1_ASP_MVC.Models.ContactModels;
using D = DAL.Entities;

namespace Demo1_ASP_MVC.Models.ViewModels.ContactVM

{
    public class ListContactVM
    {

        public ListContactVM(List<D.Contact> contacts)
        {
            _contacts = contacts;
            
        }

        private List<D.Contact> _contacts;

        public List<D.Contact> Contacts { get => _contacts; }

        public int NbContact { get => _contacts.Count(); }

        public void AddContat(D.Contact newContact)
        {
            if (newContact == null) throw new ArgumentNullException(nameof(newContact));
            if (_contacts == null) _contacts = new List<D.Contact>();
            if (!_contacts.Contains(newContact)) _contacts.Add(newContact);

        }

       
    }
}
